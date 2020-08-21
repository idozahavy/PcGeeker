using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessInfo
{
    public class ProcessUtilizationCollection
    {
        public HashSet<ProcessUtilization> ProcessUtilizations = null;

        public ProcessUtilizationCollection()
        {
            ProcessUtilizations = new HashSet<ProcessUtilization>(new ProcessUtilization.ProcessUtilizationEqualitor());
            Process[] procs = Process.GetProcesses();
            foreach(Process process in procs)
            {
                if(process.Id != 0)
                {
                    ProcessUtilizations.Add(new ProcessUtilization(process));
                }
            }
        }

        public void UpdateProcesses()
        {
            Process[] procs = Process.GetProcesses();
            HashSet<int> updateIds = new HashSet<int>();
            foreach(Process process in procs)
            {
                if(process.Id != 0)
                {
                    ProcessUtilization processUtil = new ProcessUtilization(process);
                    if(ProcessUtilizations.Contains(processUtil))
                    {
                        updateIds.Add(process.Id);
                        processUtil.Dispose();
                    }
                    else
                    {
                        ProcessUtilizations.Add(processUtil);
                    }
                }
            }
            foreach(ProcessUtilization procUtil in ProcessUtilizations)
            {
                if(updateIds.Contains(procUtil.process.Id))
                {
                    procUtil.GetUtilizationValue();
                }
            }
            ProcessUtilizations.RemoveWhere((ProcessUtilization procUtil) => procUtil.process == null);
        }
        public double UpdateGetTotalUtilization()
        {
            UpdateProcesses();
            return GetLastTotalUtilization();
        }
        public double GetLastTotalUtilization()
        {
            double total = 0;
            foreach(ProcessUtilization proc in ProcessUtilizations)
            { 
                total += proc.LastUtilization;
            }
            return total > 1 ? 1 : total;
        }
    }

    class ProcessComparer : IEqualityComparer<Process>
    {
        public bool Equals(Process x, Process y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Process obj)
        {
            return obj.Id * obj.ProcessName.GetHashCode();
        }
    }

    public class ProcessUtilization : IComparable<ProcessUtilization> , IEquatable<ProcessUtilization>
    {
        public Process process { get; private set; }
        public long LastUpdate { get; private set; }
        public long LastTicks { get; private set; }
        public double LastUtilization { get; private set; }

        public ProcessUtilization(Process process)
        {
            this.process = process;
            try
            {
                LastTicks = process.TotalProcessorTime.Ticks;
                LastUpdate = DateTime.Now.Ticks;
                process.Exited += Process_Exited;
            }
            catch // (InvalidOperationException e)
            {
                this.process = null;
            }
        }

        public void Dispose()
        {
            process.Exited -= Process_Exited;
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            process = null;
        }

        public double GetUtilizationValue()
        {
            if (process == null)
            {
                return -1;
            }
            long _lastUpdate = LastUpdate;
            LastUpdate = DateTime.Now.Ticks;
            float processElapsedTicks = process.TotalProcessorTime.Ticks - LastTicks;
            float timeElapsed = DateTime.Now.Ticks - _lastUpdate;
            LastUtilization = processElapsedTicks / timeElapsed / Environment.ProcessorCount;
            if (LastUtilization > 1)
            {
                LastUtilization = 1;
            }
            LastTicks = process.TotalProcessorTime.Ticks;
            return LastUtilization;
        }

        public int CompareTo(ProcessUtilization other)
        {
            if (this.process == null)
            {
                return 1;
            }
            if (other.process == null)
            {
                return -1;
            }
            return (int)((this.LastUtilization - other.LastUtilization)*100.0);
        }

        public bool Equals(ProcessUtilization other)
        {
            return this.process.Id == other.process.Id;
        }

        public class ProcessUtilizationEqualitor : IEqualityComparer<ProcessUtilization>
        {
            public bool Equals(ProcessUtilization x, ProcessUtilization y)
            {
                return x.Equals(y);
            }

            public int GetHashCode(ProcessUtilization obj)
            {
                if (obj == null || obj.process == null)
                {
                    return 0;
                }
                return 7 * obj.process.Id * obj.process.ProcessName.GetHashCode();
            }
        }
    }

}

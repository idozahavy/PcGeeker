namespace HardwareInfo.Analyzer
{
    public class CPUAnalysis : Analysis
    {
        public bool CoresPowerThresholded { get; internal set; }
        public bool DRAMPowerThresholded { get; internal set; }
        public bool GraphicsPowerThresholded { get; internal set; }
        public bool PackagePowerThresholded { get; internal set; }
        public bool BusClockThresholded { get; internal set; }
        public bool CoresThresholded { get; internal set; }
        public bool PackageTemperatureThresholded { get; internal set; }
        public bool TotalLoadThresholded { get; internal set; }

        internal CPUAnalysis()
        {
        }

        public CPUAnalysis(bool coresPowerThresholded, bool dRAMPowerThresholded, bool graphicsPowerThresholded,
            bool packagePowerThresholded, bool busClockThresholded, bool coresThresholded,
            bool packageTemperatureThresholded, bool totalLoadThresholded)
        {
            CoresPowerThresholded = coresPowerThresholded;
            DRAMPowerThresholded = dRAMPowerThresholded;
            GraphicsPowerThresholded = graphicsPowerThresholded;
            PackagePowerThresholded = packagePowerThresholded;
            BusClockThresholded = busClockThresholded;
            CoresThresholded = coresThresholded;
            PackageTemperatureThresholded = packageTemperatureThresholded;
            TotalLoadThresholded = totalLoadThresholded;
        }
    }
}
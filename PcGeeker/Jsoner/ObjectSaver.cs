using HardwareInfo;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jsoner
{
    class ObjectSaver
    {
        private static List<string> serializedObjectStrings;
        private static JsonSerializerSettings jsonSettings;

        public static void AddObjectToList(object obj)
        {
            if (jsonSettings == null)
            {
                jsonSettings = new JsonSerializerSettings()
                {
                    MaxDepth = null,
                    Formatting = Formatting.None,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
            }
            if (serializedObjectStrings == null)
            {
                serializedObjectStrings = new List<string>();
            }
            serializedObjectStrings.Add(JsonConvert.SerializeObject(obj, jsonSettings));
        }

        public static void SaveObjectsToFile(string fileName)
        {
            if (serializedObjectStrings != null)
            {
                FileStream stream = File.Create(fileName);
                StreamWriter writer = new StreamWriter(stream);
                writer.Write("{");
                int count = 0;
                foreach (string obj in serializedObjectStrings)
                {
                    writer.Write("\"{0}\":",count++);
                    writer.Write(obj);
                    if (count < serializedObjectStrings.Count)
                    writer.Write(",");
                    writer.Flush();
                }
                writer.Write("}");
                writer.Close();
            }
        }
    }
}

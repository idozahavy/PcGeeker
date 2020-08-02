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
        private static List<object> _objectList;
        public static List<object> ObjectsList
        {
            get
            {
                if (_objectList == null)
                {
                    _objectList = new List<object>();
                }
                return _objectList;
            }
        }

        private static JsonSerializerSettings _jsonSerSettings;
        private static JsonSerializerSettings JsonSerSettings
        {
            get
            {
                if (_jsonSerSettings == null)
                {
                    _jsonSerSettings = new JsonSerializerSettings()
                    {
                        MaxDepth = null,
                        Formatting = Formatting.None,
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    };
                }
                return _jsonSerSettings;
            }
        }

        public static void AddObject(object obj)
        {
            ObjectsList.Add(obj);
        }

        public static void ClearObjects()
        {
            ObjectsList.Clear();
        }

        public static void SaveObjectsToFile(string fileNamePrefix, string fileNameSuffix)
        {
            int count = 0;
            foreach (object obj in ObjectsList)
            {
                SaveObjectToFile(obj, fileNamePrefix + (count++).ToString() + fileNameSuffix, ".json");
            }
        }

        public static void SaveObjectsToFileType()
        {
            SaveObjectsToFileType("");
        }

        public static void SaveObjectsToFileType(string path)
        {
            if (!path.EndsWith("\\") && !path.EndsWith("/"))
            {
                path += "\\";
            }
            Directory.CreateDirectory(path);
            foreach (object obj in ObjectsList)
            {
                SaveObjectToFile(obj, path+obj.GetType().ToString(), ".json");
            }
        }

        public static void SaveObjectToFile(object obj, string fileName, string extension)
        {
            if (!extension.StartsWith("."))
            {
                extension = "." + extension;
            }
            string objSer = JsonConvert.SerializeObject(obj, JsonSerSettings);
            int count = 0;
            FileStream stream;
            if (File.Exists(fileName + extension))
            {
                while (File.Exists(fileName + (++count) + extension)) ;
                stream = File.Create(fileName + count + extension);
            }
            else
            {
                stream = File.Create(fileName + extension);
            }
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(objSer);
            writer.Close();
        }

        public static ObjectType LoadObjectFromFile<ObjectType>(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.Open);
            StreamReader streamReader = new StreamReader(stream);
            string fileString = "";
            while (!streamReader.EndOfStream)
            {
                fileString += streamReader.ReadLine();
            }
            streamReader.Close();
            return JsonConvert.DeserializeObject<ObjectType>(fileString, JsonSerSettings);
        }
    }
}

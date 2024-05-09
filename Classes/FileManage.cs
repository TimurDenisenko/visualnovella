using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace visualnovella.Classes
{
    public static class FileManage
    {
        private static readonly string path = Environment.CurrentDirectory.Replace("bin\\Debug", "Saves");
        public static string[] GetFilesFromFolder()
        {
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] Files = d.GetFiles();
            foreach (FileInfo item in Files)
            {
                string a = item.Name;
            }
            return Files.Select(x => x.Name).ToArray();
        }
        public static void SerializeToFile<T>(T obj, string name)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(path+"\\"+name, json);
        }
        public static T DeserializeFromFile<T>()
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}

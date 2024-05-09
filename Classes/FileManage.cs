using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace visualnovella.Classes
{
    public static class FileManage
    {
        public static readonly string path = Environment.CurrentDirectory.Replace("bin\\Debug", "Saves");
        public static string[] GetFilesFromFolder(string specificPath = null)
        {
            DirectoryInfo d = new DirectoryInfo(specificPath ?? path);
            FileInfo[] Files = d.GetFiles();
            foreach (FileInfo item in Files)
            {
                string a = item.Name;
            }
            return Files.Select(x => x.Name).ToArray();
        }
        public static void ClearFiles(string num)
        {
            foreach (string item in GetFilesFromFolder(path+"\\"+num))
            {
                File.Delete(path + "\\" + num+"\\"+item);
            }
        }
        public static void SerializeToFile<T>(T obj, string name)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(path+"\\"+name, json);
        }
        public static T DeserializeFromFile<T>(string num)
        {
            string[] file = GetFilesFromFolder(path + "\\" + num);
            string json = File.ReadAllText(path + "\\" + num+"\\"+file[0]);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}

﻿using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace visualnovella.Classes
{
    public static class FileManage
    {
        public static readonly string pathForScenario = Environment.CurrentDirectory.Replace("bin\\Debug", "Resources/scenario.txt");
        public static readonly string pathForSave = Environment.CurrentDirectory.Replace("bin\\Debug", "Saves");
        public static string[] GetFilesFromFolder(string specificPath = null)
        {
            DirectoryInfo d = new DirectoryInfo(specificPath ?? pathForSave);
            FileInfo[] Files = d.GetFiles();
            foreach (FileInfo item in Files)
            {
                string a = item.Name;
            }
            return Files.Select(x => x.Name).ToArray();
        }
        public static void ClearFiles(string num)
        {
            foreach (string item in GetFilesFromFolder(pathForSave+"\\"+num))
            {
                File.Delete(pathForSave + "\\" + num+"\\"+item);
            }
        }
        public static void SerializeToFile<T>(T obj, string name)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(pathForSave+"\\"+name, json);
        }
        public static T DeserializeFromFile<T>(string num)
        {
            string[] file = GetFilesFromFolder(pathForSave + "\\" + num);
            if (file.Length == 0) return default;
            string json = File.ReadAllText(pathForSave + "\\" + num+"\\"+file[0]);
            return JsonConvert.DeserializeObject<T>(json);
        }
        public static string[] ReadFromFile()
        { 
            string[] scenario = File.ReadAllLines(pathForScenario);
            return scenario;
        }
    }
}

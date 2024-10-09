using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CLI_NTUA_2024;

public static class Utilities
{
    private static string _savePath = "";
    public static string SavePath
    {
        get
        {
            return ComputeSavePath();
        }
    }
    private static string ComputeSavePath()
    {
        if (string.IsNullOrWhiteSpace(_savePath))
        {
            _savePath =
                Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.UserProfile),
                "AppData", "LocalLow", "CLI_NTUA_2024.Data");
            
            if (!Directory.Exists(_savePath))
                Directory.CreateDirectory(_savePath);
        }

        return _savePath;
    }
    public static bool SaveDataToJson(string fileName, object data, bool overwriteIfExists = true)
    {
        bool result = false;

        if (string.IsNullOrWhiteSpace(fileName))
            return result;

        string filePath = Path.Combine(SavePath, fileName);

        if (!overwriteIfExists && File.Exists(filePath))
            return false;

        string json = JsonConvert.SerializeObject(data
#if DEBUG
            ,Formatting.Indented);
#else
            );
#endif


        using StreamWriter writer = new StreamWriter(filePath);
        writer.Write(json);

        return true;
    }
    public static bool LoadDataFromJson<T>(string fileName, out T data)
    {
        data = default(T);
        if(string.IsNullOrWhiteSpace(fileName))
            return false;

        string filePath = Path.Combine(SavePath, fileName);
        if (!File.Exists(filePath))
            return false;

        using StreamReader reader = new StreamReader(filePath);
        string json = reader.ReadToEnd();
        data = JsonConvert.DeserializeObject<T>(json);

        return true;
    }
}

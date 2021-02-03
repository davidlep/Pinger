using System;
using System.IO;
using System.Text.Json;

namespace Pinger
{
    public class Settings
    {
        public static readonly string FileName = Environment.CurrentDirectory + @"\settings.json";

        public string host { get; set; } = "www.google.ca";
        public int frequencyInSec { get; set; } = 3;

        public static Settings Read()
        {
            return JsonSerializer.Deserialize<Settings>(File.ReadAllText(FileName));
        }

        public static void Write(Settings settings)
        {
            File.WriteAllText(FileName, JsonSerializer.Serialize(settings));
        }

        public static void Init()
        {
            if (File.Exists(FileName))
                return;

            Write(new Settings());
        }
    }
}
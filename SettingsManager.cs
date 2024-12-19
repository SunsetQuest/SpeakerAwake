using System.IO;
using System.Text.Json;
//using System.Text.Json;



namespace SpeakerAwake
{
    public class Settings
    {
        public int FrequencyHz { get; set; } = 20;
        public float VolumePercent { get; set; } = 0.02f; // Default 2%
    }

    public class SettingsManager
    {
        private const string FileName = "settings.json";

        public Settings Load()
        {
            if (!File.Exists(FileName))
            {
                return new Settings();
            }

            string json = File.ReadAllText(FileName);
            return JsonSerializer.Deserialize<Settings>(json) ?? new Settings();
        }

        public void Save(int frequency, float volume)
        {
            Settings s = new()
            {
                FrequencyHz = frequency,
                VolumePercent = volume
            };
            string json = JsonSerializer.Serialize(s, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FileName, json);
        }
    }
}

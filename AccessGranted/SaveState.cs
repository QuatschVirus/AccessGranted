using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AccessGranted
{
    internal enum Language
    {
        CSharp,
        // Python, // TODO: Implement later
    }

    internal class SaveState
    {
        private const string path = "AccessGrantedSave.bin";
        private static string CorruptedPath => path + ".corrupted";

        public static SaveState Load()
        {
            if (File.Exists(path))
            {
                SaveState? save = JsonSerializer.Deserialize<SaveState>(File.ReadAllText(path));
                if (save == null)
                {
                    Console.Error.WriteLine("Could not load save file. The file will be renamed to " + CorruptedPath);
                    File.Copy(path, CorruptedPath, true);
                    File.Delete(path);
                    return new SaveState();
                }
                return save;
            } else
            {
                return new SaveState();
            }
        }

        public static bool Exists()
        {
            return File.Exists(path);
        }

        public void Save()
        {
            File.WriteAllText(path, JsonSerializer.Serialize(this));
        }

        public int StoryProgression { get; set; } = 0;
        public Language? Language { get; set; } = null;

        public bool HasDatabase => StoryProgression >= 3;
    }
}

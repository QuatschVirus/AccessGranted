using AccessGranted.Languages;

namespace AccessGranted
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Access Granted! Loading save state...");
            SaveState save = SaveState.Load();
            Console.WriteLine("Save state loaded, beginning game");
            Console.Clear();

            if (save.StoryProgression == 0)
            {
                Console.WriteLine("Welcome in the Access Granted Program, agent! First of: Congrats on getting hired.\n" +
                    "As it said in the job description; You'll be programming the checking machines at the border crossings, so we can make the job a lot safer and less boring for the on-location agents.\n" +
                    $"You don't need to compile anything, the system will do it for you; Just put the code files in {Path.GetFullPath(IUserProgram.programPath)}\n");
                save.StoryProgression++;
            }

            #region Language Setting
            string[] langs = Enum.GetNames<Language>();
            while (save.Language == null)
            {
                Console.WriteLine();
                Console.WriteLine("What language would you like to use? (You can change this later) (Enter exit to close the program)");

                for (int i = 0; i < langs.Length; i++)
                {
                    Console.WriteLine($"\t{i + 1}: {langs[i]}");
                }
                string? r = Console.ReadLine();
                if (int.TryParse(r, out int s))
                {
                    if (s < 1 || s > langs.Length) { Console.WriteLine("That is not a valid option"); }
                    else
                    {
                        save.Language = (Language)s;
                        Console.WriteLine("Selected: " + save.Language);
                    }

                }
                else if (r?.Equals("exit", StringComparison.OrdinalIgnoreCase) ?? false)
                {
                    save.Save();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("That didn't work. Please try again");
                }
            }
            save.Save();
            #endregion
        }
    }
}

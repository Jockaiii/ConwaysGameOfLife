using System;

namespace ConwaysGameOfLife
{
    internal static class Output
    {
        /// <summary>
        /// Metod som sköter utskrift av startinstruktioner till användaren.
        /// </summary>
        public static void OutputStart()
        {
            Console.WriteLine("Welcome to the Game Of Life \nPlease choose a save or start a new randomised game.");
            Console.WriteLine("Press 1 to start a new game \nPress 2 for saved games \nPress 3 for presets");
        }

        /// <summary>
        /// Metod som sköter utrskrift av AgarPlate[,] till användaren.
        /// </summary>
        /// <param name="agarPlates">Den nuvarande instansen av AgarPlates.cs</param>
        public static void OutputAgarPlate(Models.AgarPlates agarPlates)
        {
            for (int i = 0; i < agarPlates.AgarPlateHeight; i++)
            {
                for (int j = 0; j < agarPlates.AgarPlateWidth; j++)
                {
                    Console.Write(Cell.AliveIcons[Models.AgarPlates.AgarPlate[i, j].Alive]);
                }
                Console.Write("\n");
            }
            Console.WriteLine("Press any key to continue");
            Controllers.ViewController.ReadLine();
        }

        /// <summary>
        /// Metod som sköter utskrift av sparade .json filer (AgarPlates) till användaren.
        /// </summary>
        /// <param name="SavedAgarPlates">Är en string[] som innehåller .json filernas namn och paths</param>
        public static void OutputSavedAgarPlates(string[] SavedAgarPlates)
        {
            for (int i = 0; i < SavedAgarPlates.Length; i++)
                Console.WriteLine($"{i+1}: {SavedAgarPlates[i]}");
        }

        /// <summary>
        /// Metod som sköter utskrift av fråga angånde ifall användaren vill spara den nuvarande AgarPlate[,](en) eller inte.
        /// </summary>
        public static void OutputSave()
        {
             Console.WriteLine("Do you want to save the current AgarPlate? (y/n)");
        }

        /// <summary>
        /// Metod som skriver ut val av presets/mallar för användaren.
        /// </summary>
        /// <param name="agarPlatePresets">Är en string[] som innehåller de sparade presetsen namn och path</param>
        public static void OutputPresets(string[] agarPlatePresets)
        {
            for (int i = 0; i < agarPlatePresets.Length; i++)
                Console.WriteLine($"{i+1}: {agarPlatePresets[i]}");
        }

        /// <summary>
        /// Metod som skriver ut till användaren att det inte finns några sparade AgarPlates[,].
        /// </summary>
        public static void OutputNoSavedAgarPlates()
        {
            Console.WriteLine("No saved AgarPlates");
        }
    }
}
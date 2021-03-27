using System;

namespace ConwaysGameOfLife.Controllers
{
    internal static class ViewController
    {
        /// <summary>
        /// Metod som skriver ut startinstruktioner till användaren och tar sedan emot och felhanterar input från användaren. Tillkallar sedan
        /// lämpliga metoder beroende på användarens val.
        /// </summary>
        /// <param name="game">Den nuvarande instansen av Game.cs</param>
        /// <param name="agarPlates">Den nuvarande instansens ag AgarPlates.cs</param>
        public static void StartInput(Game game, Models.AgarPlates agarPlates)
        {
            string input;
            do
            {
                Output.OutputStart();
                input = Console.ReadLine();
            } while (input.Length != 1 && int.TryParse(input, out int result) && result !> 0 && result !< 4);

            if (int.Parse(input) == 1)
            {
                Helpers.Seeder.AgarPlateSeeder(agarPlates);
                Output.OutputAgarPlate(agarPlates);
                game.CheckVitalState(agarPlates);
            }
            else if (int.Parse(input) == 2)
            {
                Helpers.GameHelper.AgarPlateLoader();
                Output.OutputAgarPlate(agarPlates);
                game.CheckVitalState(agarPlates);
            }
            else
            {
                Helpers.GameHelper.AgarPlatePresetsLoader(agarPlates);
                Output.OutputAgarPlate(agarPlates);
                game.CheckVitalState(agarPlates);
            }
        }

        /// <summary>
        /// Tillkallar metod som skriver ut sparade AgarPlate[,] till användaren och tar sedan emot och felhanterar input från användaren.
        /// </summary>
        /// <param name="SavedAgarPlates">Är en string[] som innehåller sparade .json filer (AgarPlate[,]s) och deras path.</param>
        /// <returns>returnerar användarens input</returns>
        public static int OutputSavedAgarPlatesController(string []SavedAgarPlates)
        {
            string input;
            do
            {
                Output.OutputSavedAgarPlates(SavedAgarPlates);
                input = Console.ReadLine();
            } while (!int.TryParse(input, out int result) && result !> 0 && result !<= SavedAgarPlates.Length);
            return int.Parse(input);
        }

        /// <summary>
        /// Tillkallar metod som frågar användaren  om hen vill spara AgarPlate[,](n) och tar sedan emot och felhanterar input från användaren.
        /// tillkallar därefter metod som sparar den nuvarande AgarPlate[,] beroende på användarens val.
        /// </summary>
        public static void OutputSaveController()
        {
            string input;
            do
            {
                Output.OutputSave();
                input = Console.ReadLine().ToLower();
            } while ((input.Length != 1 && (input == "y" || input == "n")) || input is null);

            if (input == "y")
                Helpers.GameHelper.AgarPlateSaver();
        }

        /// <summary>
        /// Metod som skriver ut Console.ReadKey() för att vänta med att skriva ut nästa generation tills att användaren väljer det.
        /// </summary>
        public static void ReadLine()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// Metod som tillkallar metod för tillgängliga presets samt tar emot och felhanterar input från användaren.
        /// </summary>
        /// <param name="agarPlatesPresets">en array med filnamn och path till sparade presets</param>
        /// <returns>returerar den godkända inputen från användaren</returns>
        public static int OutputPresetsController(string[] agarPlatesPresets)
        {
            string input;
            do
            {
                Output.OutputPresets(agarPlatesPresets);
                input = Console.ReadLine();
            } while (!int.TryParse(input, out int result) && result! > 0 && result! <= agarPlatesPresets.Length);
            return int.Parse(input);
        }
    }
}
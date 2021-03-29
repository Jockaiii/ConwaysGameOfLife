using System;
using System.IO;
using Newtonsoft.Json;

namespace ConwaysGameOfLife.Helpers
{
    public static class GameHelper
    {
        /// <summary>
        /// Metod som serialiserar nuvarande AgarPlate[,] så att den kan sparas i .json format. Metoden sköter även indexering av filnamn genom DateTime samt.
        /// formatering av .json filen. Slutligen skapar metoden en .json fil och skriver över data från AgarPlate[,] till .json filen.
        /// </summary>
        public static void AgarPlateSaver()
        {
            Directory.CreateDirectory("Saves"); // Skapar Directory om den inte redan finns
            var time = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"); // Sparar den nuvarande tiden på enheten för att sedan användas som filnamn.
            string jsonString = JsonConvert.SerializeObject(Models.AgarPlates.AgarPlate);
            File.AppendAllText(@"Saves\" + time + ".json", jsonString);
        }

        /// <summary>
        /// Metod som hämtar alla sparade .json filers filnamn (+ path) och tillkallar metod för att-
        /// ta emot och felhantera användar input. för att slutligen deserialisera .json filen och kopiera datan till den nuvarande AgarPlate[,]n.
        /// </summary>
        public static void AgarPlateLoader()
        {
            Directory.CreateDirectory("Saves"); // Skapar Directory om den inte redan finns
            string[] savedAgarPlates = Directory.GetFiles(@"Saves\"); // Läser in alla sparade json filer och lägger dom stängar i en array.

            if (savedAgarPlates.Length == 0 || savedAgarPlates is null)  // Om det inte finns några sparade games.
                Output.OutputNoSavedAgarPlates();
            else
            {
                int input = Controllers.ViewController.OutputSavedAgarPlatesController(savedAgarPlates); // Tillkallar metod som skriver ut de sparade filerna och tillkallar metod som tar emot input av användaren
                string jsonString = File.ReadAllText(savedAgarPlates[input-1]); // Läser in den valda filen till en sträng för att deseriliseras.
                Models.AgarPlates.AgarPlate =  JsonConvert.DeserializeObject<Cell[,]>(jsonString); // Deseriliaserar .json filen och Sätter AgarPlate i Game.cs till den sparade AgarPlaten.
            }
        }

        /// <summary>
        /// Metod som används för att ladda in skapade presets till spelet samt tolka filen till data för AgarPlate[,].
        /// </summary>
        /// <param name="agarPlate">instans av AgarPlate.cs</param>
        public static void AgarPlatePresetsLoader(Models.AgarPlates agarPlate)
        {
            Directory.CreateDirectory("Presets"); // Skapar Directory om den inte redan finns
            string[] agarPlatePresets = Directory.GetFiles(@"Presets\");

            if (agarPlatePresets.Length == 1 || agarPlatePresets is null) // om det inte finns några sparade presets.
                Output.OutputNoSavedAgarPlates();
            else
            {
                int input = Controllers.ViewController.OutputPresetsController(agarPlatePresets);
                string[] cellRows = File.ReadAllLines(agarPlatePresets[input-1]);

                for (int i = 0; i < agarPlate.AgarPlateHeight; i++)
                {
                    string[] cells = cellRows[i].Split(" ");
                    for (int j = 0; j < agarPlate.AgarPlateWidth; j++)
                    {
                        if (cells[j] == "1")
                            Models.AgarPlates.AgarPlate[i, j] = new Cell { Alive = true };
                        else
                            Models.AgarPlates.AgarPlate[i, j] = new Cell { Alive = false };
                    }
                }
            }
        }

        /// <summary>
        /// Metod som används för att göra en tom mall att "måla" in egna mönster i AgarPlate[,].
        /// </summary>
        /// <param name="agarPlates">instans av AgarPlates.cs</param>
        public static void AgarPlatePresetMaker(Models.AgarPlates agarPlates)
        {
            foreach (var cell in Models.AgarPlates.AgarPlate) // sätter alla celler till döda så att det blir lättare att "måla" i filen senare.
                cell.Alive = false;

            using var sw = new StreamWriter(@"Presets\EmptyPreset.txt");
            for (int i = 0; i < agarPlates.AgarPlateHeight; i++)
            {
                for (int j = 0; j < agarPlates.AgarPlateWidth; j++)
                    sw.Write(Cell.AliveIcons[Models.AgarPlates.AgarPlate[i, j].Alive] + " ");
                sw.Write("\n");
            }

            sw.Flush();
            sw.Close();
        }
    }
}
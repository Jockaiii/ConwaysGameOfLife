using System;

namespace ConwaysGameOfLife
{
    public class Game : Interfaces.IGame
    {
        public static bool GameContinue { get; set;  } // Bool som bestämmer ifall Agarplaten ska köra en till generation eller inte.
        public static bool IsTesting { get; set; } = false; // bool som bestämmer om det är ett test som körs eller inte.
        public virtual int CheckRadius { get; } = 1; // Property som bestämmer hur stort område ska räknas som grannar till en cell.
        public virtual int NeighbourMax { get; } = 3; // Property som bestämmer hur många grannar en cell max få ha innan den dör.
        public virtual int NeighbourMin { get; } = 2; // Property som bestämmer hur få grannar en cell minst få ha innan den dör.
        public virtual int CellNeighbourResurrectMax { get; } = 4; // Property som bestämmer minimum av en döds cells levande grannar som krävs för att cellen ska återupplevas.
        public virtual int CellNeighbourResurrectMin { get; } = 2; // Property som bestämmer maximum av en döds cells levande grannar som krävs för att cellen ska återupplevas.

        /// <summary>
        /// Metod som kollar varje cell i AgarPlate[,]. Räknar cellens "grannar" och beroende på cellens propertys så ändras cellens properties efter spelreglerna
        /// Tillkallar därefter en metod för utskrift av AgarPlate[,] till konsolen.
        /// Metoden ser sedan till att Kolla ifall AgarPlate[,] har några levande celler kvar och ändrar GameContinue därefter.
        /// </summary>
        /// <param name="agarPlates">Den nuvarande instansen av AgarPlates.cs</param>
        public virtual void CheckVitalState(Models.AgarPlates agarPlates)
        {
            GameContinue = false; // sätter till false som default och ändras till true om någon cell == Alive i AgarPlate[,].
            Cell[,] NextGeneration = new Cell[agarPlates.AgarPlateHeight, agarPlates.AgarPlateWidth]; // Gör en till tom 2d array som jag sedan kan uppdatera
                                                                                                     // properties på utan att ändra den nuvarande spelplanen                                                                                                          
            for (int i = 0; i < agarPlates.AgarPlateHeight; i++) // Kollar varje cell i Agarplate.
            {
                for (int j = 0; j < agarPlates.AgarPlateWidth; j++)
                {
                    Models.AgarPlates.AgarPlate[i, j].Neighbours = 0; // Återställer nuvarande cellens neighbours till 0. (för utträkning).

                    for (int k = i - CheckRadius; k <= i + CheckRadius; k++) // Kollar varje cell runt den nuvarande cellen.
                    {
                        for (int l = j - CheckRadius; l <= j + CheckRadius; l++)
                        {
                            if (k < 0 || k > agarPlates.AgarPlateHeight - 1|| l < 0 || l > agarPlates.AgarPlateWidth - 1|| (k == i && l == j)) // Hoppar över kordinaten ifall den faller utan för index eller om den är på sig själv.
                                continue;
                            else if (Models.AgarPlates.AgarPlate[k, l].Alive) // Ökar Neighbours om en granne lever.
                                Models.AgarPlates.AgarPlate[i, j].Neighbours++;
                        }
                    }

                    if (Models.AgarPlates.AgarPlate[i, j].Alive && Models.AgarPlates.AgarPlate[i, j].Neighbours < NeighbourMin) // Cellen dör om den har färre än 2 grannar.
                        NextGeneration[i, j] = new Cell(false);
                    else if (Models.AgarPlates.AgarPlate[i, j].Alive && Models.AgarPlates.AgarPlate[i, j].Neighbours > NeighbourMax) // Cellen dör om den har fler än 3 grannar.
                        NextGeneration[i, j] = new Cell(false);
                    else if (!Models.AgarPlates.AgarPlate[i, j].Alive && Models.AgarPlates.AgarPlate[i, j].Neighbours > CellNeighbourResurrectMin && Models.AgarPlates.AgarPlate[i, j].Neighbours < CellNeighbourResurrectMax) // Varje död cell med exakt 3 levande celler runt sig blir levande.
                        NextGeneration[i, j] = new Cell(true);
                    else
                        NextGeneration[i, j] = new Cell(Models.AgarPlates.AgarPlate[i, j].Alive);
                }
            }

            if (!IsTesting) // Innan AgarPlaten uppdateras.
                Controllers.ViewController.OutputSaveController(); // Tillkallar metod som ber användaren om input om hen vill spara AgarPlaten eller inte.

            Models.AgarPlates.AgarPlate = NextGeneration; // Uppdaterar AgarPlate innan utskrivning.
            if (!IsTesting)
            {
                Output.OutputAgarPlate(agarPlates); // Skriver ut AgarPlate[,] till konsolen.
                foreach (var cell in Models.AgarPlates.AgarPlate)
                    if (cell.Alive) // Om någon cell i AgarPlate är levande så körs en till generation.
                        CheckVitalState(agarPlates);
            }
        }
    }
}
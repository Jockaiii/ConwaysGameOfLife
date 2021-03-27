namespace ConwaysGameOfLife
{
    internal static class Program
    {
        private static void Main()
        {
            Game game = new Game();
            Models.AgarPlates agarPlates = new Models.AgarPlates();
            Models.AgarPlates.AgarPlate = new Cell[agarPlates.AgarPlateHeight, agarPlates.AgarPlateWidth];
            Controllers.ViewController.StartInput(game, agarPlates);
        }
    }
}
// TODO:
// Lägg till CellPosition property till Cell.cs Så att man inte behöver skriva ut hela arrayen varje gång utan endast de cellerna som har uppdateras.
// Lägg till CellAge property för att kunna visualisera/arbeta med celler som överlever under flera rundor.
namespace ConwaysGameOfLife.Interfaces
{
    internal interface IAgarPlates
    {
        int AgarPlateHeight { get; }
        int AgarPlateWidth { get; }
        public static Cell[,] AgarPlate { get; set; }
    }
}
namespace ConwaysGameOfLife.Models
{
    public class AgarPlates : Interfaces.IAgarPlates
    {
        public virtual int AgarPlateHeight { get; } = 10; // Bestämmer höjden (antal rader) på AgarPlate[,].
        public virtual int AgarPlateWidth { get; } = 10; // Bestämmer bredden (antal kolumner) på AgarPlate[,].
        public static Cell[,] AgarPlate { get; set; } = new Cell[10, 10]; // En 2d Array av typen Cell. Som används som Spelkarta samt lagarar Celler för spelet.
    }
}
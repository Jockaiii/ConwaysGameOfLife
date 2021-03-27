namespace ConwaysGameOfLife.Interfaces
{
    internal interface ICell
    {
        bool Alive { get; set; }
        int Neighbours { get; set; }
        public static string AliveIcon { get; set; } = "1";
        public static string DeadIcon { get; set; } = "0";
    }
}
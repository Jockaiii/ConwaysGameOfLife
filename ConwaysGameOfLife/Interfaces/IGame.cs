namespace ConwaysGameOfLife.Interfaces
{
    internal interface IGame
    {
        static bool GameContinue { get; set;  }
        static bool IsTesting { get; set; }
        int CheckRadius { get; }
        int NeighbourMax { get; }
        int NeighbourMin { get; }
        int CellNeighbourResurrectMax { get; }
        int CellNeighbourResurrectMin { get; }
        static void CheckVitalState() {}
    }
}
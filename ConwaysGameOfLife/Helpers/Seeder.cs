namespace ConwaysGameOfLife.Helpers
{
    public static class Seeder
    {
        /// <summary>
        /// Metod som ser till att köra constructor för varje element i AgarPlate[,].
        /// </summary>
        public static void AgarPlateSeeder(Models.AgarPlates agarPlates)
        {
            for (int i = 0; i < agarPlates.AgarPlateHeight; i++)
            {
                for (int j = 0; j < agarPlates.AgarPlateWidth; j++)
                {
                    Models.AgarPlates.AgarPlate[i, j] = new Cell();
                }
            }
        }
    }
}
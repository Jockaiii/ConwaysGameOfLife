using NUnit.Framework;
using System.IO;
using Newtonsoft.Json;

namespace ConwaysGameOfLife.Helpers.Tests
{
    [TestFixture()]
    public class GameHelperTests
    {
        [Test()]
        public void AgarPlateSaverTest()
        {
            Game game = new Game();
            Models.AgarPlates agarPlates = new Models.AgarPlates();

            Seeder.AgarPlateSeeder(agarPlates);
            Cell[,] testAgarPlate = new Cell[agarPlates.AgarPlateHeight, agarPlates.AgarPlateWidth];

            foreach (var item in Models.AgarPlates.AgarPlate) // Sätter alla cellers neigbours till 0 för att slippa massa onödig extra kod. 
                item.Neighbours = 0;                           // Eftersom det är 100 celler så är sannoligheten att en slumpad array skulle vara lika med
            for (int i = 0; i < agarPlates.AgarPlateHeight; i++) // den sparade arrayen väldigt låg. Och för att vara säker kan man köra testet flera gånger.
                for (int j = 0; j < agarPlates.AgarPlateWidth; j++)
                {
                    if (Models.AgarPlates.AgarPlate[i, j].Alive)
                        testAgarPlate[i, j] = new Cell(true);
                    else
                        testAgarPlate[i, j] = new Cell(false);
                }

            GameHelper.AgarPlateSaver(); // Sparar AgarPlate[,].

            string[] savedAgarPlates = Directory.GetFiles(@"..\..\..\..\ConwaysGameOfLifeTests\bin\Debug\netcoreapp3.1\Saves\"); // AgarPlate sparad version.
            string jsonString = File.ReadAllText(savedAgarPlates[^1]);
            Models.AgarPlates.AgarPlate = JsonConvert.DeserializeObject<Cell[,]>(jsonString);

            Assert.IsTrue(ArrayChecker(agarPlates, testAgarPlate));
        }

        public bool ArrayChecker(Models.AgarPlates agarPlates, Cell[,] testAgarPlate)
        {
            for (int i = 0; i < agarPlates.AgarPlateHeight; i++) // Loopar igenom varje varje element i arrayerna och returnerar false om inte alla element är lika. Annars true
                for (int j = 0; j < agarPlates.AgarPlateWidth; j++)
                    if (testAgarPlate[i, j].Alive != Models.AgarPlates.AgarPlate[i, j].Alive)
                        return false;
            return true;
        }
    }
}
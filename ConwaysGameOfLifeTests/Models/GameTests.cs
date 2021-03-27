using NUnit.Framework;
using ConwaysGameOfLife;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConwaysGameOfLife.Tests
{
    [TestFixture()]
    public class GameTests
    {
        [Test()]
        public void CheckVitalStateMinimumNeighboursTest() // Kollar så att celler med mindre än 2 grannar dör (och med 2 grannar överlever).
        {
            Game game = new Game();
            Models.AgarPlates agarPlates = new Models.AgarPlates();
            Game.IsTesting = true;

            Helpers.Seeder.AgarPlateSeeder(agarPlates);
            foreach (var cell in Models.AgarPlates.AgarPlate) // Dödar alla celler i arrayen.
                cell.Alive = false;

            Models.AgarPlates.AgarPlate[0, 0].Alive = true; // Borde dö :(
            Models.AgarPlates.AgarPlate[0, 1].Alive = true; // Borde Överleva :)
            Models.AgarPlates.AgarPlate[0, 2].Alive = true; // Borde dö :(

            game.CheckVitalState(agarPlates);

            Assert.IsFalse(Models.AgarPlates.AgarPlate[0, 0].Alive); // En cell färre än 2 grannar borde dö
            Assert.IsTrue(Models.AgarPlates.AgarPlate[0, 1].Alive); // En cell med 2 grannar borde överleva.
            Assert.IsFalse(Models.AgarPlates.AgarPlate[0, 2].Alive); // En cell färre än 2 grannar borde dö
        }

        [Test()]
        public void CheckVitalStateMaximumNeighboursTest() // Testar om celler med mer än 3 grannar dör (och med 3 grannar överlever) 
        {
            Game game = new Game();
            Models.AgarPlates agarPlates = new Models.AgarPlates();
            Game.IsTesting = true;

            Helpers.Seeder.AgarPlateSeeder(agarPlates);
            foreach (var cell in Models.AgarPlates.AgarPlate) // Dödar alla celler i arrayen.
                cell.Alive = false;

            Models.AgarPlates.AgarPlate[0, 0].Alive = true; // Borde Överleva (3 grannar):)
            Models.AgarPlates.AgarPlate[0, 1].Alive = true; // Borde Överleva (3 grannar):)
            Models.AgarPlates.AgarPlate[1, 0].Alive = true; // Har 4 grannar borde dö. :(
            Models.AgarPlates.AgarPlate[1, 1].Alive = true; // Har 4 grannar borde dö. :(
            Models.AgarPlates.AgarPlate[2, 0].Alive = true; // Borde Överleva :)

            game.CheckVitalState(agarPlates);

            Assert.IsTrue(Models.AgarPlates.AgarPlate[0, 0].Alive);
            Assert.IsFalse(Models.AgarPlates.AgarPlate[1, 0].Alive); // En cell med fler än 3 grannar borde dö
        }

        [Test()]
        public void CheckVitalStateResurrectionTest() // Testar så att döda celler med 3 levande grannar återupplevas
        {
            Game game = new Game();
            Models.AgarPlates agarPlates = new Models.AgarPlates();
            Game.IsTesting = true;

            Helpers.Seeder.AgarPlateSeeder(agarPlates);
            foreach (var cell in Models.AgarPlates.AgarPlate) // Dödar alla celler i arrayen.
                cell.Alive = false;

            Models.AgarPlates.AgarPlate[0, 0].Alive = true; // Borde dö :(
            Models.AgarPlates.AgarPlate[0, 1].Alive = true; // Borde Överleva :)
            Models.AgarPlates.AgarPlate[0, 2].Alive = true;

            game.CheckVitalState(agarPlates);

            Assert.IsTrue(Models.AgarPlates.AgarPlate[1, 1].Alive); // En död cell med 3 levande grannar borde återupplevas
        }
    }
}
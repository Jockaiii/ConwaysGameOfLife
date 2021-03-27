using System;
using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class Cell : Interfaces.ICell
    {
        public Random rnd = new Random();
        public virtual bool Alive { get; set; } // Är en book som bestämmer ifall cellen är levande eller inte. Används även som nyckel till AliveIcon Dictionaryn.
        public virtual int Neighbours { get; set; }  // Är en cells antal "grannar".
        public virtual string AliveIcon { get; set; } = "1"; // är en string som används för att visulisera att en cell lever för användaren.
        public virtual string DeadIcon { get; set; } = "0"; // är en string som används för att visulisera att en cell är död för användaren.

        /// <summary>
        /// Tilldelar värden till varje Cells properties.
        /// </summary>
        public Cell()
        {
            Alive = rnd.Next(0, 3) == 0; // 33% att varje cell blir levande. :) Najs!
            Neighbours = 0;
        }

        /// <summary>
        /// Overloaded constuctor som tillkallas när jag lägger till en ny Cell i kopian av AgarPlate[,] (egentligen varje gång man tillkallar Cell.cs med en bool parameter)
        /// </summary>
        /// <param name="copiedState">Är Alive värdet på elementet i AgarPlate, som skall föras över till kopian.</param>
        public Cell(bool copiedState)
        {
            Alive = copiedState;
            Neighbours = 0;
        }

        internal static readonly Dictionary<bool, string> AliveIcons = new Dictionary<bool, string>() // Tar emot bool för att visualisera cellers levanadsstatus
        {                                                                                             // till användaren
            { true , "1" }, // Byt till AliveIcon
            { false, "0" } // Byt till DeadIcon
        };
    }
}
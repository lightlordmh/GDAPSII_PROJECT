using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace The_Attempt
{
    // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating
    // Handles the Monster game object and AI
    // This class will be implemented in the future
    public class Monster:GameObject
    {
        // attributes
        private int creepSpeed; // the speed at which the monster moves while not in pursuit mode
        private int rushSpeed; // the speed at which the monster moves while in pursuit mode

        // properties
        public int CreepSpeed
        {
            get { return creepSpeed; }
            set { creepSpeed = value; }
        }
        public int RushSpeed
        {
            get { return rushSpeed; }
            set { rushSpeed = value; }
        }

        /// <summary>
        /// Constructs a Monster object and places it in a Rectangle defined by the parameters that are passed in.
        /// </summary>
        /// <param name="xPos">The X coordinate of the top left point of the Rectangle.</param>
        /// <param name="yPos">The Y coordinate of the top left point of the Rectangle.</param>
        /// <param name="width">The width dimension of the Rectangle.</param>
        /// <param name="height">The height dimension of the Rectangle.</param>
        public Monster(int xPos, int yPos, int width, int height, int cSpeed, int rSpeed):base(xPos,yPos,width,height)
        {
            cSpeed = creepSpeed;
            rSpeed = rushSpeed;
        }
    }
}

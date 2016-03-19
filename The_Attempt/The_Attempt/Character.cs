using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace The_Attempt
{
    // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating
    // This Class represents the player character in the game
    public class Character:GameObject
    {
        // attributes
        private int numKeyParts; // number of pieces collected (only need 1 to win for now) to create a key

        // properties
        public int NumKeyParts
        {
            get { return numKeyParts; }
            set { numKeyParts = value; }
        }

        /// <summary>
        /// Constructs a Character object and places it in a Rectangle defined by the parameters that are passed in.
        /// </summary>
        /// <param name="xPos">The X coordinate of the top left point of the Rectangle.</param>
        /// <param name="yPos">The Y coordinate of the top left point of the Rectangle.</param>
        /// <param name="width">The width dimension of the Rectangle.</param>
        /// <param name="height">The height dimension of the Rectangle.</param>
        public Character(int xPos, int yPos, int width, int height):base(xPos,yPos,width,height)
        {
            numKeyParts = 0; // set default number of keys to zero
        }
    }
}

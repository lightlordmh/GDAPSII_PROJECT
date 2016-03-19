using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace The_Attempt
{
    // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating
    // Handles the intersection of the maze and the player's collision with them
    // This class will be implemented in the future
    public class Intersection:GameObject
    {
        // constructor
        /// <summary>
        /// Constructs an Intersection object that will represent an intersection on the map that the Character or Monster can walk on.
        /// </summary>
        /// <param name="xPos">The X coordinate of the top left point of the Rectangle.</param>
        /// <param name="yPos">The Y coordinate of the top left point of the Rectangle.</param>
        /// <param name="width">The width dimension of the Rectangle.</param>
        /// <param name="height">The height dimension of the Rectangle.</param>
        public Intersection(int xPos, int yPos, int width, int height) : base(xPos, yPos, width, height)
        {
            
        }
    }
}

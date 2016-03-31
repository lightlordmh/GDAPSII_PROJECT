using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace The_Attempt
{
    // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating
    // Handles the movement of an objects Rectangle
    public class Movement
    {
        // attributes
        private int scale; // controls the speed of the movement

        // properties
        public int Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        /// <summary>
        /// Constructs a Movement object that handles the movement of a 2D Vector.
        /// </summary>
        /// <param name="value">The amount by which the movement will be scaled in order to alter the speed.</param>
        public Movement(int value)
        {
            scale = value;
        }

        /// <summary>
        /// Does a caluculation to move the Rectangle to the left. 
        /// </summary>
        /// <param name="obj">Rectangle of the object which is being moved</param>
        /// <returns>An int which gives the new value for the Rectangle's X coordinate</returns>
        public int Left(Rectangle obj)
        {
            return obj.X + (1 * scale);
        }

        /// <summary>
        /// Does a caluculation to move the Rectangle to the right. 
        /// </summary>
        /// <param name="obj">Rectangle of the object which is being moved</param>
        /// <returns>An int which gives the new value for the Rectangle's X coordinate</returns>
        public int Right(Rectangle obj)
        {
            return obj.X - (1 * scale);
        }

        /// <summary>
        /// Does a caluculation to move the Rectangle up. 
        /// </summary>
        /// <param name="obj">Rectangle of the object which is being moved</param>
        /// <returns>An int which gives the new value for the Rectangle's Y coordinate</returns>
        public int Up(Rectangle obj)
        {
            return obj.Y + (1 * scale);
        }

        /// <summary>
        /// Does a caluculation to move the Rectangle down. 
        /// </summary>
        /// <param name="obj">Rectangle of the object which is being moved</param>
        /// <returns>An int which gives the new value for the Rectangle's Y coordinate</returns>
        public int Down(Rectangle obj)
        {
            return obj.Y - (1 * scale);
        }
    }
}

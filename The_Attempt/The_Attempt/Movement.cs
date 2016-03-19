using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace The_Attempt
{
    // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating
    // Handles the movement of a given 2D vector
    // This Class will be overhauled to use rectangles in the future for easier collision detection
    public class Movement
    {
        // attributes
        private float scale; // scales the speed by this factor
        
        // properties
        public float Scale
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
        /// Does a caluculation to move the vector2 left. 
        /// </summary>
        /// <param name="i">Input Vector2 object for left Movement calculation</param>
        /// <returns>A Vector2 with a new position based on the calculations made</returns>
        public Vector2 Left(Vector2 i)
        {
            // create a Vector2 object with a postions that moves the parameter Vector2 left
            Vector2 afterM = new Vector2(i.X - (1 * scale), i.Y);
            return afterM;
        }

        /// <summary>
        /// Does a caluculation to move the vector2 right.
        /// </summary>
        /// <param name="i">Input Vector2 object for right Movement calculation</param>
        /// <returns>A Vector2 with a new position based on the calculations made</returns>
        public Vector2 Right(Vector2 i)
        {
            // create a Vector2 object with a postions that moves the parameter Vector2 right
            Vector2 afterM = new Vector2(i.X + (1 * scale), i.Y);
            return afterM;
        }

        /// <summary>
        /// Does a caluculation to move the vector2 up.
        /// </summary>
        /// <param name="i">Input Vector2 object for up Movement calculation</param>
        /// <returns>A Vector2 with a new position based on the calculations made</returns>
        public Vector2 Up(Vector2 i)
        {
            // create a Vector2 object with a postions that moves the parameter Vector2 up
            Vector2 afterM = new Vector2(i.X, i.Y - (1 * scale));
            return afterM;
        }

        /// <summary>
        /// Does a caluculation to move the vector2 down.
        /// </summary>
        /// <param name="i">Input Vector2 object for down Movement calculation</param>
        /// <returns>A Vector2 with a new position based on the calculations made</returns>
        public Vector2 Down(Vector2 i)
        {
            // create a Vector2 object with a postions that moves the parameter Vector2 down
            Vector2 afterM = new Vector2(i.X, i.Y + (1 * scale));
            return afterM;
        }
    }
}

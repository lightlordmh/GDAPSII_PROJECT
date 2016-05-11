using Microsoft.Xna.Framework.Graphics;

namespace The_Attempt
{
    // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating
    // Handles a collectible key needed for the player to progress in the game
    // This class will be implemented in the future
    public class Key:Collectible
    {
        // attributes
        private string type; // the type of part which this particular key is (blade, shaft, or bow)
        private bool rendered;

        // properties
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public bool Rendered
        {
            get { return rendered; }
            set { rendered = value; }
        }

        /// <summary>
        /// Constructs a Key object and places it in a Rectangle defined by the parameters that are passed in.
        /// </summary>
        /// <param name="xPos">The X coordinate of the top left point of the Rectangle.</param>
        /// <param name="yPos">The Y coordinate of the top left point of the Rectangle.</param>
        /// <param name="width">The width dimension of the Rectangle.</param>
        /// <param name="height">The height dimension of the Rectangle.</param>
        /// <param name="tp">Type that this key represents.</param>
        public Key(int xPos, int yPos, int width, int height, string tp) : base(xPos, yPos, width, height)
        {
            type = tp;
            rendered = true;
        }
    }
}

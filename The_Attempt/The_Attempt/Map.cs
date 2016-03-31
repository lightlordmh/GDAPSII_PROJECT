using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace The_Attempt
{
    // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating 
    // This game object represents the map the player will "move within"(the player does not move the map does)
    // Possible errors due to inheritance from game object
    public class Map
    {

        // attributes
        Texture2D currentTexture; // texture the object is given
        Rectangle mapPos; // the position of the map
      
        public Texture2D CurrentTexture
        {
            get { return currentTexture; }
            set { currentTexture = value; }
        }
        public Rectangle MapPos
        {
            get { return mapPos; }
            set { mapPos = value; }
        }
        public int X
        {
            get { return mapPos.X; }
            set { mapPos.X = value; }
        }
        public int Y
        {
            get { return mapPos.Y; }
            set { mapPos.Y = value; }
        }

        /// <summary>
        /// Constructs the Map object which defines the space on which the Character can walk.
        /// </summary>
        /// <param name="xPos">The X coordinate of the top left point of the Rectangle.</param>
        /// <param name="yPos">The Y coordinate of the top left point of the Rectangle.</param>
        /// <param name="width">The width dimension of the Rectangle.</param>
        /// <param name="height">The height dimension of the Rectangle.</param>
        public Map(int xPos, int yPos, int width, int height)
        {
            mapPos = new Rectangle(xPos, yPos, width, height);
        }

        /// <summary>
        /// Draws the Map to the screen.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentTexture, mapPos, Color.White);
        }
    }
}

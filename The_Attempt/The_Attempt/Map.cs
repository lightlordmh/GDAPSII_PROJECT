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
    public class Map : GameObject
    {

        /// <summary>
        /// Constructs the Map object which defines the space on which the Character can walk.
        /// </summary>
        /// <param name="xPos">The X coordinate of the top left point of the Rectangle.</param>
        /// <param name="yPos">The Y coordinate of the top left point of the Rectangle.</param>
        /// <param name="width">The width dimension of the Rectangle.</param>
        /// <param name="height">The height dimension of the Rectangle.</param>
        public Map(int xPos, int yPos, int width, int height) : base(xPos, yPos, width, height)
        {

        }

        /// <summary>
        /// Draws the Map to the screen.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (base.CurrentTexture != null)
            {
                spriteBatch.Draw(base.CurrentTexture, base.PositionCurr, Color.White);
            }
        }

        //needed for multiple levels and map textures
        //sets the texture for the current level
        //must be called after loading the corridors
        public void SetMapTexture()
        {
            int currLevel = Settings.currentLevel;
            if (currLevel >= 1 && currLevel <= Settings.mapTexture.Count())
            {
                base.CurrentTexture = Settings.mapTexture[currLevel - 1];
            }
            else
            {
                base.CurrentTexture = null;
            }
        }


    }
}

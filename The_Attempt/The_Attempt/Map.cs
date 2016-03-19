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
    public class Map:GameObject
    {

        // attributes
        private Rectangle position; // position of the object on the screen 
        private Texture2D currentTexture; // texture the object is given
        private static Vector2 mapPos;

        // properties 
        public Rectangle Position
        {
            get { return position; }
            set { position = value; }
        }

        public Texture2D CurrentTexture
        {
            get { return currentTexture; }
            set { currentTexture = value; }
        }
        public Vector2 MapPos
        {
            get { return mapPos; }
            set { mapPos = value; }
        }

        // attirbutes to handle the location and size of the map
        private int posXf = 0;
        private int posYf = 0;
        private int widthf = 0;
        private int heightf = 0;

        /// <summary>
        /// Constructs the Map object which defines the space on which the Character can walk.
        /// </summary>
        /// <param name="xPos">The X coordinate of the top left point of the Rectangle.</param>
        /// <param name="yPos">The Y coordinate of the top left point of the Rectangle.</param>
        /// <param name="width">The width dimension of the Rectangle.</param>
        /// <param name="height">The height dimension of the Rectangle.</param>
        public Map(int xPos, int yPos, int width, int height): base(xPos, yPos, width, height)
        {
            posXf = xPos;
            posYf = yPos;
            widthf = width;
            heightf = height;
        }

        // This method's purpose is unknown to the writer of this comment thus
        // this method will be edited or removed in the future
        public void UpD()
        {
            position = new Rectangle((int)mapPos.X - posXf, (int)mapPos.Y - posYf, widthf, heightf);
        }

        // draw method used to draw the GameObject to the screen
        // does not properly override the inheritted Draw method
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentTexture, position, Color.White);
        }
    }
}

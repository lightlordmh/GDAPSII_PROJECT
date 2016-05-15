using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace The_Attempt
{
    // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating
    // This class represents the physical objects that will interact in the game
    public class GameObject
    {
        // attributes
        private Rectangle position; // position of the object on the map
        private Rectangle positionCurr; //position of te object currently
        private Texture2D currentTexture; // texture the object is given

        // properties 
        public Rectangle Position
        {
            get { return position; }
            set { position = value; }
        }
        public int X
        {
            get { return position.X; }
            set { position.X = value; }
        }
        public int Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }
        public int Width
        {
            get { return position.Width; }
            set { position.Width = value; }
        }
        public int Height
        {
            get { return position.Height; }
            set { position.Height = value; }
        }


        //current position x and y
        public Rectangle PositionCurr
        {
            get { return positionCurr; }
            set { positionCurr = value; }
        }
        public int XCurr
        {
            get { return positionCurr.X; }
            set { positionCurr.X = value; }
        }
        public int YCurr
        {
            get { return positionCurr.Y; }
            set { positionCurr.Y = value; }
        }

        public Texture2D CurrentTexture
        {
            get { return currentTexture; }
            set { currentTexture = value; }
        }

        // redundant code for future removal
        /*
        public Vector2 MapPos
        {
            get { return mapPos; }
            set { mapPos = value; }
        }
        */

        /// <summary>
        /// Constructs a GameObject object and places it in a Rectangle defined by the parameters that are passed in.
        /// </summary>
        /// <param name="xPos">The X coordinate of the top left point of the Rectangle.</param>
        /// <param name="yPos">The Y coordinate of the top left point of the Rectangle.</param>
        /// <param name="width">The width dimension of the Rectangle.</param>
        /// <param name="height">The height dimension of the Rectangle.</param>
        public GameObject(int xPos, int yPos, int width, int height)
        {
            position = new Rectangle(xPos, yPos, width, height);
            positionCurr = new Rectangle(xPos, yPos, width, height);
        }

        /// <summary>
        /// Draws the GameObject to the screen.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentTexture, positionCurr, Color.White);
        }


        public void UpdateCurrPos(Map map) //arguments should be the current x and y position of the map
        {
            XCurr = X + map.XCurr;
            YCurr = Y + map.YCurr;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace The_Attempt
{
    public class Map:GameObject
    {


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

        private int posXf = 0;
        private int posYf = 0;
        private int widthf = 0;
        private int heightf = 0;



        // parameterized constructor
        public Map(int posX, int posY, int width, int height): base(posX, posY, width, height)
        {
            posXf = posX;
            posYf = posY;
            widthf = width;
            heightf = height;
        }

        public void UpD()
        {
            position = new Rectangle((int)mapPos.X - posXf, (int)mapPos.Y - posYf, widthf, heightf);
        }

        // draw method used to draw the GameObject to the screen
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentTexture, position, Color.White);
        }
    }
}

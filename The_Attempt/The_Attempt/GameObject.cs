using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace The_Attempt
{
    // This class represents the physical objects that will interact in the game
    public class GameObject
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

        // parameterized constructor
        public GameObject(int posX, int posY, int width, int height)
        {
            position = new Rectangle(posX, posY, width, height);
        }

        // draw method used to draw the GameObject to the screen
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentTexture, position, Color.White);
        }
    }
}

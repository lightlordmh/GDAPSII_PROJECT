using Microsoft.Xna.Framework.Graphics;

namespace The_Attempt
{
    public class Door:Collectible
    {
        // attribute
        private bool open;

        // property
        public bool Open
        {
            get { return open; }
            set { open = value; }
        }

        // constructor
        public Door(int posX, int posY, int width, int height) : base(posX, posY, width, height)
        {
            open = false; // collectiblies are default active
        }

        // method used to allow the player to attempt to escape when they touch a door
        public bool TurnLock(Character player)
        {
            // if the player has the correct number of key parts (only needs one for now), then the door can be opened
            if (player.NumKeyParts == 1) // going to be one for now but may increase to 3
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // overriden draw method
        public void Draw(SpriteBatch spriteBatch, Texture2D openTexture, Texture2D closedTexture)
        {
            // only draw collectible if it is active
            if (open)
            {
                CurrentTexture = openTexture;
                base.Draw(spriteBatch);
            }
            else
            {
                CurrentTexture = closedTexture;
                base.Draw(spriteBatch);
            }
        }
    }
}

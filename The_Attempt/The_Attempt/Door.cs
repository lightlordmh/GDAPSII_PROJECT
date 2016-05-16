using Microsoft.Xna.Framework.Graphics;

namespace The_Attempt
{
    // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating
    // This collectible Door object requires player interaction for the game to proceed to another level
    public class Door:Collectible
    {
        // attributes
        private bool open;

        // properties
        public bool Open
        {
            get { return open; }
            set { open = value; }
        }


        /// <summary>
        /// Constructs a Door object and places it in a Rectangle defined by the parameters that are passed in.
        /// </summary>
        /// <param name="xPos">The X coordinate of the top left point of the Rectangle.</param>
        /// <param name="yPos">The Y coordinate of the top left point of the Rectangle.</param>
        /// <param name="width">The width dimension of the Rectangle.</param>
        /// <param name="height">The height dimension of the Rectangle.</param>
        public Door(int xPos, int yPos, int width, int height) : base(xPos, yPos, width, height)
        {
            open = false; // doors are default closed
        }

        // method used to allow the player to attempt to escape when they touch a door
        /// <summary>
        /// If the player has the correct number of key parts, they can unlock the door to then complete the level.
        /// </summary>
        /// <param name="player">The player.</param>
        public void TurnLock(Character player)
        {
            // if the player has the correct number of key parts (only needs one for now), then the door can be opened
            if (player.NumKeyParts == 1) // going to be one for now but may increase to 3
            {
                open = true;
            }
        }

        // overriden draw method
        /// <summary>
        /// Overriden Draw method which draws the Door in an open or closed state depending on the 'open' attribute.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch</param>
        /// <param name="openTexture">Texture used for representing an open door.</param>
        /// <param name="closedTexture">Texture used for representing a closed door.</param>
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

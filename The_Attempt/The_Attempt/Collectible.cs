using Microsoft.Xna.Framework.Graphics;

namespace The_Attempt
{
    // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating
    // Represents game objects the player needs to collect or interact with to progress in the game
    public class Collectible:GameObject
    {
        // attributes
        private bool active;

        // properties
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        /// <summary>
        /// Constructs a Collectible object and places it in a Rectangle defined by the parameters that are passed in.
        /// </summary>
        /// <param name="xPos">The X coordinate of the top left point of the Rectangle.</param>
        /// <param name="yPos">The Y coordinate of the top left point of the Rectangle.</param>
        /// <param name="width">The width dimension of the Rectangle.</param>
        /// <param name="height">The height dimension of the Rectangle.</param>
        public Collectible(int xPos, int yPos, int width, int height) : base(xPos, yPos, width, height)
        {
            active = true; // collectiblies are default active
        }

        /// <summary>
        /// Checks to see if the Character is colliding with the Collectible. If so, makes the Collectible's active attribute set to
        /// false.
        /// </summary>
        /// <param name="player">The player.</param>
        public void CheckCollision(Character player)
        {
            if (active && Position.Intersects(player.Position))
            {
                active = false;
            }
        }
        
        /// <summary>
        /// Overridden Draw method that only draws the Collectible if it is active.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (active)
            {
                base.Draw(spriteBatch);
            }
        }
    }
}

using Microsoft.Xna.Framework.Graphics;

namespace The_Attempt
{   //Israel Anthony
    //Russell Swartz
    //Evan Keating
    //Kyle Vanderwiel
    //Handles Collectable Game Objects
    //These are game objects the player needs to collect/ intereact with to progress in the game
    public class Collectible:GameObject
    {
        // attribute
        private bool active;

        // property
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        // constructor
        public Collectible(int posX, int posY, int width, int height) : base(posX, posY, width, height)
        {
            active = true; // collectiblies are default active
        }

        // method used to detect if the player is colliding with the collectible
        public bool CheckCollision(Character player)
        {
            // if the collectible is active, check for collisions to see if player is colliding with it
            if (active && Position.Intersects(player.Position))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // overriden draw method
        public override void Draw(SpriteBatch spriteBatch)
        {
            // only draw collectible if it is active
            if (active)
            {
                base.Draw(spriteBatch);
            }
        }
    }
}

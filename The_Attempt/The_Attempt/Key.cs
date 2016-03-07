using Microsoft.Xna.Framework.Graphics;

namespace The_Attempt
{  
    public class Key:Collectible
    {
        // attributes
        private string type; // the type of part which this particular key is (blade, shaft, or bow)
        
        // properties
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        // constructor
        public Key(int posX, int posY, int width, int height, string tp) : base(posX, posY, width, height)
        {
            type = tp;
        }
    }
}

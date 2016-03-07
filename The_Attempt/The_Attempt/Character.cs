using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace The_Attempt
{
    public class Character:GameObject
    {
        // attribute
        private int numKeyParts; // number of pieces collected (only need 1 to win for now) to create a key

        // property
        public int NumKeyParts
        {
            get { return numKeyParts; }
            set { numKeyParts = value; }
        }

        // constructor
        public Character(int posX, int posY, int width, int height):base(posX,posY,width,height)
        {
            // set default number of keys to zero
            numKeyParts = 0;
        }
    }
}

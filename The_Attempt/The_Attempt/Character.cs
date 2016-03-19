using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace The_Attempt
{
    //Israel Anthony
    //Russell Swartz
    //Evan Keating
    //Kyle Vanderwiel
    //This Class represents the player character in the game
    //it inherits from the gameObject class
    public class Character:GameObject
    {
        //Attribute
        private int numKeyParts; // number of pieces collected (only need 1 to win for now) to create a key

        //Property
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

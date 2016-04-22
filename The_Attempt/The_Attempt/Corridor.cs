using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace The_Attempt
{
    // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating  
    // Handles the maze's corridors and the players collision with them
    // This Class will be implemented in the future

        // Each corridor has an x,y,width,height atribute relating to the corridor list text domucent "CorridorPosition"
        // These values have a 160:1 ratio with rendering values
        // the plus four is because the map ended up needing to be 4 extra blocks in all directions, found this out after writing that text file
    public class Corridor : GameObject
    {
        private int x;
        private int y;
        private int height;
        private int width;

        public Corridor(int xI, int yI, int hI, int wI) : base((xI)*160, (yI)*160, hI*160, wI*160)
        {
            x = xI;
            y = yI;
            height = hI;
            width = wI;
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public int Height
        {
            get { return height; }
        }

        public int Width
        {
            get { return width; }
        }
    }
}

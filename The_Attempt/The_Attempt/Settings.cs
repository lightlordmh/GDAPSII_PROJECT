using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;

namespace The_Attempt
{
    // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating
    // This class will be further fleshed out in the future
    // This class will handle setting of common defined variables in the game
    // It will also read in a Game settings txt to preset those settings before the main game runs
    static class Settings
    {
        public static int WinHeight = 800;
        public static int WinWidth = 800;



        //All current level information (maybe should be its own class
        public static int currentLevel; // current level the player is on
        public static List<Corridor> corridorList = new List<Corridor>(); //The array of corridors


        //All textures of maps, because they needed to be all static
        public static List<Texture2D> mapTexture = new List<Texture2D>();


    }
}

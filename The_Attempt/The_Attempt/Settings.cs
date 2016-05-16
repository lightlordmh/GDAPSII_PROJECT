using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Text;

namespace The_Attempt
{
    // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating
    // This class will handle setting of common defined variables in the game
    // It will also read in a Game settings txt to preset those settings before the main game runs
    static class Settings
    {
        public static int WinHeight = 800;
        public static int WinWidth = 800;
        public static string Flashlight = "FLON1";// Default setting for flashlight Brightness changed in Setup Method
        public static int EnemySpeed = 1;// Default setting for Enemy speed changed in Setup Method
        public static int Level = 1; //Default setting for the Level changed in the Setup Method

        //All current level information (maybe should be its own class
        public static int currentLevel; // current level the player is on
        public static List<Corridor> corridorList = new List<Corridor>(); //The array of corridors


        //All textures of maps, because they needed to be all static
        public static List<Texture2D> mapTexture = new List<Texture2D>();

        //sets up the Game settings to the data from the External Tool
        public static void Setup(string file)
        {
            StreamReader MySR = null;
            try
            {
                MySR = new StreamReader(file);
                string temp;
                int tempCount = 0;
                int tempVal = 0;
                while((temp = MySR.ReadLine()) != null)
                {
                    if (tempCount == 1)
                    {
                        EnemySpeed = int.Parse(temp);
                    }
                    else if (tempCount == 2)
                    {
                        Level = int.Parse(temp);
                    }
                    else
                    {
                        tempVal = int.Parse(temp);
                        switch (tempVal)
                        {
                            case 0:
                                Flashlight = "FLON3";
                                break;
                            case 1:
                                Flashlight = "FLON2";
                                break;
                            case 2:
                                Flashlight = "FLON1";
                                break;
                            case 3:
                                Flashlight = "FLON";
                                break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                if (MySR != null) MySR.Close();
            }

        }


        public static int testingint = 0;
    }
}

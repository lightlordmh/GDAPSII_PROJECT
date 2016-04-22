using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace The_Attempt
{
    class Level
    {
        // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating  
        // loads the levels as the game progresses 
        // I'm putting the mapimage here as well since it changes as the game progress
        // This Class will be implemented in the future


        // the texture for the map, there is only one now, but if multiple levels are made there will be an array of texture2Ds and a current map texture.
        


        /// <summary>
        /// Loads the correct array of corridors in the 160:1 matrix
        /// </summary>
        public void LoadCorridors()
        {
            Settings.corridorList.Clear();
            try
            {
                StreamReader reading = new StreamReader(TitleContainer.OpenStream("Content/CorPos.txt"));
                string line = "";
                while ((line = reading.ReadLine()) != null) //if someone can figure out a better way of doing this be my guest and change it
                {
                    int fC = line.IndexOf(",");
                    int fS = line.IndexOf("|");
                    int lC = line.LastIndexOf(",");
                    int lS = line.LastIndexOf("|");

                    int xI = int.Parse(line.Substring(0, fC));
                    int yI = int.Parse(line.Substring(fC + 1, fS - fC - 1));
                    int widthI = int.Parse(line.Substring(fS + 1, lC - fS - 1));
                    int heightI = int.Parse(line.Substring(lC + 1, lS - lC - 1));

                    Settings.corridorList.Add(new Corridor(xI + 3, yI + 3, widthI, heightI));
                }
                reading.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            Settings.currentLevel++;
        }
    }
}

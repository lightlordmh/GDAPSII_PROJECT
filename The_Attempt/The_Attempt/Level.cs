﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace The_Attempt
{
    // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating  
    // Loads the levels as the game progresses 
    class Level
    {      
        /// <summary>
        /// Loads the correct array of corridors in the 160:1 matrix
        /// </summary>
        public void LoadCorridors()
        {
            string fileName = "Content/";

            if(Settings.Level == 1)
            {
                fileName += "CorPos1.txt";
            }
            else if(Settings.Level == 2)
            {
                fileName += "CorPos2.txt";
            }

            Settings.corridorList.Clear();
            try
            {
                StreamReader reading = new StreamReader(TitleContainer.OpenStream(fileName));
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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace The_Attempt
{
    // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating
    // This class will be implemented in the future
    // Handles collision between game objects
    class CollDetect
    {
        //enum directcion {U,D,L,R}
        //loop that creates the array of corridor rectangles from a text file (this is in the constructor)


        //detect method(argument direction, map.x, map.y)
        //{
        //loop that updates every corridor array object with the map position
        //loop that checks to see if any of the corridor array rectangles are intersecting the character rectangle (the character rectangle never changes)
        //if it does activate a switch
        //switch takes the direction and each case moves it back the opposite direction
        //}

        //The 1:160 scale version of things is called the "SmallScale" vs "LargeScale"





        //checking for basically any collision between objects
        public bool SimpleCheck(Rectangle objOne, Rectangle objTwo)
        {
            Rectangle collision = new Rectangle(0, 0, 0, 0);
            collision = Rectangle.Intersect(objOne, objTwo);

            if (collision.Width > 10 && collision.Height > 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //finds the x & y coordinates on the 1:160 and returns them as a vector
        public Vector2 FindSmallScaleLocation(Rectangle obj, Map currentMap)
        {
            int xOnMap = ((int)((obj.X - currentMap.X) / 160)) - 1;
            int yOnMap = ((int)((obj.Y - currentMap.Y) / 160)) - 1;
            Vector2 returning = new Vector2(xOnMap, yOnMap);
            return returning;
        }





                                                                               //for directionmoved input the direction to move back
        public int corridorCheck(Rectangle objChecking, Map currentMap) //for the char pass in either U, D, L or R
        { 
            Vector2[] cornerCheck = new Vector2[4];
            cornerCheck[0] = new Vector2(0,0); //TL
            cornerCheck[1] = new Vector2(0,0); //BL
            cornerCheck[2] = new Vector2(0,0); //TR
            cornerCheck[3] = new Vector2(0,0); //BR

            //corner rectangles
            //array of corners (TL:0, BL:1, TR:2, BR:3)
            Rectangle[] corners = new Rectangle[4];
            corners[0] = new Rectangle(objChecking.X, objChecking.Y, 5, 5); //top left of object
            corners[1] = new Rectangle(objChecking.X, (objChecking.Y + objChecking.Height)-5, 5, 5); //bottom left
            corners[2] = new Rectangle((objChecking.X + objChecking.Width)-5, objChecking.Y, 5, 5); //top right
            corners[3] = new Rectangle((objChecking.X + objChecking.Width) - 5, (objChecking.Y + objChecking.Height) - 5, 5, 5); //bottom right



            //Vector2 simplePos = FindSmallScaleLocation(objChecking, currentMap);

            Corridor instanceCorridor;
            Rectangle check = new Rectangle(0, 0, 0, 0);

            foreach (Corridor corridor in Settings.corridorList)
            {
                instanceCorridor = corridor;
                instanceCorridor.UpdateCurrPos(currentMap);

                for (int i = 0; i < 4; i++)
                {
                    check = Rectangle.Intersect(corners[i], instanceCorridor.PositionCurr);

                    cornerCheck[i].X += check.Width;
                    cornerCheck[i].Y += check.Height;
                    
                }
            }

            if (cornerCheck[0].X > 4 && cornerCheck[0].Y > 4 && cornerCheck[1].Y > 4 && cornerCheck[1].X > 4 && cornerCheck[2].Y > 4 && cornerCheck[2].X > 4 && cornerCheck[3].Y > 4 && cornerCheck[3].X > 4)// is fully in at least one corridor
            {
                //this is for finding when the ai is on an intersection of corridor
                if (cornerCheck[0].Y > 9 && cornerCheck[0].X > 9 && cornerCheck[1].Y > 9 && cornerCheck[1].X > 9 && cornerCheck[2].Y > 9 && cornerCheck[2].X > 9 && cornerCheck[3].Y > 9 && cornerCheck[3].X > 9) //is in two coridors
                {
                    return 0;
                }
                else //is in only one corridor
                {
                    return 2;
                }
            }
            else// if(cornerCheck[0].X < 5 && cornerCheck[0].Y < 5 || cornerCheck[1].Y < 5 && cornerCheck[1].X < 5 || cornerCheck[2].Y < 5 && cornerCheck[2].X < 5 || cornerCheck[3].Y < 5 && cornerCheck[3].X < 5)
            {
                return 1;
            }
          //  else
           // {
           //     Settings.testingint = 1;
           //     return 1;
          //  }

            //returns here explained
            //0 = turn and is a good direction
            //1 = turn but isn't a good direction
            //2 = dont turn and is a good direction
        }


    }
}

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

            if (collision.Width > 10 && collision.Height > 0)
            {
                return false;
            }
            else
            {
                return true;
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
        public bool corridorCheck(Rectangle objChecking, GameObject objMoving, char directionMoved, Map currentMap, Movement move) //for the char pass in either U, D, L or R
        { 

            //its ints due to the functionality of the AI
            Vector2[] cornerCheck = new Vector2[4];
            cornerCheck[0] = new Vector2(0,0);
            cornerCheck[1] = new Vector2(0,0);
            cornerCheck[2] = new Vector2(0,0);
            cornerCheck[3] = new Vector2(0,0);

            //current map position
            int mapX = currentMap.XCurr;
            int mapY = currentMap.YCurr;

            //corner rectangles
            //array of corners (TL:0, BL:1, TR:2, BR:3)
            Rectangle[] corners = new Rectangle[4];
            corners[0] = new Rectangle(objChecking.X, objChecking.Y, 5, 5); //top left of object
            corners[1] = new Rectangle(objChecking.X, objChecking.Y + objChecking.Height, 5, 5); //bottom left
            corners[2] = new Rectangle(objChecking.X + objChecking.Width, objChecking.Y, 5, 5); //top right
            corners[3] = new Rectangle(objChecking.X + objChecking.Width, objChecking.Y + objChecking.Height, 5, 5); //bottom right



            Vector2 simplePos = FindSmallScaleLocation(objChecking, currentMap);

            Corridor instanceCorridor;
            Rectangle check = new Rectangle(0, 0, 0, 0);

            foreach (Corridor corridor in Settings.corridorList)
            {
                instanceCorridor = corridor;
                instanceCorridor.UpdateCurrPos(mapX, mapY);

                for (int i = 0; i < 4; i++)
                {
                    check = Rectangle.Intersect(corners[i], instanceCorridor.PositionCurr);

                    cornerCheck[i].X += check.Width;
                    cornerCheck[i].Y += check.Height;
                    
                }
            }

            if (cornerCheck[0].X > 4 && cornerCheck[0].X > 4 && cornerCheck[1].X > 4 && cornerCheck[1].X > 4 && cornerCheck[2].X > 4 && cornerCheck[2].X > 4 && cornerCheck[3].X > 4 && cornerCheck[3].X > 4)
            {
                if (cornerCheck[0].X < 10 && cornerCheck[0].X < 10 && cornerCheck[1].X < 10 && cornerCheck[1].X < 10 && cornerCheck[2].X < 10 && cornerCheck[2].X < 10 && cornerCheck[3].X < 10 && cornerCheck[3].X < 10)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {

                switch (directionMoved)
                {
                    case 'U':
                        objMoving.Y = move.Up(objMoving.Position);
                        break;
                    case 'D':
                        objMoving.Y = move.Down(objMoving.Position);
                        break;
                    case 'L':
                        objMoving.X = move.Left(objMoving.Position);
                        break;
                    case 'R':
                        objMoving.X = move.Right(objMoving.Position);
                        break;
                }
                return true;
            }

        }
    }
}

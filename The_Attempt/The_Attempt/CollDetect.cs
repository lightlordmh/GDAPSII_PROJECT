using System;
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
        Movement move = new Movement(6);

            //checking for basically any collision between objects
        public bool SimpleCheck(Rectangle objOne, Rectangle objTwo)
        {
            Rectangle collision = new Rectangle(0, 0, 0, 0);
            collision = Rectangle.Intersect(objOne, objTwo);
            
            if(collision.Width > 10 && collision.Height > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //finds the x & y coordinates on the 1:160 and returns them as a vector
        public Vector2 FindLocation(Rectangle obj, Map currentMap)
        {
            int xOnMap = ((int)((obj.X - currentMap.X) / 160))-1;
            int yOnMap = ((int)((obj.Y - currentMap.Y) / 160))-1;
            Vector2 returning = new Vector2(xOnMap, yOnMap);
            return returning;
        }

        public bool corridorCheck(Vector2 simpleCoor, Rectangle objChecking, Rectangle objMoving, char directionMoved) //for the char pass in either U, D, L or R
        {
            int intersectWidth = 0;
            int intersectHeight = 0;

            Rectangle instanceCorridor;
            Rectangle check = new Rectangle(0, 0, 0, 0);

            foreach (Corridor corridor in Settings.corridorList)
            {
                if(corridor.X == simpleCoor.X - 1 || corridor.X == simpleCoor.X || corridor.X == simpleCoor.X + 1)
                {
                    instanceCorridor = new Rectangle(corridor.X, corridor.Y, corridor.Width, corridor.Height);
                    check = Rectangle.Intersect(instanceCorridor, objChecking);
                    intersectWidth += check.Width;
                    intersectHeight += check.Height;
                }
                else if (corridor.Y == simpleCoor.Y - 1 || corridor.Y == simpleCoor.Y || corridor.Y == simpleCoor.Y + 1)
                {
                    instanceCorridor = new Rectangle(corridor.X, corridor.Y, corridor.Width, corridor.Height);
                    check = Rectangle.Intersect(instanceCorridor, objChecking);
                    intersectWidth += check.Width;
                    intersectHeight += check.Height;
                }
            }

            if(intersectWidth < objChecking.Width || intersectHeight < objChecking.Height)
            {
                switch(directionMoved)
                {
                    case 'U': move.Down(objMoving);
                        break;
                    case 'D': move.Up(objMoving);
                        break;
                    case 'L': move.Right(objMoving);
                        break;
                    case 'R': move.Left(objMoving);
                        break;
                }
                return true;
            }
            else if(intersectWidth > objChecking.Width*2 || intersectHeight > objChecking.Height*2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}

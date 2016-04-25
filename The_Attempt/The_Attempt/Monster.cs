using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace The_Attempt
{
    // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating
    // Handles the Monster game object and AI
    // This class will be implemented in the future
    public class Monster : GameObject
    {
        // attributes
        private int creepSpeed = 0; // the speed at which the monster moves while not in pursuit mode
        private int rushSpeed = 0; // the speed at which the monster moves while in pursuit mode
        private Movement move = null;
        private CollDetect collide;
        private Random rgen;

        private bool[] possibleDirections = new bool[4];

        private enum direction
        {
            up,
            down,
            left,
            right
        }

        private direction currentDirection;

        // properties
        public int CreepSpeed
        {
            get { return creepSpeed; }
            set { creepSpeed = value; }
        }
        public int RushSpeed
        {
            get { return rushSpeed; }
            set { rushSpeed = value; }
        }


        // properties for the directions array
        public bool DirectUp
        {
            get { return possibleDirections[0]; }
            set { possibleDirections[0] = value; }
        }

        public bool DirectDown
        {
            get { return possibleDirections[1]; }
            set { possibleDirections[1] = value; }
        }

        public bool DirectLeft
        {
            get { return possibleDirections[2]; }
            set { possibleDirections[2] = value; }
        }

        public bool DirectRight
        {
            get { return possibleDirections[3]; }
            set { possibleDirections[3] = value; }
        }

        /// <summary>
        /// Constructs a Monster object and places it in a Rectangle defined by the parameters that are passed in.
        /// </summary>
        /// <param name="xPos">The X coordinate of the top left point of the Rectangle.</param>
        /// <param name="yPos">The Y coordinate of the top left point of the Rectangle.</param>
        /// <param name="width">The width dimension of the Rectangle.</param>
        /// <param name="height">The height dimension of the Rectangle.</param>
        public Monster(int xPos, int yPos, int width, int height, int cSpeed, int rSpeed) : base(xPos, yPos, width, height)
        {
            cSpeed = creepSpeed;
            rSpeed = rushSpeed;
            move = new Movement(cSpeed);
            collide = new CollDetect();
            rgen = new Random();
        }





        public void aiMove(GameObject player, Map map)
        {
            if (currentDirection == null)
            {
                Assess(map);
                int directionPlayer = FindPlayer(player, map);
                int[] directPercent = DirectionPercent(directionPlayer);
                int monsterDirect = PickDirection(directPercent);
            }
        }

        private void Assess(Map mapI)
        {
             // 0:up 1:down 2:left 3:right

            move.Up(base.Position);  //position to move via ai possition current to refrence onto map
            possibleDirections[0] = collide.corridorCheck(base.Position, this, 'U', mapI, move);

            move.Down(base.Position); 
            possibleDirections[1] = collide.corridorCheck(base.Position, this, 'D', mapI, move);

            move.Left(base.Position);
            possibleDirections[2] = collide.corridorCheck(base.Position, this, 'L', mapI, move);

            move.Right(base.Position);
            possibleDirections[3] = collide.corridorCheck(base.Position, this, 'R', mapI, move);

        }

        private int FindPlayer(GameObject player, Map mapI) // the returning int is the direction the player is, 1 is directly North, 2 is NE 3 is E so on till 8 9 is if the monster is on you
        {
            Vector2 playerPos;
            playerPos = collide.FindSmallScaleLocation(player.Position,mapI);
            Vector2 monsterPos;
            monsterPos = collide.FindSmallScaleLocation(base.PositionCurr, mapI);

            if(monsterPos.X == playerPos.X && monsterPos.Y == playerPos.Y) { return 9; }
            if (monsterPos.X == playerPos.X && monsterPos.Y > playerPos.Y) { return 1; }
            if (monsterPos.X < playerPos.X && monsterPos.Y > playerPos.Y) { return 2; }
            if (monsterPos.X < playerPos.X && monsterPos.Y == playerPos.Y) { return 3; }
            if (monsterPos.X < playerPos.X && monsterPos.Y < playerPos.Y) { return 4; }
            if (monsterPos.X == playerPos.X && monsterPos.Y < playerPos.Y) { return 5; }
            if (monsterPos.X > playerPos.X && monsterPos.Y < playerPos.Y) { return 6; }
            if (monsterPos.X > playerPos.X && monsterPos.Y == playerPos.Y) { return 7; }
            if (monsterPos.X > playerPos.X && monsterPos.Y > playerPos.Y) { return 8; }
            else { return 0; } //shouldn't return 0
        }

        private int[] DirectionPercent(int playerD) //should be modified to make ai better at tracking 
        {
            //up, down, left, right

            int[] percents = new int[4];
            if (playerD == 0) { percents[0] = 0; percents[1] = 0; percents[2] = 0; percents[3] = 0; }
            if (playerD == 1) { percents[0] = 70; percents[1] = 6; percents[2] = 12; percents[3] = 12; }
            if (playerD == 2) { percents[0] = 42; percents[1] = 8; percents[2] = 8; percents[3] = 42; }
            if (playerD == 3) { percents[0] = 12; percents[1] = 12; percents[2] = 6; percents[3] = 70; }
            if (playerD == 4) { percents[0] = 8; percents[1] = 42; percents[2] = 8; percents[3] = 42; }
            if (playerD == 5) { percents[0] = 6; percents[1] = 70; percents[2] = 12; percents[3] = 12; }
            if (playerD == 6) { percents[0] = 8; percents[1] = 42; percents[2] = 42; percents[3] = 8; }
            if (playerD == 7) { percents[0] = 12; percents[1] =12; percents[2] = 70; percents[3] = 6; }
            if (playerD == 8) { percents[0] = 42; percents[1] = 8; percents[2] = 42; percents[3] = 8; }
            if (playerD == 9) { percents[0] = 0; percents[1] = 0; percents[2] = 0; percents[3] = 0; }
            else { return null; }

            for(int i = 0; i < 4; i++)
            {
                if(possibleDirections[i] == false)
                {
                    percents[i] = 0;
                }
            }

            return percents;
        }


        private int PickDirection(int[] percentsPrev)  //retuns direction 0:U 1:D 2:L 3:R
        {
            int returning = -1;
            int adding = 0;
            for(int i = 0; i < 4; i++)
            {
                if (percentsPrev[i] != 0)
                {
                    percentsPrev[i] += adding;
                    adding = percentsPrev[i];
                }
            }

            int randomNum = rgen.Next(adding) + 1;

            for(int i = 0; i < 4; i++)
            {
                if(percentsPrev[i] != 0)
                {
                    if(randomNum <= percentsPrev[i])
                    {
                        returning = i;
                    }
                    else { return -1; }
                }
            }

            return returning;

            
        }
    }
 }

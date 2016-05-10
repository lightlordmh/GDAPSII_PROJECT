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
        private Movement assessMove;
        private CollDetect collide;
        private Random rgen;
        private bool turn;

        private bool[] possibleDirections = new bool[4];


        //later
        // private enum direction
        //  {
        //     up,
        //     down,
        //    left,
        //    right
        // }

        // private direction currentDirection;


        private int currentDirection = -1;  //can make into a enum later -1 is null 0,1,2,3 are U,D,L,R

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
            assessMove = new Movement(20);
            turn = false;
        }





        public void aiMove(GameObject player, Map map)
        {
            
            if (currentDirection == -1 || turn == true)
            {
                Assess(map);
                int directionPlayer = FindPlayer(player, map);
                int[] directPercent = DirectionPercent(directionPlayer);
                int monsterDirect = PickDirection(directPercent); //will get either 0,1,2,or 3 U,D,L,R
                currentDirection = monsterDirect;
                turn = false;
            }

            if(currentDirection == 0) // up
            {
                base.Y = move.Up(base.Position);
                base.UpdateCurrPos(map.X, map.Y);
                turn = collide.corridorCheck(base.PositionCurr, this, 'D', map, move);
            }
            if (currentDirection == 1) // down
            {
                base.Y = move.Down(base.Position);
                base.UpdateCurrPos(map.X, map.Y);
                turn = collide.corridorCheck(base.PositionCurr, this, 'U', map, move);
            }
            if (currentDirection == 2) // right
            {
                base.Y = move.Left(base.Position);
                base.UpdateCurrPos(map.X, map.Y);
                turn = collide.corridorCheck(base.PositionCurr, this, 'R', map, move);
            }
            if (currentDirection == 3) // left
            {
                base.Y = move.Right(base.Position);
                base.UpdateCurrPos(map.X, map.Y);
                turn = collide.corridorCheck(base.PositionCurr, this, 'L', map, move);
            }


        }


        private void Assess(Map mapI)
        {
            // 0:up 1:down 2:left 3:right
            assessMove.Up(base.Position);
            base.UpdateCurrPos(mapI.X, mapI.Y);
            possibleDirections[0] = collide.corridorCheck(base.PositionCurr, this, 'D', mapI, assessMove);//returning false means it is a possible location to move DONT CHANGE THAT
            if (possibleDirections[0] == false) { assessMove.Down(base.Position); } //these move the object if it is a posible location to move to

            assessMove.Down(base.Position);
            base.UpdateCurrPos(mapI.X, mapI.Y);
            possibleDirections[1] = collide.corridorCheck(base.PositionCurr, this, 'U', mapI, assessMove);
            if (possibleDirections[1] == false) { assessMove.Up(base.Position); }

            assessMove.Left(base.Position);
            base.UpdateCurrPos(mapI.X, mapI.Y);
            possibleDirections[2] = collide.corridorCheck(base.PositionCurr, this, 'R', mapI, assessMove);
            if (possibleDirections[2] == false) { assessMove.Right(base.Position); }

            assessMove.Right(base.Position);
            base.UpdateCurrPos(mapI.X, mapI.Y);
            possibleDirections[3] = collide.corridorCheck(base.PositionCurr, this, 'L', mapI, assessMove);
            if (possibleDirections[3] == false) { assessMove.Left(base.Position); }
        }

        private int FindPlayer(GameObject player, Map mapI) // the returning int is the direction the player is, 1 is directly North, 2 is NE 3 is E so on till 8 9 is if the monster is on you
        {
            Vector2 playerPos;
            playerPos = collide.FindSmallScaleLocation(player.Position,mapI);
            Vector2 monsterPos;
            base.UpdateCurrPos(mapI.X, mapI.Y);
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
//<<<<<<< HEAD
//=======
            // else { return null; }
//>>>>>>> c6b72f81626781076d804a45c83747d294b7c09d

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
                if(percentsPrev[i] != 0 && returning == -1)
                {
                    if(randomNum <= percentsPrev[i])
                    {
                        returning = i;
                    }
                }
            }

            return returning;
        }
    }
 }

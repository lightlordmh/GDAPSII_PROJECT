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
        private Movement move;
        private Movement assessMove;
        private CollDetect collide;
        private Random rgen;
        private int turn; //2 is not turning while 0 and 1 are turning

        private int[] possibleDirections = new int[4];


        // private direction currentDirection;
        private int currentDirection;  //can make into a enum later -1 is null 0,1,2,3 are U,D,L,R

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
        public int CurrentDirection
        {
            get { return currentDirection; }
        }



        // properties for the directions array
        public int DirectUp
        {
            get { return possibleDirections[0]; }
            set { possibleDirections[0] = value; }
        }

        public int DirectDown
        {
            get { return possibleDirections[1]; }
            set { possibleDirections[1] = value; }
        }

        public int DirectLeft
        {
            get { return possibleDirections[2]; }
            set { possibleDirections[2] = value; }
        }

        public int DirectRight
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
            creepSpeed = cSpeed;
            rushSpeed = rSpeed;
            move = new Movement(cSpeed);
            collide = new CollDetect();
            rgen = new Random();
            assessMove = new Movement(15);
            turn = 2; 
            currentDirection = 3;
        }





        public void aiMove(GameObject player, Map map)
        {
            //monster spawns with currentdirection == -1
            //turn 1 and turn 0 


            if (turn == 1 || turn == 0) 
            {
                Assess(map);
                int directionPlayer = FindPlayer(player, map);
                int[] directPercent = DirectionPercent(directionPlayer);
                int monsterDirect = PickDirection(directPercent); //will get either 0,1,2,or 3 (U,D,L,R)
                currentDirection = monsterDirect;
                turn = 2;
            }

            else if(currentDirection == 0) // up
            {
                base.Y = move.Up(base.Position);
                base.UpdateCurrPos(map);
                turn = collide.corridorCheck(base.PositionCurr, map);
                if(turn == 1)
                {
                    base.Y = move.Down(base.Position);
                }
            }
            else if (currentDirection == 1) // down
            {
                base.Y = move.Down(base.Position);
                base.UpdateCurrPos(map);
                turn = collide.corridorCheck(base.PositionCurr, map);
                if (turn == 1)
                {
                    base.Y = move.Up(base.Position);
                }
            }
            else if (currentDirection == 2) // left
            {

                base.X = move.Left(base.Position);
                base.UpdateCurrPos(map);
                turn = collide.corridorCheck(base.PositionCurr, map);
                if (turn == 1)
                {
                    base.X = move.Right(base.Position);
                }
            }
            else if (currentDirection == 3) // right
            {
                base.X = move.Right(base.Position);
                base.UpdateCurrPos(map);
                turn = collide.corridorCheck(base.PositionCurr, map);
                if (turn == 1)
                {
                    base.X = move.Left(base.Position);
                }
            }
        }


        private void Assess(Map map) //possible directions are 2 and 0
        {
            // 0:up 1:down 2:left 3:right
            base.UpdateCurrPos(map);
            base.YCurr = assessMove.Up(base.PositionCurr);
            possibleDirections[0] = collide.corridorCheck(base.PositionCurr, map);//returning false means it is a possible location to move DONT CHANGE THAT
            if (possibleDirections[0] == 0 || possibleDirections[0] == 1) { base.YCurr = assessMove.Down(base.PositionCurr); } //these move the object if it is a posible location to move to

            base.UpdateCurrPos(map);
            base.YCurr = assessMove.Down(base.PositionCurr);
            possibleDirections[1] = collide.corridorCheck(base.PositionCurr, map);
            if (possibleDirections[1] == 0 || possibleDirections[1] == 1) { base.YCurr = assessMove.Up(base.PositionCurr); }

            base.UpdateCurrPos(map);
            base.XCurr = assessMove.Left(base.PositionCurr);
            possibleDirections[2] = collide.corridorCheck(base.PositionCurr, map);
            if (possibleDirections[2] == 0 || possibleDirections[2] == 1) { base.XCurr = assessMove.Right(base.PositionCurr); }

            base.UpdateCurrPos(map);
            base.XCurr = assessMove.Right(base.PositionCurr);
            possibleDirections[3] = collide.corridorCheck(base.PositionCurr, map);
            if (possibleDirections[3] == 0 || possibleDirections[3] == 1) { base.XCurr = assessMove.Left(base.PositionCurr); }
        }

        private int FindPlayer(GameObject player, Map map) // the returning int is the direction the player is, 1 is directly North, 2 is NE 3 is E so on till 8 9 is if the monster is on you
        {
            Vector2 playerPos;
            playerPos = collide.FindSmallScaleLocation(player.PositionCurr,map);
            Vector2 monsterPos;
            base.UpdateCurrPos(map);
            monsterPos = collide.FindSmallScaleLocation(base.PositionCurr, map);

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

            for(int i = 0; i < 4; i++)
            {
                if(possibleDirections[i] == 1)
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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace The_Attempt
{
    // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating
    // Handles the input for the Charater's movement.
    public class Input
    { 
        /// <summary>
        /// Checks the current state of the keyboard then does selected events based on the keyboard state.
        /// </summary>
        /// <param name="curGameMap">Parameter to store the game's map.</param>
        public string Check(Map curGameMap)
        {
            KeyboardState kbState = Keyboard.GetState(); // keyboardState object to store the current state of the keyboard

            Movement inputMove = new Movement(3); // movement object to move the map object based on keyboard input
            CollDetect detect = new CollDetect();
            Rectangle instanceOfPlayer = new Rectangle(360, 360, 80, 80);

            string direction = ""; // used to return the direction the player is facing
            int fallback = 0;

            
            // check if the leftshift key is being pressed
            if (kbState.IsKeyDown(Keys.LeftShift)) 
            {
                // call and set inputMove's scale propety to double its previous value
                inputMove.Scale *= 2;
            }
            // check if the W key is being pressed
            if (kbState.IsKeyDown(Keys.W))
            {
                // change the current game map's position by updating the Y position of it's Rectangle in the vertically upward direction
                curGameMap.YCurr = inputMove.Down(curGameMap.PositionCurr);

                // calls CollDectec.detect( argument either u,d,l or r (one of these), curGameMap.x, curGameMap.y) returning a bool to see if its colliding with a corridor
                fallback = detect.corridorCheck(instanceOfPlayer, curGameMap);

                if (fallback == 1)
                {
                    curGameMap.YCurr = inputMove.Up(curGameMap.PositionCurr);
                }

                direction = "Walk Up";
            }
            // check if the D key is being pressed
            if (kbState.IsKeyDown(Keys.D))
            {
                // change the current game map's position by updating the X position of it's Rectangle in the right direction
                curGameMap.XCurr = inputMove.Left(curGameMap.PositionCurr);

                // calls CollDectec.detect( argument either u,d,l or r (one of these), curGameMap.x, curGameMap.y) returning a bool to see if its colliding with a corridor
                fallback = detect.corridorCheck(instanceOfPlayer, curGameMap);

                if (fallback == 1)
                {
                    curGameMap.XCurr = inputMove.Right(curGameMap.PositionCurr);
                }

                direction = "Walk Right";
            }
            // check if the S key is being pressed
            if (kbState.IsKeyDown(Keys.S))
            {
                // change the current game map's position by updating the Y position of it's Rectangle in the vertically downward direction
                curGameMap.YCurr = inputMove.Up(curGameMap.PositionCurr);

                // calls CollDectec.detect( argument either u,d,l or r (one of these), curGameMap.x, curGameMap.y) returning a bool to see if its colliding with a corridor
                fallback = detect.corridorCheck(instanceOfPlayer, curGameMap);

                if (fallback == 1)
                {
                    curGameMap.YCurr = inputMove.Down(curGameMap.PositionCurr);
                }

                direction = "Walk Down";
            }
            // check if the A key is being pressed
            if (kbState.IsKeyDown(Keys.A))
            {
                // change the current game map's position by updating the X position of it's Rectangle in the left direction
                curGameMap.XCurr = inputMove.Right(curGameMap.PositionCurr);

                // calls CollDectec.detect( argument either u,d,l or r (one of these), curGameMap.x, curGameMap.y) returning a bool to see if its colliding with a corridor
                fallback = detect.corridorCheck(instanceOfPlayer, curGameMap);

                if (fallback == 1)
                {
                    curGameMap.XCurr = inputMove.Left(curGameMap.PositionCurr);
                }

                direction = "Walk Left";
            }
            // check if the space key is being pressed
            
            if (kbState.IsKeyDown(Keys.Space)) //Flashlight
            {
                // for future implementation
            }

            return direction;
        }
    }
}

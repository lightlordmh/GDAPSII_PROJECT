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
            Vector2 curPosOnMap = new Vector2(0, 0); // used for the collision detect
            CollDetect detect = new CollDetect();
            Rectangle instanceOfPlayer = new Rectangle(400, 400, 80, 80);
            string direction = ""; // used to return the direction the player is facing

            // each key that we might use
            // check if the leftshift key is being pressed
            if (kbState.IsKeyDown(Keys.LeftShift)) //Running if we have it
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
                detect.corridorCheck(instanceOfPlayer, curGameMap.PositionCurr, 'U' , curGameMap, inputMove);

                direction = "Face Up";
            }
            // check if the D key is being pressed
            if (kbState.IsKeyDown(Keys.D))
            {
                // change the current game map's position by updating the X position of it's Rectangle in the right direction
                curGameMap.XCurr = inputMove.Left(curGameMap.PositionCurr);

                // calls CollDectec.detect( argument either u,d,l or r (one of these), curGameMap.x, curGameMap.y) returning a bool to see if its colliding with a corridor
                detect.corridorCheck(instanceOfPlayer, curGameMap.PositionCurr, 'R' , curGameMap, inputMove);

                direction = "Face Right";
            }
            // check if the S key is being pressed
            if (kbState.IsKeyDown(Keys.S))
            {
                // change the current game map's position by updating the Y position of it's Rectangle in the vertically downward direction
                curGameMap.YCurr = inputMove.Up(curGameMap.PositionCurr);

                // calls CollDectec.detect( argument either u,d,l or r (one of these), curGameMap.x, curGameMap.y) returning a bool to see if its colliding with a corridor
                detect.corridorCheck(instanceOfPlayer, curGameMap.PositionCurr, 'D' , curGameMap, inputMove);

                direction = "Face Down";
            }
            // check if the A key is being pressed
            if (kbState.IsKeyDown(Keys.A))
            {
                // change the current game map's position by updating the X position of it's Rectangle in the left direction
                curGameMap.XCurr = inputMove.Right(curGameMap.PositionCurr);

                // calls CollDectec.detect( argument either u,d,l or r (one of these), curGameMap.x, curGameMap.y) returning a bool to see if its colliding with a corridor
                detect.corridorCheck(instanceOfPlayer, curGameMap.PositionCurr, 'L' , curGameMap, inputMove);

                direction = "Face Left";
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

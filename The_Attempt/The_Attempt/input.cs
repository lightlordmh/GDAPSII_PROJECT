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
        public void Check(Map curGameMap)
        {
            KeyboardState kbState = Keyboard.GetState(); // keyboardState object to store the current state of the keyboard

            Movement inputMove = new Movement(3); // movement object to move the map object based on keyboard input


            // each key that we might use
            // check if the leftshift key is being pressed
            if (kbState.IsKeyDown(Keys.LeftShift)) //Running if we have it
            {
                // call and set inputMove's scale propety 
                inputMove.Scale = 1.3F;
            }
            // check if the W key is being pressed
            if (kbState.IsKeyDown(Keys.W))
            {
                // create a Vector2 object given the current game maps position.
               Vector2 bMM = curGameMap.MapPos;
                // change the current game map's position to that of inputMove's down method given the vector2
               curGameMap.MapPos = inputMove.Down(bMM);
            }
            // check if the D key is being pressed
            if (kbState.IsKeyDown(Keys.D))
            {
                // create a Vector 2 object given the current game maps position
                Vector2 bMM = curGameMap.MapPos;
                // change the current game map's position to thtat of the inputMove's left method given the Vector2
                curGameMap.MapPos = inputMove.Left(bMM);
            }
            // check if the S key is being pressed
            if (kbState.IsKeyDown(Keys.S))
            {
                // create a Vector2 object give the current game maps position
                Vector2 bMM = curGameMap.MapPos;
                // chagne the current game mp's position to that of the inputMove's up method given the Vector2
                curGameMap.MapPos = inputMove.Up(bMM);
            }
            // check if the A key is being pressed
            if (kbState.IsKeyDown(Keys.A))
            {
                // create a Vector2 object given the current game maps position
                Vector2 bMM = curGameMap.MapPos;
                // change the current game map's positon to that of the inputMove's right method give the Vector2
                curGameMap.MapPos = inputMove.Right(bMM);
            }
            // check if the space key is being pressed
            
            if (kbState.IsKeyDown(Keys.Space)) //Flashlight
            {
                // for future implementation
            }
        }
    }
}

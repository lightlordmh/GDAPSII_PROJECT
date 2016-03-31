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
                // call and set inputMove's scale propety to double its previous value
                inputMove.Scale *= 2;
            }
            // check if the W key is being pressed
            if (kbState.IsKeyDown(Keys.W))
            {
                // change the current game map's position by updating the Y position of it's Rectangle in the vertically upward direction
               curGameMap.Y = inputMove.Up(curGameMap.MapPos);
            }
            // check if the D key is being pressed
            if (kbState.IsKeyDown(Keys.D))
            {
                // change the current game map's position by updating the X position of it's Rectangle in the right direction
                curGameMap.X = inputMove.Right(curGameMap.MapPos);
            }
            // check if the S key is being pressed
            if (kbState.IsKeyDown(Keys.S))
            {
                // change the current game map's position by updating the Y position of it's Rectangle in the vertically downward direction
                curGameMap.Y = inputMove.Down(curGameMap.MapPos);
            }
            // check if the A key is being pressed
            if (kbState.IsKeyDown(Keys.A))
            {
                // change the current game map's position by updating the X position of it's Rectangle in the left direction
                curGameMap.X = inputMove.Left(curGameMap.MapPos);
            }
            // check if the space key is being pressed
            
            if (kbState.IsKeyDown(Keys.Space)) //Flashlight
            {
                // for future implementation
            }
        }
    }
}

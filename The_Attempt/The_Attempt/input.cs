using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace The_Attempt
{
    public class Input
    {
        //Israel Anthony
        //Russell Swartz
        //Evan Keating
        //Kyle Vanderwiel
        /// <summary>
        /// checks the current state of the keyboard then
        /// does selected events based on the keyboard state
        /// </summary>
        /// <param name="curGameMap">Parameter to store the game's map</param>
        public void Check(Map curGameMap)
        {
            KeyboardState kbState = Keyboard.GetState(); //keyboardState object to store the current state of the keyboard

            Movement inputMove = new Movement(); //Movement object to move the map object based on keyboard input


            //Each key that we might use
            //Check if the leftshift key is being pressed
            if (kbState.IsKeyDown(Keys.LeftShift)) //Running if we have it
            {
                //call and set inputMove's scale propety 
                inputMove.Scale = 1.3F;
            }
            //Check if the W key is being pressed
            if (kbState.IsKeyDown(Keys.W))
            {
                //Create a Vector2 object given the current game maps position.
               Vector2 bMM = curGameMap.MapPos;
                //change the current game map's position to that of inputMove's down method given the vector2
               curGameMap.MapPos = inputMove.Down(bMM);
            }
            //Check if the D key is being pressed
            if (kbState.IsKeyDown(Keys.D))
            {
                //Create a Vector 2 object given the current game maps position
                Vector2 bMM = curGameMap.MapPos;
                //Change the current game map's position to thtat of the inputMove's left method given the Vector2
                curGameMap.MapPos = inputMove.Left(bMM);
            }
            //Check if the S key is being pressed
            if (kbState.IsKeyDown(Keys.S))
            {
                //Create a Vector2 object give the current game maps position
                Vector2 bMM = curGameMap.MapPos;
                //chagne the current game mp's position to that of the inputMove's up method given the Vector2
                curGameMap.MapPos = inputMove.Up(bMM);
            }
            //Check if the A key is being pressed
            if (kbState.IsKeyDown(Keys.A))
            {
                //Create a Vector2 object given the current game maps position
                Vector2 bMM = curGameMap.MapPos;
                //change the current game map's positon to that of the inputMove's right method give the Vector2
                curGameMap.MapPos = inputMove.Right(bMM);
            }
            //check if the space key is being pressed
            
            if (kbState.IsKeyDown(Keys.Space)) //Flashlight
            {
                // for future implementation
            }

            //return it
        }


    }
}

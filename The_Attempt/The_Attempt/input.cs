using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace The_Attempt
{
    // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating
    // Handles the input for the Charater's movement.
    public class Input
    {

        KeyboardState kbState = Keyboard.GetState(); // keyboardState object to store the current state of the keyboard
        Movement inputMove = new Movement(3); // movement object to move the map object based on keyboard input
        Vector2 curPositionMap = new Vector2(0, 0); // used for the collision detect
        CollDetect detect = new CollDetect();
        Rectangle instanceOfPlayer = new Rectangle(0,0,0,0);


        public Input(Rectangle player)
        {
            instanceOfPlayer = player;
        }


        /// <summary>
        /// Checks the current state of the keyboard then does selected events based on the keyboard state.
        /// </summary>
        /// <param name="curGameMap">Parameter to store the game's map.</param>
        public void Check(Map curGameMap)
        {


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

                // calls CollDectec.detect( argument either u,d,l or r (one of these), curGameMap.x, curGameMap.y) returning a bool to see if its colliding with a corridor
                curPositionMap = detect.FindLocation(instanceOfPlayer, curGameMap);
                detect.corridorCheck(curPositionMap, instanceOfPlayer, curGameMap.MapPos, 'U');
            }
            // check if the D key is being pressed
            if (kbState.IsKeyDown(Keys.D))
            {
                // change the current game map's position by updating the X position of it's Rectangle in the right direction
                curGameMap.X = inputMove.Right(curGameMap.MapPos);


                curPositionMap = detect.FindLocation(instanceOfPlayer, curGameMap);
                detect.corridorCheck(curPositionMap, instanceOfPlayer, curGameMap.MapPos, 'R');
            }
            // check if the S key is being pressed
            if (kbState.IsKeyDown(Keys.S))
            {
                // change the current game map's position by updating the Y position of it's Rectangle in the vertically downward direction
                curGameMap.Y = inputMove.Down(curGameMap.MapPos);


                curPositionMap = detect.FindLocation(instanceOfPlayer, curGameMap);
                detect.corridorCheck(curPositionMap, instanceOfPlayer, curGameMap.MapPos, 'D');
            }
            // check if the A key is being pressed
            if (kbState.IsKeyDown(Keys.A))
            {
                // change the current game map's position by updating the X position of it's Rectangle in the left direction
                curGameMap.X = inputMove.Left(curGameMap.MapPos);


                curPositionMap = detect.FindLocation(instanceOfPlayer, curGameMap);
                detect.corridorCheck(curPositionMap, instanceOfPlayer, curGameMap.MapPos, 'L');
            }
            // check if the space key is being pressed
            
            if (kbState.IsKeyDown(Keys.Space)) //Flashlight
            {
                // for future implementation
            }
        }
    }
}

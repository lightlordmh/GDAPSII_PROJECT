using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace The_Attempt
{
    public class Input
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curGameMap">Parameter to store the game's map</param>
        public void Check(Map curGameMap) //current game map
        {
            KeyboardState kbState;
            kbState = Keyboard.GetState();

            //Movement object
            Movement inputMove = new Movement();


            //Each key that we might use
            if (kbState.IsKeyDown(Keys.LeftShift)) //Running if we have it
            {
                inputMove.Scale = 1.3F;
            }
            if (kbState.IsKeyDown(Keys.W))
            {
               Vector2 bMM = curGameMap.MapPos;
               curGameMap.MapPos = inputMove.Down(bMM);
            }
            if (kbState.IsKeyDown(Keys.D))
            {
                Vector2 bMM = curGameMap.MapPos;
                curGameMap.MapPos = inputMove.Left(bMM);
            }
            if (kbState.IsKeyDown(Keys.S))
            {
                Vector2 bMM = curGameMap.MapPos;
                curGameMap.MapPos = inputMove.Up(bMM);
            }
            if (kbState.IsKeyDown(Keys.A))
            {
                Vector2 bMM = curGameMap.MapPos;
                curGameMap.MapPos = inputMove.Right(bMM);
            }
            if (kbState.IsKeyDown(Keys.Space)) //Flashlight
            {

            }

            //return it
        }


    }
}

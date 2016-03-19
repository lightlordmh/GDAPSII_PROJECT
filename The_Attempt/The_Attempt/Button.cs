using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace The_Attempt
{
    //Israel Anthony
    //Russell Swartz
    //Evan Keating
    //Kyle Vanderwiel
    //Handles UI buttons in the menus 
    //This class has not been implemented in the game yet
    class Button
    {
        //Attributes
        Texture2D texture;// the button's texture
        Rectangle rect; // the button's bounding rectangle
        Rectangle mouseRect; // the bounding rectangle for the mouse
        bool click; // store the click state of the button

        //Properties
        public Rectangle Rect { get { return rect; } set { rect = value; } } // property to allow access to the buttons bounding rectangle.
        public int X { get { return rect.X; } set { rect.X = value; } } // property to allow access to the buttons X position
        public int Y { get { return rect.Y; } set { rect.Y = value; } } // property to allow access to the buttons Y position
        public int Width { get { return rect.Width; } set { rect.Width = value; } } // property to allow access to buttons Width
        public int Height { get { return rect.Height;  } set { rect.Height = value; } } // property to allow access to the buttons Height
        public Texture2D Texture { get { return texture; } set { texture = value; } } // property to allow access to the buttons texture
        public bool Click { get { return click; } set { click = value; } } // property to allow access to the buttons click event

        //Constructor
        /// <summary>
        /// Takes X and Y Position, Width and Height, and Texture
        /// </summary>
        /// <param name="x">X Position</param>
        /// <param name="y">Y Position</param>
        /// <param name="w">Width</param>
        /// <param name="h">Height</param>
        /// <param name="tx">Texture2D</param>
        public Button(int x, int y, int w, int h, Texture2D tx)
        {
            click = false; // set the default click state as false / not clicked
            texture = tx; // set the button's texture to the parameter
            rect = new Rectangle(x, y, w, h); // setup the buttons bounding rectangle with given x,y,width,and height parameters
        }

        //Button Click Event
        /// <summary>
        /// Takes a MouseState 
        /// returns true if the mouse clicked the button else false
        /// </summary>
        /// <param name="mouse">mouse</param>
        /// <returns></returns>
        public bool ClickUpdate(MouseState mouse)
        {
            //create a bounding rectangle for the mouse with the given the mouse's position
            mouseRect = new Rectangle(mouse.X, mouse.Y, 5, 5);
            //if the mouse's bounding rectangle intersects with the button's bounding rectangle
            if (mouseRect.Intersects(rect))
            {
                //if the mouse's left mouse button is being pressed
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    click = true; //set the button click state to true / clicked
                    return true; // return true / return that the button is being clicked
                }
                else
                {
                    click = false; // set the button click state to false / not clicked
                    return false; // return false / return that the button is not being clicked
                }
            }
            else { return false; }// return false // the button is not being clicked
        }

        //Draw Method
        /// <summary>
        /// Takes at SpriteBatch
        /// draws the button 
        /// </summary>
        /// <param name="spritebatch">SpriteBatch</param>
        public virtual void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture,rect,Color.White); // draw the button's bounding rectangle with a given texture and with a white color

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace The_Attempt
{
    // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating
    // Handles UI buttons in the menus 
    // This class will be implemented in the future
    class Button
    {
        // attributes
        SpriteFont font;
        string phrase;
        //exture2D texture;// the button's texture
        Rectangle rect; // the button's bounding rectangle
        Rectangle mouseRect; // the bounding rectangle for the mouse
        bool click; // store the click state of the button

        // properties
        // property to allow access to the buttons bounding rectangle.
        public Rectangle Rect
        {
            get { return rect; }
            set { rect = value; }
        } 
        // property to allow access to the buttons X position
        public int X
        {
            get { return rect.X; }
            set { rect.X = value; }
        } 
        // property to allow access to the buttons Y position
        public int Y
        {
            get { return rect.Y; }
            set { rect.Y = value; }
        } 
        // property to allow access to buttons Width
        public int Width
        {
            get { return rect.Width; }
            set { rect.Width = value; }
        } 
        // property to allow access to the buttons Height
        public int Height
        {
            get { return rect.Height; }
            set { rect.Height = value; }
        } 
        // property to allow access to the buttons texture
        public string Phrase
        {
            get { return phrase; }
            set { phrase = value; }
        } 
        // property to allow access to the buttons click event
        public bool Click
        {
            get { return click; }
            set { click = value; }
        } 

        public SpriteFont Font
        {
            get { return font; }
            set { font = value; }
        }

        /// <summary>
        /// Constructs a button with an X and Y Position, width and height, and Texture2D.
        /// </summary>
        /// <param name="xPos">The X coordinate of the top left point of the Rectangle.</param>
        /// <param name="yPos">The Y coordinate of the top left point of the Rectangle.</param>
        /// <param name="width">The width dimension of the Rectangle.</param>
        /// <param name="height">The height dimension of the Rectangle.</param>
        /// <param name="tx">Texture2D that the button uses for drawing.</param>
        public Button(int xPos, int yPos, int width, int height, string str,SpriteFont inFont)
        {
            click = false; // set the default click state as false
            Font = inFont;
            //texture = tx; 
            rect = new Rectangle(xPos, yPos, width, height); 
        }

        // button Click Event
        /// <summary>
        /// Takes a MouseState and processes it.
        /// </summary>
        /// <param name="mouse">MouseState that carries information about what has been clicked.</param>
        /// <returns>Returns true when a button is clicked. Otherwise returns false.</returns>
        public bool ClickUpdate(MouseState mouse)
        {
            // create a bounding rectangle for the mouse with the given mouse's position
            mouseRect = new Rectangle(mouse.X, mouse.Y, 5, 5);

            // if the mouse's bounding rectangle intersects with the button's bounding rectangle
            if (mouseRect.Intersects(rect))
            {
                // if the mouse's left mouse button is being pressed
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    click = true; // set the button click state to true
                    return true; 
                }
                else
                {
                    click = false; // set the button click state to false 
                    return false; 
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Takes at SpriteBatch and draws the button.
        /// </summary>
        /// <param name="spritebatch">SpriteBatch</param>
        public virtual void Draw(SpriteBatch spritebatch)
        {
            //spritebatch.DrawString(Font,Phrase,rect,Color.White); // draw the button's bounding rectangle with a given texture
        }
    }
}

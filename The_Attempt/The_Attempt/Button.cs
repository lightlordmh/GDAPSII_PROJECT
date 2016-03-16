using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace The_Attempt
{
    class Button
    {
        //Attributes
        Texture2D texture;
        Rectangle rect;
        Rectangle mouseRect;
        bool click;

        //Properties
        public Rectangle Rect { get { return rect; } set { rect = value; } }
        public int X { get { return rect.X; } set { rect.X = value; } }
        public int Y { get { return rect.Y; } set { rect.Y = value; } }
        public int Width { get { return rect.Width; } set { rect.Width = value; } }
        public int Height { get { return rect.Height;  } set { rect.Height = value; } }
        public Texture2D Texture { get { return texture; } set { texture = value; } }
        public bool Click { get { return click; } set { click = value; } }

        //Constructor
        public Button(int x, int y, int w, int h, Texture2D tx)
        {
            click = false;
            texture = tx;
            rect = new Rectangle(x, y, w, h);
        }

        //Button Click Event
        public bool ClickUpdate(MouseState mouse)
        {
            mouseRect = new Rectangle(mouse.X, mouse.Y, 5, 5);
            if (mouseRect.Intersects(rect))
            {
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    click = true;
                    return true;
                }
                else
                {
                    click = false;
                    return false;
                }
            }
            else { return false; }
        }

        //Draw Method
        public virtual void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture,rect,Color.White);

        }
    }
}

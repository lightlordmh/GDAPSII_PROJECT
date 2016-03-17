using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace The_Attempt
{
    public class Movement
    {
        //acts as differnce in speed
        private float scale = 1;



        //for changing the scale
        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public Vector2 Left(Vector2 i)
        {
            Vector2 afterM = new Vector2(i.X - (1 * scale), i.Y);
            return afterM;
        }
        public Vector2 Right(Vector2 i)
        {
            Vector2 afterM = new Vector2(i.X + (1 * scale), i.Y);
            return afterM;
        }


        public Vector2 Up(Vector2 i)
        {
            Vector2 afterM = new Vector2(i.X, i.Y - (1 * scale));
            return afterM;
        }
        public Vector2 Down(Vector2 i)
        {
            Vector2 afterM = new Vector2(i.X, i.Y + (1 * scale));
            return afterM;
        }
    }
}

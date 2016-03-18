using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace The_Attempt
{
    public class Movement
    {
        //Attribute
        //acts as differnce in speed
        private float scale = 3;
        
        //Property
        //Allows Access to get and set the scale Attribute
        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }
        /// <summary>
        /// does a caluculation to move the vector2 left 
        /// </summary>
        /// <param name="i">Input Vector2 object for left Movement calculation</param>
        /// <returns>A Vector2 with a new position based on the calculations made</returns>
        public Vector2 Left(Vector2 i)
        {
            //Create a Vector2 object with a postions that moves the parameter Vector2 left
            Vector2 afterM = new Vector2(i.X - (1 * scale), i.Y);
            //return the Vector2 with the new postion
            return afterM;
        }
        /// <summary>
        /// does a caluculation to move the vector2 right 
        /// </summary>
        /// <param name="i">Input Vector2 object for right Movement calculation</param>
        /// <returns>A Vector2 with a new position based on the calculations made</returns>
        public Vector2 Right(Vector2 i)
        {
            //Create a Vector2 object with a postions that moves the parameter Vector2 right
            Vector2 afterM = new Vector2(i.X + (1 * scale), i.Y);
            //return the Vector2 with the new postion
            return afterM;
        }
        /// <summary>
        /// does a caluculation to move the vector2 up 
        /// </summary>
        /// <param name="i">Input Vector2 object for up Movement calculation</param>
        /// <returns>A Vector2 with a new position based on the calculations made</returns>
        public Vector2 Up(Vector2 i)
        {
            //Create a Vector2 object with a postions that moves the parameter Vector2 up
            Vector2 afterM = new Vector2(i.X, i.Y - (1 * scale));
            //return the Vector2 with the new postion
            return afterM;
        }
        /// <summary>
        /// does a caluculation to move the vector2 down
        /// </summary>
        /// <param name="i">Input Vector2 object for down Movement calculation</param>
        /// <returns>A Vector2 with a new position based on the calculations made</returns>
        public Vector2 Down(Vector2 i)
        {
            //Create a Vector2 object with a postions that moves the parameter Vector2 down
            Vector2 afterM = new Vector2(i.X, i.Y + (1 * scale));
            //return the Vector2 with the new postion
            return afterM;
        }
    }
}

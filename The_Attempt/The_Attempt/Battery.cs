using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace The_Attempt
{
    // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating   
    // This class allows the player to recharge their cellphone upon collision.
    // ***** STRETCH GOAL CLASS ***** 
    public class Battery:Collectible
    {
        /// <summary>
        /// Constructs a Battery object and places it in a Rectangle defined by the parameters that are passed in.
        /// </summary>
        /// <param name="xPos">The X coordinate of the top left point of the Rectangle.</param>
        /// <param name="yPos">The Y coordinate of the top left point of the Rectangle.</param>
        /// <param name="width">The width dimension of the Rectangle.</param>
        /// <param name="height">The height dimension of the Rectangle.</param>
        public Battery(int xPos, int yPos, int width, int height) : base(xPos, yPos, width, height)
        {
            
        }
    }
}

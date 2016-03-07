using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace The_Attempt
{
    public class Map
    {
        private Vector2 mapPlace = new Vector2(10, 10);         //PH   placeholder placement

        public Vector2 MapPlace
        {
            get { return mapPlace; }
            set { mapPlace = value; }
        }

    }
}

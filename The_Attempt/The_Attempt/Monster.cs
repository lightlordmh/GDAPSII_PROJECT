using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace The_Attempt
{
    public class Monster:GameObject
    {
        // attribute
        private int creepSpeed; // the speed at which the monster moves while not in pursuit mode
        private int rushSpeed; // the speed at which the monster moves while in pursuit mode

        // property
        public int CreepSpeed
        {
            get { return creepSpeed; }
            set { creepSpeed = value; }
        }
        public int RushSpeed
        {
            get { return rushSpeed; }
            set { rushSpeed = value; }
        }

        // constructor
        public Monster(int posX, int posY, int width, int height, int cSpeed, int rSpeed):base(posX,posY,width,height)
        {
            cSpeed = creepSpeed;
            rSpeed = rushSpeed;
        }
    }
}

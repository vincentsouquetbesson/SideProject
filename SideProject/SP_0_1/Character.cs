using System;
using System.Collections.Generic;
using System.Text;

namespace SP_0_1
{
    class Character
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int MovePoint { get; set; }

        public Character(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
            MovePoint = 4;
        }

        /*
        public int getPositionX()
        {
            return positionX;
        }

        public int getPositionY()
        {
            return positionY;
        }
        */

        public void move()
        {

        }
        /*
        public int getMovePoint()
        {
            return movePoint;
        }
    */

    }
}

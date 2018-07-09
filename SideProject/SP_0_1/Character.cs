using System;
using System.Collections.Generic;
using System.Text;

namespace SP_0_1
{
    class Character
    {
        private int positionX;
        private int positionY;

        public Character(int positionX, int positionY)
        {
            this.positionX = positionX;
            this.positionY = positionY;
        }


        public int getPositionX()
        {
            return positionX;
        }

        public int getPositionY()
        {
            return positionY;
        }
    }
}

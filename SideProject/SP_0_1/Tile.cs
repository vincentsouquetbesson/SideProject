using System;
using System.Collections.Generic;
using System.Text;

namespace SP_0_1
{
    class Tile
    {
        private int type;
        private double high;
        private Character character;



        public Tile(int type, double high)
        {
            this.type = type;
            this.high = high;
            character = null;
        }

        public double getType()
        {
            return type;
        }

        public void setHigh(double high)
        {
            this.high = high;
        }

        public double getHigh()
        {
            return high;
        }

        public void characterOnTile(Character character)
        {
            this.character = character;
        }

        public void characterLeave()
        {
            character = null;

        }

        public Boolean charOnTile()
        {
            if (character == null)
                return false;
            else
                return true;

        }
    }
}

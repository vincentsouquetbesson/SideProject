using System;
using System.Collections.Generic;
using System.Text;

namespace SP_0_1
{
    class Tile
    {
        public int Type { get; set; }
        public double High { get; set; }
        public Character Piece { get; set; }
        public Boolean MovePossible { get; set; }



        public Tile(int type, double high)
        {
            Type = type;
            High = high;
            Piece = null;
            MovePossible = false;
        }


        public void characterLeave()
        {
            Piece = null;

        }

        public Boolean charOnTile()
        {
            if (Piece == null)
                return false;
            else
                return true;

        }



    }
}

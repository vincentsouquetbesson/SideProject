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
        public int MovePossible { get; set; }

        public double DirNorth { get; set; }
        public double DirSouth { get; set; }
        public double DirEast { get; set; }
        public double DirWest { get; set; }

        public Tile(int type, double high)
        {
            Type = type;
            High = high;
            Piece = null;
            MovePossible = 300;
        }


        public void characterLeave()
        {
            Piece = null;
        }


        public int CharOnTile()
        {
            if (Piece == null)
                return 0;
            else
            {
                if (Piece.Team == 2)
                {
                    return 2;
                }
                else
                    return 1;
            }
        }



    }
}
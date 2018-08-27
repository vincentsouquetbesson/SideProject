using System;
using System.Collections.Generic;
using System.Text;

namespace SP_0_1
{
    class Tile
    {
        public int Type { get; set; } //0.Existe pas  1.classique 2.eau 3.lave
        public double High { get; set; }
        public Character Piece { get; set; }
        public int MovePossible { get; set; }
        public int AttackPossible { get; set; }
        public String Path { get; set; }

        public double DirNorth { get; set; }
        public double DirSouth { get; set; }
        public double DirEast { get; set; }
        public double DirWest { get; set; }

        public Dictionary<string, int> CastList;

        public Boolean LigneOfSight { get; set; }

        public Tile(int type, double high)
        {
            Type = type;
            High = high;
            Piece = null;
            MovePossible = 300;  //300 == incorect
            AttackPossible = 300;
            CastList = new Dictionary<string, int>();
            CastList.Add("a", 0);
        }



        public Tile(double high)
        {
            Type = 1;
            High = high;
            Piece = null;
            MovePossible = 300;  //300 == incorect


            CastList = new Dictionary<string, int>();
            CastList.Add("a", 0);
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
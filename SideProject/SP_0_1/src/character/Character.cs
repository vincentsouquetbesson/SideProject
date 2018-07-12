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
        public int Team { get; set; } // 1.ally 2.foe 3.Pnj
        public String PieceName { get; set; }

        public Character(String pieceName,int positionX, int positionY, int team)
        {
            PieceName = pieceName;
            PositionX = positionX;
            PositionY = positionY;
            Team = team;
            MovePoint = 4;
        }



        public void move()
        {

        }

    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace SP_0_1
{
    class FOE : Character
    {


        public Nael BossType;


        public Boolean Boss; //false. sbire  true. Boss

        public FOE( String name, int positionX, int positionY)
        {
            Name = name;
            PositionX = positionX;
            PositionY = positionY;
            Team = 2; //foe
            MovePoint = 4;
            Boss =  false;
        }


        public FOE(String name, int positionX, int positionY, Board fightingBoard)
        {
            Name = name;
            PositionX = positionX;
            PositionY = positionY;
            Team = 2; //foe
            MovePoint = 4;
            if (Boss == true)
            {
                BossType = new Nael(fightingBoard);
            }
        }

    }
}

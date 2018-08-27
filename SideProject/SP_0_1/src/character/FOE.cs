using System;
using System.Collections.Generic;
using System.Text;

namespace SP_0_1
{
    class FOE : Character
    {
        public Board FightingBoard;

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
                //Console.WriteLine("New BOSS");
                BossType = new Nael(fightingBoard);
            }
        }


        public FOE(String name, Boolean boss, int positionX, int positionY)
        {
            Name = name;
            PositionX = positionX;
            PositionY = positionY;
            Team = 2; //foe
            MovePoint = 4;
            Boss = boss;
            if (Boss == true)
            {
                Console.WriteLine("New BOSS");
                BossType = new Nael();
            }
        }


        override
        public void setBoard(Board fightingBoard)
        {
            FightingBoard = fightingBoard;
            Console.WriteLine("BHHHHHH");
            if (Boss == true)
            {
                Console.WriteLine("AHHHHHH");
                BossType.FightingBoard = FightingBoard;
            }
        }


        public override void Attack()
        {
            Console.WriteLine("FOE "+Name + " attack");
            if ( Boss == true)
            {
                Console.WriteLine("FOE ");
                BossType.attack();
            }
            else
            {

            }
        }

    }
}

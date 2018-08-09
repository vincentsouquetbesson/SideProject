using System;
using System.Collections.Generic;
using System.Text;

namespace SP_0_1
{
    class Nael
    {
        public Boolean cast = false;
        public Board FightingBoard;

        private static int Phase;

        public Nael(Board fightingBoard)
        {
            FightingBoard = fightingBoard;
            Phase = 0;
        }

        public Nael()
        {
            Phase = 0;
        }



        public void attack()
        {
            if(Phase == 0){
                heavenFall();
            }
            if(Phase == 1)
            {
                PillarExplosion();
            }
               
        }

        public void griffe()
        {

        }



        public void heavenFall()
        {
            if (cast == false) //Si l'attaque n'a pas été lancé
            {
                Console.WriteLine("Heaven's Fall cast");
                int mid = FightingBoard.Height / 2 ;
                cast = true;
                FightingBoard.CreateAOE("heavenFall", 2, mid, mid,"ALL");
                
            }
            else //tour suivant
            {
                Console.WriteLine("Heaven's Fall burn");
                FightingBoard.UpdateAOE("heavenFall", 9999, 3);
                Phase++;
                cast = false;
            }
            Console.WriteLine("GO");
        }


        public void PillarExplosion()
        {
            if (cast == false) //Si l'attaque n'a pas été lancé
            {
                Console.WriteLine("Pillar Explosion cast");
                int mid = FightingBoard.Height / 2;
                cast = true;
                FightingBoard.CreateAOE("pillarExplosion", 9, mid, mid, "NE");
                FightingBoard.CreateAOE("pillarExplosion", 9, mid, mid, "SW");
                //FightingBoard.CreateAOE("pillarExplosion", 9, mid, mid, "SE");
            }
        }






    }
}

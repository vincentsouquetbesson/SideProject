using System;
using System.Collections.Generic;
using System.Text;

namespace SP_0_1
{
    class Nael
    {
        public Boolean cast = false;
        public Board FightingBoard;

        public Nael(Board fightingBoard)
        {
            FightingBoard = fightingBoard;
        }

        public void griffe()
        {

        }



        public void heavenFall()
        {
            if (cast == false) //Si l'attaque n'a pas été lancé
            {
                cast = true;
                for (int m = 0; m < 2; m++)
                {
                    for (int i = 0; i < FightingBoard.Height; i++) // On parcourt les Y
                    {
                        for (int j = 0; j < FightingBoard.Width; j++) //On parcourt les X
                        {

                        }
                    }
                }
            }
            else //tour suivant
            {

            }

        }


    }
}

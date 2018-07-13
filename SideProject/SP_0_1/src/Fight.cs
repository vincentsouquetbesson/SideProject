using System;
using System.Collections.Generic;
using System.Text;

namespace SP_0_1
{
    class Fight
    {

        Board FightingBoard;
        List<Character> CharacterList;


        public Fight()
        {
            FightingBoard = new Board();
            CharacterList = new List<Character>();
            
            CharacterList.Add(new Character("hero1",9, 9, 1)); //HERO
            CharacterList.Add(new Character("hero2", 1, 1, 1)); //HERO
            CharacterList.Add(new Character("gobelin",4, 4, 2)); //FOE

            foreach (Character c in CharacterList)
            {
                FightingBoard.UpdatePositionCharacter(c);
            }
        }


        public void playFightLIDL()
        {
            ConsoleMVS ConsoleMVSO = new ConsoleMVS(FightingBoard);   //A SUPRIMER
            ConsoleMVSO.ShowBoard();

            ConsoleMVSO.ShowBoardHigh();


            FightingBoard.UpdatePositionCharacter(CharacterList[0]);
            FightingBoard.UpdatePositionCharacter(CharacterList[1]);
            Console.WriteLine("Depart");
            ConsoleMVSO.showMovePossible();


            Console.WriteLine("Move POSSIBLE");
            FightingBoard.UpdateMovePossible(CharacterList[0]);
            ConsoleMVSO.showMovePossible();
            ConsoleMVSO.ShowBoardHigh();

            Console.WriteLine("DEPLACEMENT");
            FightingBoard.MoveCharacter(CharacterList[0], 2, 2);
            FightingBoard.UpdateMovePossible(CharacterList[0]);
            ConsoleMVSO.showMovePossible();
        }



        public void playFight()
        {
            ConsoleMVS ConsoleMVSO = new ConsoleMVS(FightingBoard);   //A SUPRIMER
            ConsoleMVSO.ShowBoardHigh();
            Console.WriteLine("ARRIVER");
            foreach (Character c in CharacterList)
            {
                Console.WriteLine("Depart");
                FightingBoard.UpdateMovePossible(c);
                ConsoleMVSO.showMovePossible();
                FightingBoard.MoveCharacter(c, c.PositionX +1, c.PositionY );
                Console.WriteLine("ARRIVER");
                FightingBoard.UpdateMovePossible(c);
                ConsoleMVSO.showMovePossible();
            }
            FightingBoard.UpdateBowAttackPossible(CharacterList[2]);
            ConsoleMVSO.showAttackPossible();
            
        }








    }
}

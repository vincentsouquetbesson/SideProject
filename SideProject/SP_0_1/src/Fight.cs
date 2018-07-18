using System;
using System.Collections.Generic;
using System.Text;

namespace SP_0_1
{
    class Fight
    {

        Board FightingBoard;

        List<Character> CharactersTurnList;


        public Fight( List<Character>heroList)
        {
            FightingBoard = new Board();
            List<Character> CharacterList = new List<Character>();

            ChooseCharacterPosition(heroList); 

            CharacterList = new List<Character>( heroList );
           // CharacterList = heroList;   //On copie la liste des hero dans la liste du combat

            //INITIATIVE



            CharacterList.Add(new Character("gobelin",4, 4, 2)); //FOE
            CharacterList[2].InitBaseStat(5, 7, 7, 15);

            foreach (Character c in CharacterList)
            {
                FightingBoard.UpdatePositionCharacter(c);
                c.Counter = 0;
            }
            createTurn(CharacterList);

        }


        public void ChooseCharacterPosition(List<Character> heroList)
        {
            heroList[0].move(1, 1);
            heroList[1].move(9, 8);
        }


        public void playFightLIDL()
        {
            ConsoleMVS ConsoleMVSO = new ConsoleMVS(FightingBoard);   //A SUPRIMER
            ConsoleMVSO.ShowBoard();

            ConsoleMVSO.ShowBoardHigh();


            FightingBoard.UpdatePositionCharacter(CharactersTurnList[0]);
            FightingBoard.UpdatePositionCharacter(CharactersTurnList[1]);
            Console.WriteLine("Depart");
            ConsoleMVSO.showMovePossible();


            Console.WriteLine("Move POSSIBLE");
            FightingBoard.UpdateMovePossible(CharactersTurnList[0]);
            ConsoleMVSO.showMovePossible();
            ConsoleMVSO.ShowBoardHigh();

            Console.WriteLine("DEPLACEMENT");
            FightingBoard.MoveCharacter(CharactersTurnList[0], 2, 2);
            FightingBoard.UpdateMovePossible(CharactersTurnList[0]);
            ConsoleMVSO.showMovePossible();
        }



        public void playFight()
        {
            ConsoleMVS ConsoleMVSO = new ConsoleMVS(FightingBoard);   //A SUPRIMER
            ConsoleMVSO.ShowTurn(CharactersTurnList);
            ConsoleMVSO.ShowBoardHigh();
            Console.WriteLine("ARRIVER");
            foreach (Character c in CharactersTurnList)
            {
                Console.WriteLine("Depart "+ c.Name+" "+c.PositionX + " " + c.PositionY);
                FightingBoard.UpdateMovePossible(c);
                ConsoleMVSO.showMovePossible();
                FightingBoard.MoveCharacter(c, c.PositionX +1, c.PositionY );
                Console.WriteLine("ARRIVER");
                FightingBoard.UpdateMovePossible(c);
                ConsoleMVSO.showMovePossible();
            }
            FightingBoard.UpdateBowAttackPossible(CharactersTurnList[2]);
            ConsoleMVSO.showAttackPossible();
            
        }




        public void createTurn(List<Character> charactersList)
        {
            int nbTurn = 0;
            CharactersTurnList = new List<Character>();
            List<Character> charactersBufferList = new List<Character>();
            while(nbTurn < 10) { 
                foreach (Character c in charactersList)
                {
                    c.Counter += c.Initiative;
                    if (c.Counter >= 100)
                    {
                        c.Counter -= 100;
                        charactersBufferList.Add(c);

                    }
                }
                if (charactersBufferList.Count > 0)
                {
                    if (charactersBufferList.Count == 1)
                    {
                        CharactersTurnList.Add(charactersBufferList[0]);
                        charactersBufferList.RemoveAt(0);
                        nbTurn++;
                    }
                    else
                    {
                        Character characterBuffer = null;
                        while (charactersBufferList.Count != 0)
                        {
                            characterBuffer = charactersBufferList[0];
                            foreach (Character c in charactersBufferList)
                            {
                                if (characterBuffer.Counter < c.Counter)
                                {
                                    characterBuffer = c;
                                }
                            }
                            CharactersTurnList.Add(characterBuffer);
                            charactersBufferList.Remove(characterBuffer);
                            nbTurn++;
                            if (charactersBufferList.Count == 1)
                            {
                                CharactersTurnList.Add(charactersBufferList[0]);
                                charactersBufferList.RemoveAt(0);
                                nbTurn++;
                            }
                        }
                    }
                }
            }

        }








    }
}

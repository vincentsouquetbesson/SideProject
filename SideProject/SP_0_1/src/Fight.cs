using System;
using System.Collections.Generic;
using System.Text;

namespace SP_0_1
{
    class Fight
    {

        Board FightingBoard;

        //List<Character> CharactersTurnList;
        List<Character> CharacterList;
        List<Character> charactersBufferList;


        public Fight( List<Character>heroList)
        {
            FightingBoard = new Board();

            CharacterList = new List<Character>();

            ChooseCharacterPosition(heroList); 

            CharacterList = new List<Character>( heroList );
            // CharacterList = heroList;   //On copie la liste des hero dans la liste du combat

            //INITIATIVE

            
            charactersBufferList = FightingBoard.CharactersBufferList;
            foreach (Character c in charactersBufferList)
            {
                c.InitBaseStat(10,10,10,80,2);
                c.setBoard(FightingBoard);
            }

            CharacterList.AddRange(charactersBufferList);

            //CharacterList.Add(new Character("gobelin",10, 4, 2)); //FOE
            //CharacterList.Add(new Character("gobelin", 10, 4, 2)); //FOE
            //CharacterList[2].InitBaseStat(5, 7, 7, 15,2);

            foreach (Character c in CharacterList)
            {
                FightingBoard.UpdatePositionCharacter(c);
                c.Counter = 0;
            }
            //SetTurn(CharacterList);
            
        }


        public void ChooseCharacterPosition(List<Character> heroList)
        {
            heroList[0].move(1, 4);
            heroList[1].move(5, 4);
        }

/*
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
*/

        /*
        public void PlayFight()
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
        */



        public void PlayFight()
        {
            ConsoleMVS ConsoleMVSO = new ConsoleMVS(FightingBoard);   //A SUPRIMER
            // ConsoleMVSO.ShowTurn(CharactersTurnList);
            Console.WriteLine("HIGH");
            ConsoleMVSO.ShowBoardHigh();
            Console.WriteLine("TYPE");
            ConsoleMVSO.ShowBoardType();

            Character c;

            for (int i = 0; i < 5;i++)
            {
                c = NextTurn();
                Console.WriteLine("Depart " + c.Name + " " + c.PositionX + " " + c.PositionY);
                FightingBoard.UpdateMovePossible(c);
                ConsoleMVSO.showMovePossible();
                FightingBoard.MoveCharacter(c, c.PositionX + 1, c.PositionY);
                Console.WriteLine("ARRIVER");
                FightingBoard.UpdateMovePossible(c);
                ConsoleMVSO.showMovePossible();
                c.Attack();
            }

            Console.WriteLine("TYPE");
            ConsoleMVSO.showBossAttack();

            //    FightingBoard.UpdateBowAttackPossible( c );
            //    ConsoleMVSO.showAttackPossible();

        }







        /*
                public void SetTurn(List<Character> charactersList)
                {
                    int nbTurn = 0;
                    CharactersTurnList = new List<Character>();
                    List<Character> charactersBufferList = new List<Character>();
                    while(nbTurn < 10) { 
                        foreach (Character c in charactersList)
                        {
                            c.Counter += c.Initiative;
                            if (c.Counter >= c.GoalCounter)
                            {
                                c.Counter -= c.GoalCounter;
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
                */

        public Character NextTurn()
        {
           // CharactersTurnList = new List<Character>();
            if(charactersBufferList.Count > 0)  //si il reste des perso dans le buffer
            {
                return getNextcharacter();
            }
            while (true)
            {
                foreach (Character c in CharacterList)
                {
                    c.Counter += c.Initiative;
                    if (c.Counter >= c.GoalCounter)
                    { 
                        c.Counter -= c.GoalCounter;
                        charactersBufferList.Add(c);

                    }
                }
                if (charactersBufferList.Count > 0)
                {
                    return getNextcharacter();
                }
            }
            return null;
        }


        public Character getNextcharacter()
        {
            Character characterBuffer;
            if (charactersBufferList.Count == 1) //Si il reste uniquement un perso dans le buffer
            {
                characterBuffer = charactersBufferList[0];
                charactersBufferList.Remove(characterBuffer);
                return characterBuffer;
            }
            else
            {
                characterBuffer = charactersBufferList[0];
                foreach (Character c in charactersBufferList)
                {
                    if (characterBuffer.Counter < c.Counter)
                    {
                        characterBuffer = c;
                    }
                }
                charactersBufferList.Remove(characterBuffer);
                return characterBuffer;
            }
        }










    }
}

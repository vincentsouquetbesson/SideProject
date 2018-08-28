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
        Turn Turns;


        public Fight( List<Character>heroList)
        {
            FightingBoard = new Board();

            CharacterList = new List<Character>();

            ChooseCharacterPosition(heroList); 

            CharacterList = new List<Character>( heroList );
            // CharacterList = heroList;   //On copie la liste des hero dans la liste du combat

            //INITIALISATION NULL DE TOUTE LES UNITE
            charactersBufferList = FightingBoard.CharactersBufferList;
            foreach (Character c in charactersBufferList)
            {
                c.InitBaseStat(10,10,10,80,4);
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


            Turns = new Turn(CharacterList);


            
        }


        public void ChooseCharacterPosition(List<Character> heroList)
        {
            heroList[0].move(1, 4);
            heroList[1].move(5, 4);
        }



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
                c = Turns.NextTurn();
                Console.WriteLine("Depart " + c.Name + " " + c.PositionX + " " + c.PositionY +"    m" + c.MovePoint);
                FightingBoard.UpdateMovePossible(c);
                ConsoleMVSO.showMovePossible();
                if(FightingBoard.CheckMoveCharacter( c.PositionX + 1, c.PositionY + 3))
                {
                    FightingBoard.GetPath( c.PositionX + 1, c.PositionY + 3 );
                    ConsoleMVSO.showMovePossible();

                    FightingBoard.MoveCharacter(c,c.PositionX + 1, c.PositionY + 3);
                    Console.WriteLine("ARRIVER");
                    FightingBoard.UpdateMovePossible(c);
                    ConsoleMVSO.showMovePossible();
                    c.Attack();
                }
                else
                {
                    Console.WriteLine("COORDONE FAUSSE");
                }

                
            }

            Console.WriteLine("TYPE");
            ConsoleMVSO.showBossAttack();

            //    FightingBoard.UpdateBowAttackPossible( c );
            //    ConsoleMVSO.showAttackPossible();

        }




    }
}

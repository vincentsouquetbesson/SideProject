using System;

namespace SP_0_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            ConsoleMVS ConsoleMVSO = new ConsoleMVS(board);
            ConsoleMVSO.ShowBoard();

            ConsoleMVSO.ShowBoardHigh();


            Character hero = new Character(5, 3, 1);
            Character foe = new Character(4, 4, 2);

            board.UpdatePositionCharacter(hero);
            board.UpdatePositionCharacter(foe);
            Console.WriteLine("Depart");
            ConsoleMVSO.showMovePossible();


            Console.WriteLine("Move POSSIBLE");
            board.UpdateMovePossible(hero);
            ConsoleMVSO.showMovePossible();
            ConsoleMVSO.ShowBoardHigh();

            Console.WriteLine("DEPLACEMENT");
            board.MoveCharacter(hero, 2, 2);
            board.UpdateMovePossible(hero);
            ConsoleMVSO.showMovePossible();

            string saisie = Console.ReadLine();

        }
    }
}
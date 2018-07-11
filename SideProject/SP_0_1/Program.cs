using System;

namespace SP_0_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.ShowBoard();

            board.ShowBoardHigh();


            Character hero = new Character(5, 3, 1);
            Character foe = new Character(4, 4, 2);

            board.UpdatePositionCharacter(hero);
            board.UpdatePositionCharacter(foe);
            //  board.ShowBoard();
            Console.WriteLine("Depart");
            board.showDeplacementPossible();


            Console.WriteLine("DEPLACEMENT");
            board.UpdateMovePossible(hero);
            board.showDeplacementPossible();
            board.ShowBoardHigh();


            string saisie = Console.ReadLine();

        }
    }
}
using System;

namespace SP_0_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.showBoard();

            board.showBoardHigh();


            Character char1 = new Character(5, 3);

            board.updatePositionCharacter(char1);
            board.showBoard();
            Console.WriteLine("DEPLACEMENT");
            board.showDeplacementPossible();
            board.updateMovePossible(char1);
            Console.WriteLine("DEPLACEMENT");
            board.showDeplacementPossible();
            board.showBoardHigh();


            string saisie = Console.ReadLine();
            
        }
    }
}

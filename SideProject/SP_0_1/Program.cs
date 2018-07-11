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


            Character char1 = new Character(5, 3);

              board.UpdatePositionCharacter(char1);
            //  board.ShowBoard();
            Console.WriteLine("Depart");
            board.showDeplacementPossible();

            
            Console.WriteLine("DEPLACEMENT");
            board.UpdateMovePossible(char1);
            board.showDeplacementPossible();
            board.ShowBoardHigh();


            string saisie = Console.ReadLine();
            
        }
    }
}

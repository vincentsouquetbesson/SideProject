using System;
using System.Collections.Generic;
using System.Text;

namespace SP_0_1
{
    class ConsoleMVS
    {
        private Board Board;
        public ConsoleMVS(Board board)
        {
            Board = board;
        }




        public void ShowBoard()
        {
            List<List<Tile>> rowList = Board.getRowList();
            foreach (List<Tile> list in rowList)
            {
                foreach (Tile tile in list)
                {
                    if (tile.CharOnTile() == 0)
                    {
                        Console.Write("[ ]");
                    }
                    else
                    {
                        if (tile.CharOnTile() == 1)
                            Console.Write("[O]");
                        else
                            Console.Write("[X]");
                    }
                }
                Console.Write("\n");
            }
        }


        public void ShowBoardHigh()
        {
            List<List<Tile>> rowList = Board.getRowList();
            foreach (List<Tile> list in rowList)  //AFFICHAGE COLLONE
            {
                foreach (Tile tile in list)    //AFFICHAGE LIGNE
                {
                    Console.Write(tile.High + " ");
                }
                Console.Write("\n");
            }
        }



        public void showMovePossible()
        {
            List<List<Tile>> rowList = Board.getRowList();
            foreach (List<Tile> list in rowList) //X
            {
                foreach (Tile tile in list)   //Y
                {
                    if (tile.CharOnTile() != 0)
                    {
                        if (tile.CharOnTile() == 1)  //A REFAIRE
                            Console.Write("[O]");
                        else
                            Console.Write("[X]");
                    }
                    else
                    {
                        if (tile.MovePossible == 300)
                        {
                            Console.Write("[ ]");
                        }
                        else
                        {
                            Console.Write("["+tile.MovePossible+"]");
                        }
                    }
                }
                Console.Write("\n");
            }
        }





        public void showAttackPossible()
        {
            List<List<Tile>> rowList = Board.getRowList();
            foreach (List<Tile> list in rowList) //X
            {
                foreach (Tile tile in list)   //Y
                {
                    if (tile.CharOnTile() != 0)
                    {
                        if (tile.CharOnTile() == 1)  //A REFAIRE
                            Console.Write("[O]");
                        else
                            Console.Write("[X]");
                    }
                    else
                    {
                        if (tile.AttackPossible == 300)
                        {
                            Console.Write("[ ]");
                        }
                        else
                        {
                            Console.Write("[" + tile.AttackPossible + "]");
                        }
                    }
                }
                Console.Write("\n");
            }
        }





        public void ShowTurn(List<Character> turnList)
        {
            List<List<Tile>> rowList = Board.getRowList();
            foreach (Character c in turnList)
            {
                Console.Write(c.Name+"  ");
            }
            Console.Write("\n");
        }





    }



}

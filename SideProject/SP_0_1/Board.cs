using System;
using System.Collections.Generic;
using System.Text;

namespace SP_0_1
{
    class Board
    {
        private List<List<Tile>> rowList = new List<List<Tile>>();

        public Board()
        {
            createBoard();
        }

        private void createBoard()
        {
            for (int i = 0; i < 10; i++)
            {
                rowList.Add(new List<Tile>());
            }
            foreach (List<Tile> list in rowList)
            {
                for (int i = 0; i < 10; i++)
                {
                    list.Add(new Tile(1, 5));
                }
            }
        }


        public void showBoard()
        {
            foreach (List<Tile> list in rowList)
            {
                foreach (Tile tile in list)
                {
                    if (tile.charOnTile() == false)
                    {
                        Console.Write("[ ]");
                    }
                    else
                    {
                        Console.Write("[*]");
                    }
                }
                Console.Write("\n");
            }
        }



        public void showBoardHigh()
        {
            foreach (List<Tile> list in rowList)
            {
                foreach (Tile tile in list)
                {
                    Console.Write(tile.getHigh() + " ");
                }
                Console.Write("\n");
            }
        }


        public void updatePositionCharacter(Character character)
        {
            rowList[character.getPositionX()][character.getPositionY()].characterOnTile(character);
        }
    }
}

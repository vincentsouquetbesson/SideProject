﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SP_0_1
{
    class Board
    {
        private List<List<Tile>> RowList = new List<List<Tile>>();
        private int SizeBoard;

        public Board()
        {
            SizeBoard = 10;   //always square
            CreateBoard();
            RowList[3][3].High = 2;
            //RowList[4][4].High = 1;
            RowList[5][5].High = 1;
            UpdateDirectionnalField();
            Console.WriteLine(RowList[3][3].DirEast);
        }

        public List<List<Tile>> getRowList()
        {
            return RowList;
        }


        private void CreateBoard()
        {
            for (int i = 0; i < SizeBoard; i++)
            {
                RowList.Add(new List<Tile>());
            }
            foreach (List<Tile> list in RowList)
            {
                for (int i = 0; i < SizeBoard; i++)
                {
                    list.Add(new Tile(1, 5));
                }
            }
        }





        public void UpdatePositionCharacter(Character character)
        {
            RowList[character.PositionY][character.PositionX].Piece = character;
        }




        private void UpdateDirectionnalField()
        {
            for (int i = 0; i < SizeBoard; i++) // On parcourt les Y
            {
                for (int j = 0; j < SizeBoard; j++) //On parcourt les X
                {
                    if (i == 0 || i == SizeBoard - 1)
                    {
                        if (i == 0)
                        {
                            RowList[i][j].DirNorth = 100;
                            RowList[i][j].DirSouth = RowList[i + 1][j].High - RowList[i][j].High;
                        }
                        else
                        {
                            RowList[i][j].DirSouth = 100;
                            RowList[i][j].DirNorth = RowList[i - 1][j].High - RowList[i][j].High;
                        }
                    }
                    else
                    {
                        RowList[i][j].DirNorth = RowList[i - 1][j].High - RowList[i][j].High;
                        RowList[i][j].DirSouth = RowList[i + 1][j].High - RowList[i][j].High;
                    }

                    if (j == 0 || j == SizeBoard - 1)
                    {
                        if (j == 0)
                        {
                            RowList[i][j].DirWest = 100;
                            RowList[i][j].DirEast = RowList[i][j + 1].High - RowList[i][j].High;
                        }
                        else
                        {
                            RowList[i][j].DirEast = 100;
                            RowList[i][j].DirWest = RowList[i][j - 1].High - RowList[i][j].High;
                        }
                    }
                    else
                    {
                        RowList[i][j].DirWest = RowList[i][j - 1].High - RowList[i][j].High;
                        RowList[i][j].DirEast = RowList[i][j + 1].High - RowList[i][j].High;
                    }
                }
            }
        }


        public void UpdateMovePossible(Character character)    //juste mais ne prend pas en compte la hauteur
        {
            clearMovePossible();
            RowList[character.PositionY][character.PositionX].MovePossible = 0;
            for (int m = 0; m < character.MovePoint; m++)
            {
                for (int i = 0; i < SizeBoard; i++) // On parcourt les Y
                {
                    for (int j = 0; j < SizeBoard; j++) //On parcourt les X
                    {
                        if (RowList[i][j].MovePossible == m)
                        {
                            if (RowList[i][j].DirNorth < 2 && RowList[i][j].DirNorth > -3 && i - 1 >= 0 && RowList[i - 1][j].CharOnTile() != 2)
                            {
                                RowList[i - 1][j].MovePossible = m + 1;
                            }
                            if (RowList[i][j].DirSouth < 2 && RowList[i][j].DirSouth > -3 && i + 1 < SizeBoard && RowList[i + 1][j].CharOnTile() != 2)
                            {
                                RowList[i + 1][j].MovePossible = m + 1;
                            }
                            if (RowList[i][j].DirWest < 2 && RowList[i][j].DirWest > -3 && j - 1 >= 0 && RowList[i][j - 1].CharOnTile() != 2)
                            {
                                RowList[i][j - 1].MovePossible = m + 1;
                            }
                            if (RowList[i][j].DirEast < 2 && RowList[i][j].DirEast > -3 && j + 1 < SizeBoard && RowList[i][j + 1].CharOnTile() != 2)
                            {
                                RowList[i][j + 1].MovePossible = m + 1;
                            }
                        }
                    }
                }
            }


        }

        private void clearMovePossible(){
            foreach (List<Tile> list in RowList){
                foreach (Tile tile in list){
                    tile.MovePossible = 300;
                }
            }
        }



















        


        public Boolean MoveCharacter(Character Piece, int posX, int posY)
        {

            if( RowList[posY][posX].MovePossible != 300 && RowList[posY][posX].Piece == null)
            {
                int oldPosY = Piece.PositionY;
                int oldPosX = Piece.PositionX;
                Piece.PositionY = posY;
                Piece.PositionX = posX;

                RowList[posY][posX].Piece = Piece;
                RowList[oldPosY][oldPosX].characterLeave();
                return true;
            }
            else
            {
                return false;
            }
        }
















    }
}

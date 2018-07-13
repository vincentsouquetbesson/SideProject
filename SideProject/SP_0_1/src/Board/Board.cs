using System;
using System.Collections.Generic;
using System.Text;

namespace SP_0_1
{
    class Board
    {
        private List<List<Tile>> RowList;// = new List<List<Tile>>();
        private int SizeBoard = 15;

        public Board()
        {
            CreateBoard();
            //UpdateDirectionnalField();
            //Console.WriteLine(RowList[3][3].DirEast);
        }

        public List<List<Tile>> getRowList()
        {
            return RowList;
        }

        /*
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
        */

        private void CreateBoard()
        {
            FileInput file = new FileInput();
            RowList = file.LoadMap("montain");
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


        /*
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
        */


/*
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
                            if (RowList[i][j].DirNorth < 2 && RowList[i][j].DirNorth > -3 && i - 1 >= 0 && RowList[i - 1][j].CharOnTile() != 2 && RowList[i - 1][j].MovePossible == 300)
                            {
                                RowList[i - 1][j].MovePossible = m + 1;
                            }
                            if (RowList[i][j].DirSouth < 2 && RowList[i][j].DirSouth > -3 && i + 1 < SizeBoard && RowList[i + 1][j].CharOnTile() != 2 && RowList[i + 1][j].MovePossible == 300)
                            {
                                RowList[i + 1][j].MovePossible = m + 1;
                            }
                            if (RowList[i][j].DirWest < 2 && RowList[i][j].DirWest > -3 && j - 1 >= 0 && RowList[i][j - 1].CharOnTile() != 2 && RowList[i][j - 1].MovePossible == 300)
                            {
                                RowList[i][j - 1].MovePossible = m + 1;
                            }
                            if (RowList[i][j].DirEast < 2 && RowList[i][j].DirEast > -3 && j + 1 < SizeBoard && RowList[i][j + 1].CharOnTile() != 2 && RowList[i][j + 1].MovePossible == 300)
                            {
                                RowList[i][j + 1].MovePossible = m + 1;
                            }
                        }
                    }
                }
            }
        }
        */


        public void UpdateMovePossible(Character character)    //prend en compte hauteur et terrain
        {
            int consumeMP;
            clearMovePossible();
            RowList[character.PositionY][character.PositionX].MovePossible = 0;
            for (int m = 0; m < character.MovePoint; m++)
            {
                for (int i = 0; i < SizeBoard; i++) // On parcourt les Y
                {
                    for (int j = 0; j < SizeBoard; j++) //On parcourt les X
                    {
                        if (RowList[i][j].MovePossible == m && RowList[i][j].MovePossible <character.MovePoint)
                        { //Si l'on est sur une case a traité, et qu'il reste des point de mouvement
                            if(RowList[i][j].Type == 2){ //Sortir de l'eau ralenti
                                consumeMP = 2;
                            }else{  // terrain normal
                                consumeMP = 1;
                            }

                            if (RowList[i][j].DirNorth < 2 && RowList[i][j].DirNorth > -3 && i - 1 >= 0 && RowList[i - 1][j].CharOnTile() != 2 && RowList[i - 1][j].MovePossible == 300)
                            {
                                RowList[i - 1][j].MovePossible = m + consumeMP;
                            }
                            if (RowList[i][j].DirSouth < 2 && RowList[i][j].DirSouth > -3 && i + 1 < SizeBoard && RowList[i + 1][j].CharOnTile() != 2 && RowList[i + 1][j].MovePossible == 300)
                            {
                                RowList[i + 1][j].MovePossible = m + consumeMP;
                            }
                            if (RowList[i][j].DirWest < 2 && RowList[i][j].DirWest > -3 && j - 1 >= 0 && RowList[i][j - 1].CharOnTile() != 2 && RowList[i][j - 1].MovePossible == 300)
                            {
                                RowList[i][j - 1].MovePossible = m + consumeMP;
                            }
                            if (RowList[i][j].DirEast < 2 && RowList[i][j].DirEast > -3 && j + 1 < SizeBoard && RowList[i][j + 1].CharOnTile() != 2 && RowList[i][j + 1].MovePossible == 300)
                            {
                                RowList[i][j + 1].MovePossible = m + consumeMP;
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

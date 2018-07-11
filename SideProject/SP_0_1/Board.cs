using System;
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
            UpdateDirectionnalField();
            Console.WriteLine(RowList[3][3].DirEast);
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


        public void ShowBoard()
        {
            foreach (List<Tile> list in RowList)
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



        public void ShowBoardHigh()
        {
            foreach (List<Tile> list in RowList)  //AFFICHAGE COLLONE
            {
                foreach (Tile tile in list)    //AFFICHAGE LIGNE
                {
                    Console.Write(tile.High + " ");
                }
                Console.Write("\n");
            }
        }





        public void UpdatePositionCharacter(Character character)
        {
            //rowList[character.getPositionX()][character.getPositionY()].characterOnTile(character);
            RowList[character.PositionY][character.PositionX].Piece = character;
        }




        private void UpdateDirectionnalField()
        {
            Console.WriteLine("update");
            for (int i = 0; i < SizeBoard; i++) // On parcourt les Y
            {
                Console.WriteLine(i);
                for (int j = 0; j < SizeBoard; j++) //On parcourt les X
                {
                    if ( i == 0 || i == SizeBoard - 1) {
                        if (i == 0) {
                            RowList[i][j].DirNorth = 100;
                            RowList[i][j].DirSouth = RowList[i+1][j].High - RowList[i][j].High;
                        }
                        else {
                            RowList[i][j].DirSouth = 100;
                            RowList[i][j].DirNorth = RowList[i-1][j].High - RowList[i][j].High;
                        }
                    }
                    else{
                        RowList[i][j].DirNorth = RowList[i-1][j].High - RowList[i][j].High;
                        Console.WriteLine(RowList[i][j].DirNorth);
                        RowList[i][j].DirSouth = RowList[i+1][j].High - RowList[i][j].High;
                    }

                    if (j == 0 || j == SizeBoard - 1)
                    {
                        if (j == 0)
                        {
                            RowList[i][j].DirWest = 100;
                            RowList[i][j].DirEast = RowList[i][j+1].High - RowList[i][j].High;
                        }
                        else
                        {
                            RowList[i][j].DirEast = 100;
                            RowList[i][j].DirWest = RowList[i][j-1].High - RowList[i][j].High;
                        }
                    }
                    else
                    {
                        RowList[i][j].DirWest = RowList[i][j-1].High - RowList[i][j].High;
                        RowList[i][j].DirEast = RowList[i][j+1].High - RowList[i][j].High;
                    }
                }
            }
        }







        /*
        public void UpdateMovePossible(Character character)    //juste mais ne prend pas en compte la hauteur
        {
            int mp = character.MovePoint;  //on recupére les point de movement du perso
            int posX = character.PositionX; //on recupére sa position en X
            int posY = character.PositionY; //on récupére sa position en Y
            int circle = 1;             //permet de tracer un cercle de mouvement

            for (int i = mp; i >= 0; i--) //parti sup 0 - character
            {
                if (posY - i < 0) //si sa depasse du board UP
                {
                    circle++;
                    continue;
                }
                else
                {
                    if (i == mp) //On a deja vérifié la position vertical, et l'horizon ne bouge pas
                    {
                        RowList[character.PositionY - i][character.PositionX].MovePossible = true;
                        RowList[character.PositionY - i][character.PositionX].High = 3;
                        circle++;
                    }
                    else
                    {
                        for (int j = 0; j < circle; j++)
                        {
                            if(character.PositionX + j < SizeBoard) //Verification de la position futur en X
                            {
                                RowList[character.PositionY - i][character.PositionX + j].MovePossible = true;
                            }
                            if (character.PositionX - j >= 0) //Verification de la position futur en X
                            {
                                RowList[character.PositionY - i][character.PositionX - j].MovePossible = true;
                            }
                        }
                        RowList[character.PositionY - i][character.PositionX].MovePossible = true;
                        circle++;
                    }
                }
            }
            circle -=2;
            
            for (int i = 1; i <= mp; i++) //parti sup 0 - character
            {
                if (posY + i > SizeBoard-1) //si sa depasse du board Down
                {
                    continue;
                }
                else
                {
                    if (i == mp) //On a deja vérifié la position vertical, et l'horizon ne bouge pas
                    {
                        RowList[character.PositionY + i][character.PositionX].MovePossible = true;
                        RowList[character.PositionY + i][character.PositionX].High = 3;
                    }
                    else
                    {
                        for (int j = 0; j < circle; j++)
                        {
                            if (character.PositionX + j < SizeBoard) //Verification de la position futur en X
                            {
                                RowList[character.PositionY + i][character.PositionX + j].MovePossible = true;
                            }
                            if (character.PositionX - j >= 0) //Verification de la position futur en X
                            {
                                RowList[character.PositionY + i][character.PositionX - j].MovePossible = true;
                            }
                        }
                        RowList[character.PositionY + i][character.PositionX].MovePossible = true;
                        circle--;
                    }
                }
            }
        }*/



        /*
                public void UpdateMovePossible(Character character)    //juste mais ne prend pas en compte la hauteur
                {
                    int mp = character.MovePoint;  //on recupére les point de movement du perso
                    int posX = character.PositionX; //on recupére sa position en X
                    int posY = character.PositionY; //on récupére sa position en Y
                    int circle = 1;             //permet de tracer un cercle de mouvement

                    for (int i = mp; i >= 0; i--) //parti sup 0 - character
                    {
                        if (posY - i < 0) //si sa depasse du board UP
                        {
                            circle++;
                            continue;
                        }
                        else
                        {
                            if (i == mp) //On a deja vérifié la position vertical, et l'horizon ne bouge pas
                            {
                                RowList[character.PositionY - i][character.PositionX].MovePossible = true;
                                RowList[character.PositionY - i][character.PositionX].High = 3;
                                circle++;
                            }
                            else
                            {
                                for (int j = 0; j < circle; j++)
                                {
                                    if (character.PositionX + j < SizeBoard) //Verification de la position futur en X
                                    {
                                        RowList[character.PositionY - i][character.PositionX + j].MovePossible = true;
                                    }
                                    if (character.PositionX - j >= 0) //Verification de la position futur en X
                                    {
                                        RowList[character.PositionY - i][character.PositionX - j].MovePossible = true;
                                    }
                                }
                                RowList[character.PositionY - i][character.PositionX].MovePossible = true;
                                circle++;
                            }
                        }
                    }
                    circle -= 2;
                    circle = mp+1;
                    Console.WriteLine(character.PositionX);
                    Console.WriteLine(character.PositionY);
                    for (int i = 0; i <= mp; i++) //parti inf 0 - character
                    {
                        if (posY + i > SizeBoard - 1) //si sa depasse du board Down
                        {
                            continue;
                        }
                        else
                        {
                            if (i == mp) //On a deja vérifié la position vertical, et l'horizon ne bouge pas
                            {
                                RowList[character.PositionY + i][character.PositionX].MovePossible = true;
                                RowList[character.PositionY + i][character.PositionX].High = 3;
                            }
                            else
                            {
                                if (RowList[character.PositionY + i][character.PositionX].DirSouth < 2 || RowList[character.PositionY + i][character.PositionX].DirSouth > 3)
                                {
                                    for (int j = circle -1; j > 0; j--) //Affichage de la partie gauche
                                    {
                                        if (character.PositionX - j >= 0)  //Verification de la position futur en X
                                        {
                                            if (RowList[character.PositionY + i][character.PositionX - j].DirWest <= 2 && RowList[character.PositionY + i][character.PositionX + j].DirWest >= -3)
                                            {
                                                RowList[character.PositionY + i][character.PositionX - j].MovePossible = true;
                                            }
                                            else {
                                                Console.Write(RowList[character.PositionY + i][character.PositionX - j].DirWest);
                                                break; }
                                        }
                                        else{break;}
                                    }
                                    for (int j = 0; j < circle; j++) //Affichage de la partie droite
                                    {
                                        if (character.PositionX + j < SizeBoard) //Verification de la position futur en X
                                        {
                                            if (RowList[character.PositionY + i][character.PositionX + j].DirEast <= 2 && RowList[character.PositionY + i][character.PositionX + j].DirEast >= -3)
                                            {
                                                RowList[character.PositionY + i][character.PositionX + j].MovePossible = true;
                                            }
                                            else{
                                                Console.Write(RowList[character.PositionY + i][character.PositionX + j].DirEast);
                                                break; }
                                        }
                                        else { break; }
                                    }
                                    RowList[character.PositionY + i][character.PositionX].MovePossible = true;


                                }
                                circle--;
                            }
                        }
                    }
                }
                */



        public void UpdateMovePossible(Character character)    //juste mais ne prend pas en compte la hauteur
        {
            RowList[character.PositionY][character.PositionX].MovePossible = 0;
            for (int m = 0; m < character.MovePoint; m++)
            {
                for (int i = 0; i < SizeBoard; i++) // On parcourt les Y
                {
                    Console.WriteLine(i);
                    for (int j = 0; j < SizeBoard; j++) //On parcourt les X
                    {
                        if (RowList[i][j].MovePossible == m)
                        {
                            if (RowList[i][j].DirNorth < 2 && RowList[i][j].DirNorth > -3 && i - 1 >= 0)
                            {
                                RowList[i-1][j].MovePossible = m+1;
                            }
                            if (RowList[i][j].DirSouth < 2 && RowList[i][j].DirSouth > -3 && i + 1 < SizeBoard)
                            {
                                RowList[i+1][j].MovePossible = m+1;
                            }
                            if (RowList[i][j].DirWest < 2 && RowList[i][j].DirWest > -3 && j - 1 >= 0)
                            {
                                RowList[i][j-1].MovePossible = m+1;
                            }
                            if (RowList[i][j].DirEast < 2 && RowList[i][j].DirEast > -3 && j + 1 < SizeBoard)
                            {
                                RowList[i][j+1].MovePossible = m+1;
                            }
                        } 
                    }
                }
            }


        }





















            public void showDeplacementPossible()
        {
            foreach (List<Tile> list in RowList) //X
            {
                foreach (Tile tile in list)   //Y
                {
                    if (tile.charOnTile() == true)
                    {
                        Console.Write("[*]");
                    }
                    else
                    {
                        if (tile.MovePossible == 300)
                        {
                            Console.Write("[ ]");
                        }
                        else
                        {
                            Console.Write("[D]");
                        }
                    }

                        
                }
                Console.Write("\n");
            }
        }




    }
}

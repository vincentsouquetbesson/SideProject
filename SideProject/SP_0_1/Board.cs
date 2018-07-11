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
            createBoard();
            RowList[3][3].High = 2;
        }

        private void createBoard()
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


        public void showBoard()
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



        public void showBoardHigh()
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





        public void updatePositionCharacter(Character character)
        {
            //rowList[character.getPositionX()][character.getPositionY()].characterOnTile(character);
            RowList[character.PositionY][character.PositionX].Piece = character;
        }



        /*
        public void updateMovePossible(Character character)    //juste mais ne prend pas en compte la hauteur
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




        public void updateMovePossible(Character character)    //juste mais ne prend pas en compte la hauteur
        {
            int mp = character.MovePoint;  //on recupére les point de movement du perso
            int posX = character.PositionX; //on recupére sa position en X
            int posY = character.PositionY; //on récupére sa position en Y
            int circle = 1;             //permet de tracer un cercle de mouvement
/*
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
            circle -= 2;*/
            circle = mp+1;
            for (int i = 0; i <= mp; i++) //parti sup 0 - character
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
        }


























        public void showDeplacementPossible()
        {
            foreach (List<Tile> list in RowList) //X
            {
                foreach (Tile tile in list)   //Y
                {
                    if (tile.charOnTile() != false)
                    {
                        Console.Write("[*]");
                    }
                    else
                    {
                        if (tile.MovePossible == true)
                        {
                            Console.Write("[D]");
                        }
                        else
                        {
                            Console.Write("[ ]");
                        }
                    }

                        
                }
                Console.Write("\n");
            }
        }




    }
}

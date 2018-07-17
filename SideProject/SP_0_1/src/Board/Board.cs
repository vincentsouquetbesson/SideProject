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
            UpdateDirectionnalField();
            //Console.WriteLine(RowList[3][3].DirEast);
        }

        public List<List<Tile>> getRowList()
        {
            return RowList;
        }


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
                            {  // Vers le Nord ( 0<-
                                RowList[i - 1][j].MovePossible = m + consumeMP;
                            }
                            if (RowList[i][j].DirSouth < 2 && RowList[i][j].DirSouth > -3 && i + 1 < SizeBoard && RowList[i + 1][j].CharOnTile() != 2 && RowList[i + 1][j].MovePossible == 300)
                            { //Vers le sud 0->
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






        public void UpdateBowAttackPossible(Character character)    //prend en compte hauteur et terrain
        {
            double initialH = RowList[character.PositionY][character.PositionX].High;
            clearAttackPossible();
            int atkRange;
            int bonusMeme; 

            RowList[character.PositionY][character.PositionX].AttackPossible = 0;
            for (int m = 0; m < 7; m++)
            {
                for (int i = 0; i < SizeBoard; i++) // On parcourt les Y
                {
                    for (int j = 0; j < SizeBoard; j++) //On parcourt les X
                    {
                        if (RowList[i][j].AttackPossible == m )
                        {
                            double high =  RowList[character.PositionY][character.PositionX].High - RowList[i][j].High ;
                            if (high < 0 ) // Si on attaque un foe plus haut
                            { //Sortir de l'eau ralenti
                                atkRange = 1 + Convert.ToInt32(Math.Abs(high));
                            }
                            else
                            {  // terrain normal
                                atkRange = 1;
                                bonusMeme = Convert.ToInt32(high) / 2;
                            }

                            if (i - 1 >= 0 && RowList[i - 1][j].AttackPossible == 300)
                            { //Si sa sort pas
                                RowList[i - 1][j].AttackPossible = m + atkRange;
                            }
                            if (i + 1 < SizeBoard && RowList[i + 1][j].AttackPossible == 300)
                            { //Vers le sud 0->
                                RowList[i + 1][j].AttackPossible = m + atkRange;
                            }
                            if (j - 1 >= 0 && RowList[i][j - 1].AttackPossible == 300)
                            {
                                RowList[i][j - 1].AttackPossible = m + atkRange;
                            }
                            if (j + 1 < SizeBoard && RowList[i][j + 1].AttackPossible == 300)
                            {
                                RowList[i][j + 1].AttackPossible = m + atkRange;
                            }
                        }
                    }
                }
            }
            foreach (List<Tile> list in RowList)
            {
                foreach (Tile tile in list)
                {
                    if(tile.AttackPossible < 4 || tile.AttackPossible > 7)
                        tile.AttackPossible = 300;
                }
            }

        }

        private void clearAttackPossible()
        {
            foreach (List<Tile> list in RowList)
            {
                foreach (Tile tile in list)
                {
                    tile.AttackPossible = 300;
                    tile.LigneOfSight = true;
                }
            }
        }










    }
}

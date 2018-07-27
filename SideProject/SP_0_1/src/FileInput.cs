using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SP_0_1
{
    class FileInput
    {
        private string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "Map4.csv");

        public int Width { get; set; }
        public int Height { get; set; }
        public List<Character>  CharactersBufferList{ get; set; }

        public List<List<Tile>> LoadMap(String mapName) //LIDL
        {
            List<List<Tile>> rowList = new List<List<Tile>>();
            int y = 0;
            int state = 0;   //0.find line 1. create board

            CharactersBufferList = new List<Character>();
            Width = 0;
            Height = 0;  
           
            foreach (string line in File.ReadLines(path)) //Pour chaque ligne du fichier
            {
                string[] parts = line.Split(';'); //On decoupe chaque ligne du CSV en tableau
                if(parts[0] == mapName && state == 0)
                {    //On fait tourner chaque ligne du fichier temp qu'on ne trouve pas la bonne ligne
                    state = 1;
                    Width = Int32.Parse(parts[1]);     // ligne
                    Height = Int32.Parse(parts[2]);   // colonne
                    continue; //On passe a la ligne suivante
                }
                if(state == 0)
                { // si on n'a pas encore trouvé les bonne valeur
                    continue; // On passe a la ligne suivante
                }
                if (state == 1)
                { //Si on atrouvé la bonne valeur
                    rowList.Add(new List<Tile>()); //On créer un nouvelle colonne ( list de list )

                    for (int i = 1; i <= Width; i++) //Pour chaque valeur dans la ligne
                    {
                        int r;
                        r = Int32.Parse(parts[i + Width + 1]); //conversion du type de terrain
                        rowList[y].Add(new Tile(r,Convert.ToDouble(parts[i]))); 
                    }
                    y++; //on passe a la ligne suivante
                    if(y >= Height)  //Si on a parcouru toute les lignes du plateau
                    {
                        state = 3;
                        continue;
                    }
                }
                if(state == 3)
                {
                    if(parts[1] == "2") // si c'est un enemi
                    {
                        CharactersBufferList.Add(new FOE(parts[2],
                                                Int32.Parse(parts[4]),
                                                Int32.Parse(parts[5])));
                    }
                    else
                    {
                        CharactersBufferList.Add(new Character(parts[2],
                                                Int32.Parse(parts[4]),
                                                Int32.Parse(parts[5]),3));
                    }
                    if(parts[0] == "break")
                    {
                        break;
                    }
                    
                }
            }
            return rowList;
        }



    }
}

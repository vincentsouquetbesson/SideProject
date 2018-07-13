using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SP_0_1
{
    class FileInput
    {
        private string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "Map3.csv");
        

        public List<List<Tile>> LoadMap(String mapName) //LIDL
        {
            List<List<Tile>> rowList = new List<List<Tile>>();
            int y = 0;
            int state = 0;   //0.find line 1. create board
           
            foreach (string line in File.ReadLines(path))
            {
                string[] parts = line.Split(';');
                if(parts[0] == mapName && state == 0) //On fait tourner chaque ligne du fichier temp qu'on ne trouve pas la bonne ligne
                {
                    state = 1;
                }
                if(state == 0) // si on n'a pas encore trouvé les bonne valeur
                {
                    continue;
                }
                if (state == 1)
                {
                    rowList.Add(new List<Tile>());

                    for (int i = 1; i < 16; i++)
                    {
                        int r;
                        r = Int32.Parse(parts[i + 16]);
                        rowList[y].Add( new Tile(Convert.ToDouble(parts[i])) );
                        rowList[y][i - 1].Type = r;
                    }
                    y++;
                    if(y >= 15)
                    {
                        break;
                    }
                }
            }
                return rowList;
        }



    }
}

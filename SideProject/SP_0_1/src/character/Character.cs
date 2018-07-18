using System;
using System.Collections.Generic;
using System.Text;

namespace SP_0_1
{
    class Character
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int MovePoint { get; set; }
        public int Team { get; set; } // 1.ally 2.foe 3.Pnj

        public String Name { get; set; }
        public int Lvl;
        public int exp;
        public int Force;
        public int Intel;
        public int Initiative;

        public int Counter;


        public Character(String name,int positionX, int positionY, int team) //pour le reste
        {
            Name = name;
            PositionX = positionX;
            PositionY = positionY;
            Team = team;
            MovePoint = 4;
        }

        public Character(String name, int team) //pour les hero 
        {
            Name = name;
            Team = team;
            MovePoint = 4;
        }


        public void InitBaseStat( int lvl, int force, int intel , int initiative)
        {
            Lvl = lvl;
            exp = 0;
            Force = force;
            Intel = intel;
            Initiative = initiative;
        }


        public void move(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

    }
}
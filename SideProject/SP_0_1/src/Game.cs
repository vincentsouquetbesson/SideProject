using System;
using System.Collections.Generic;
using System.Text;

namespace SP_0_1
{
    class Game
    {
        List<Character> HeroCharacterList;

        public Game()
        {
            HeroCharacterList = new List<Character>();
        }




        public void playGame()
        {
            InitHeroCharacter();


            Fight fight = new Fight(HeroCharacterList);
            //fight.playFightLIDL();
            fight.PlayFight();
        }


        public void InitHeroCharacter()
        {
            HeroCharacterList.Add(new Character("Ramza",1)); //HERO
            HeroCharacterList.Add(new Character("Delita", 1)); //HERO

            HeroCharacterList[0].InitBaseStat(1, 5, 1, 10,4);
            HeroCharacterList[1].InitBaseStat(1, 1, 6, 8,4);
        }




    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SP_0_1
{
    class Turn
    {
        List<Character> TurnList;
        List<Character> CharactersList;
        List<Character> CharactersBufferList;

        public Turn( List<Character> characterList )
        {
            TurnList = new List<Character>();
            CharactersList = characterList;
            CharactersBufferList = new List<Character>();
        }

        public void CreateTurnOrder()
        {
            ResetBufferCounter(CharactersList);
            while (TurnList.Count != 10)
            {
                // CharactersTurnList = new List<Character>();
                if (CharactersBufferList.Count > 0)  //si il reste des perso dans le buffer
                {
                    TurnList.Add( getNextCharacter() );  //on ajoute le suivant
                    continue;
                }
                while (true)        //si la liste est vide
                {
                    foreach (Character c in CharactersList)
                    {
                        c.Counter += c.Initiative;
                        if (c.Counter >= c.GoalCounter)
                        {
                            c.Counter -= c.GoalCounter;
                            CharactersBufferList.Add(c);
                        }
                    }
                    if (CharactersBufferList.Count > 0)
                    {
                        TurnList.Add(getNextCharacter() );
                        break;
                    }
                }
            }
            CharactersBufferList.Clear();
        }

        public Character getNextCharacter()
        { // gére la liste des perso si plusieur compteur on était depassé
            Character characterBuffer;
            if (CharactersBufferList.Count == 1) //Si il reste uniquement un perso dans le buffer
            {
                characterBuffer = CharactersBufferList[0];    // on ajoute le 1er perso de la liste
                CharactersBufferList.Remove(characterBuffer);  // on le retire de la liste
                return characterBuffer; // on le retourne
            }
            else  // si il en reste plus
            {
                characterBuffer = CharactersBufferList[0];   // on ajoute le 1er perso de la liste
                foreach (Character c in CharactersBufferList) // on parcourt la liste des perso en buffer
                {
                    if (characterBuffer.BufferCounter < c.BufferCounter)  // si le compteur est supérieur a celui en buffer
                    {
                        characterBuffer = c;
                    }
                }
                CharactersBufferList.Remove(characterBuffer);  // on supprime le perso avec le plus gros compteur
                return characterBuffer; // on le renvoi
            }
        }

        public void ResetBufferCounter(List<Character> characterList )
        {
            TurnList.Clear();
            foreach ( Character character in characterList)
            {
                character.BufferCounter = character.Counter;
            }
        }




        public Character NextTurn()
        {
            if(TurnList.Count < 5)
            {
                CreateTurnOrder();
            }
            Character characterBuffer = TurnList[0];    // on ajoute le 1er perso de la liste des tours
            TurnList.Remove(characterBuffer);  // on le retire de la liste
            return characterBuffer; // on le retourne
        }

/*
        public Character NextTurn()
        {
            // CharactersTurnList = new List<Character>();
            if (charactersBufferList.Count > 0)  //si il reste des perso dans le buffer
            {
                return getNextcharacter();
            }
            while (true)
            {
                foreach (Character c in CharacterList)
                {
                    c.Counter += c.Initiative;
                    if (c.Counter >= c.GoalCounter)
                    {
                        c.Counter -= c.GoalCounter;
                        charactersBufferList.Add(c);

                    }
                }
                if (charactersBufferList.Count > 0)
                {
                    return getNextcharacter();
                }
            }
            return null;
        }
        

        public Character getNextcharacter()
        {
            Character characterBuffer;
            if (charactersBufferList.Count == 1) //Si il reste uniquement un perso dans le buffer
            {
                characterBuffer = charactersBufferList[0];
                charactersBufferList.Remove(characterBuffer);
                return characterBuffer;
            }
            else
            {
                characterBuffer = charactersBufferList[0];
                foreach (Character c in charactersBufferList)
                {
                    if (characterBuffer.Counter < c.Counter)
                    {
                        characterBuffer = c;
                    }
                }
                charactersBufferList.Remove(characterBuffer);
                return characterBuffer;
            }
        }
        */



    }
}

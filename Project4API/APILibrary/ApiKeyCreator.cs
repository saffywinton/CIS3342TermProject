using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APILibrary
{
    public class ApiKeyCreator
    {
        string charcterList = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        Random rnd = new Random();

        string key = "";

        public ApiKeyCreator()
        {
            for (int i = 0; i < 20; i++)
            {
                key = key + getRandomCharacter();
            }
        }

        public ApiKeyCreator(int size)
        {
            for(int i = 0; i < size; i++)
            {
                key = key + getRandomCharacter();
            }
        }

        public string GetKey()
        {
            return key;
        }

        internal char getRandomCharacter()
        {
            return charcterList[rnd.Next(0, 61)];
        }
    }
}

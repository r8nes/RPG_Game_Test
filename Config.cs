using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    class Config
    {
        // Player's default data
        public static int _defaultPlayerHealth = 100;
        public static int _gigaSlashPower = 3;

        // Phrase generator

        public static string randomAttackPhrase(Random rnd) {
            string[] randomPhrase = new string[4] {"Rrrraaaah!", "Die!", "For The Blood god!", "Do you wanna die?"};
            string  currentPhrase= randomPhrase[rnd.Next(randomPhrase.Length)];
            return currentPhrase;
        }       

    }
}

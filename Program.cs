using System;
using System.Collections.Generic;

namespace RPG_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<string> gameHistory = new List<string>();
               
                Random random = new Random(); 

                Console.WriteLine("Hey, you. Yes, YOU! What is your name?");
                Console.WriteLine("Don't ignore me!");
                Console.WriteLine("Tap your name\n");

                string playerName = Console.ReadLine();
                Player  player = new Player(playerName);
                Console.CursorTop--;
                Console.WriteLine($"{player.Name}... Nice name!\n");

                //Encounter the monster
                Enemy monster = new Enemy("Giant Bee", 100);

                Engine.GameLoop(monster, random, player, 15, 20, gameHistory);           

                if (!player.IsDead)
                {
                    Boss boss = new Boss();
                    Engine.GameLoop(boss, random, player, 30, 15, gameHistory);
                    if (!player.IsDead)
                    {
                        Console.WriteLine($"Sorry {player.Name}, but game is developing by SSD Project now, so you can wait 8 years to play beta. See ya!");
                    }
                    else
                    {
                        GameOver();
                    }
                }
                else
                {
                    GameOver();
                }

                // Input the history.
                Console.WriteLine("Please tap something to check your log.");
                Console.ReadLine();
                Console.WriteLine("\n\n Game history: \n");

                foreach (var history in gameHistory)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(history);
                    Console.ResetColor();
                }

                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Why have you crashed the game?");
                Console.WriteLine("Something is wrong. Game will be stopping.");
                Console.ReadLine();
            }
        }
        private static void GameOver() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game over!");
            Console.ResetColor();
            
        }
    }   
}

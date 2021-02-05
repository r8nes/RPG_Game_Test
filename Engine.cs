using System;
using System.Collections.Generic;

namespace RPG_Game
{
    public static class Engine
    {
        public static void GameLoop(Enemy enemy,
                                                   Random random,
                                                   Player player,
                                                   int max_monster_attack,
                                                   int max_player_attack,
                                                   List<string> gameHistory)
        {
            string initialText = $"Oh no! The {enemy.Name} appeared! Doing somethimg!\n";
            string playerAttackText;
            string enemyAttackText;

            Console.WriteLine(initialText);
            gameHistory.Add(initialText);

            // Store what the player choose
            bool isChooseNotCorrect = true;

            while (isChooseNotCorrect)
            {
                // Battle loop
                while (!enemy.IsDead && !player.IsDead)
                {
                    Console.WriteLine($"1 - Attack {enemy.Name}!");
                    Console.WriteLine("2 - Use your skill!");
                    Console.WriteLine("3 - Defend yourself!");
                    Console.WriteLine("4 - Heal yourself!\n");

                    string playerChoose = Console.ReadLine();
                    int.TryParse(playerChoose, out int playerActions);

                    Console.CursorTop--;

                    switch (playerActions)
                    {
                            // Attack case
                        case 1:
                            isChooseNotCorrect = false;

                            playerAttackText = $"{player.Name}: {Config.randomAttackPhrase(random)}\nYou attack the {enemy.Name}\n";
                            Console.WriteLine(playerAttackText);
                            gameHistory.Add(playerAttackText);

                            enemy.GetsHit(random.Next(5, max_player_attack));
                            break;

                            // Super-mega-puper skill case
                        case 2:
                            isChooseNotCorrect = false;

                            playerAttackText = "Giga slash!\n";
                            Console.WriteLine(playerAttackText);
                            gameHistory.Add(playerAttackText);

                            for (int i = 1; i <= Config._gigaSlashPower && enemy.Health
                                > 0; i++)
                            {
                                enemy.GetsHit(random.Next(1, 15));
                            }
                            break;

                            // Defend case
                        case 3:
                            isChooseNotCorrect = false;

                            playerAttackText = "Shields up!\n";
                            Console.WriteLine(playerAttackText);
                            gameHistory.Add(playerAttackText);

                            player.isGuarding = true;
                            break;

                            // Heal case
                        case 4:
                            isChooseNotCorrect = false;

                            playerAttackText = "You feel energy in your body... You healed yourself!\n";
                            Console.WriteLine(playerAttackText);
                            gameHistory.Add(playerAttackText);

                            player.Heal(random.Next(10, 25));
                            break;
                            
                        default:
                            isChooseNotCorrect = true;        
                            
                            Console.WriteLine("Hey! Choose the right number!\n");
                            break;
                    }

                    // Enemy turn. Check if monster was dead the monster won't use the last attack.

                    if (!enemy.IsDead && !isChooseNotCorrect)
                    {
                        enemyAttackText = $"The enemy attacked the player.\n{player.Name} has {player.GetsHit(random.Next(1, max_monster_attack))} health";
                        gameHistory.Add(enemyAttackText);
                    }
                }
            }
        }
    }
}

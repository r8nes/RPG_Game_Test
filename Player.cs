using System;

namespace RPG_Game
{
    /// <summary>
    ///  This class represents the player character.
    /// </summary>
    public class Player
    {
        private readonly string _name;  
        private int maxHealthPlayerBar;
        public string Name
        {
            get
            {
                return _name;
            }
        }
        private int Health { set; get; }
        public bool IsDead { get; private set; }
        public bool isGuarding { get; set; }
        public Player(string name)
        {
            _name = name;
            Health = Config._defaultPlayerHealth;
            maxHealthPlayerBar = Health;
        }
        /// <summary>
        /// The amount of damage the player will take.
        /// </summary>
        /// <param name="hit_value"></param>
        public int GetsHit(int hit_value)
        {
            if (isGuarding)
            {
                Console.WriteLine(Name + " dodge the attack.\n");
                isGuarding = false;
            }
            else
            {
                int restHealth = Health -= hit_value;
                Console.WriteLine($"{Name} was hit for {hit_value} damage");

                if (restHealth <= 0)
                {
                    restHealth = 0;
                    Die();
                }
                Console.WriteLine($"{Name}: {restHealth}/{ maxHealthPlayerBar}\n");
            }
            if (Health < 0) {
                return 0; 
            }
                return Health;
        }
        /// <summary>
        /// Heals the player with the celectial power.
        /// </summary>
        /// <param name="amount_to_heal">The number of heal points.</param>
        public void Heal(int amount_to_heal)
        {
            Health += amount_to_heal;

            if (Health >= maxHealthPlayerBar)
            {
                Health = 100;
            }
            Console.WriteLine($"You heal {amount_to_heal} health!");
        }
        /// <summary>
        /// End game if our HP is zero.
        /// </summary>
        private void Die()
        {
            Console.WriteLine($"{Name} was died");
            IsDead = true;
        }
    }
}

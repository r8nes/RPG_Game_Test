using System;

namespace RPG_Game
{
    public class Enemy
    {
        private  int MaxHealthBar { get; }
        public int Health { get; set; }
        public string Name { get; set; }
        public bool IsDead { get; private set; }

        /// <summary>
        /// The default enemy constructor
        /// </summary>
        /// <param name="name">Monster's name</param>
        
        public Enemy(string name, int health)
        {
            Name = name; 
            Health = health;
            MaxHealthBar = health;
        }

        /// <summary>
        /// Gets called when the enemy is hit.
        /// </summary>
        /// <param name="hit_value">The amount of damage the enemy will take</param> 
        
        public void GetsHit(int hit_value) 
        {      
            int restHealth = Health -= hit_value;

            Console.WriteLine($"{Name} was hit for {hit_value} damage");

            if (restHealth <= 0) {
                restHealth = 0;
                Die();
            }

            Console.WriteLine($"{Name}: {restHealth}/{ MaxHealthBar}\n");
         
        }
        /// <summary>
        /// Gets called when enemy has died.
        /// </summary>
        private void Die(){
            Console.WriteLine($"{Name} was died");  
            IsDead = true;
        }
    }
}

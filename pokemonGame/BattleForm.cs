using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokemonGame
{
    class BattleForm
    {
        private Form1 mainforms;
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Skill { get; set; }
        public bool IsMissed { get; set; }

        private static Random random = new Random();

        public BattleForm(string name, int health, int attackPower, int skill)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
            Skill = skill;
        }

        public BattleForm(bool miss)
        {
            IsMissed = miss;
        }

        public void missed(BattleForm opponent)
        {
            IsMissed = random.Next(0, 100) < 30;

            if (IsMissed)
            {
                MessageBox.Show($"{Name} missed!");
            }
            else
            {
                opponent.Health += 0; // No effect since it's a miss
            }
        }

        public void Attack(BattleForm opponent)
        {
            // opponent.Health = Math.Max(0, opponent.Health - AttackPower);
            // Apply random damage variation (e.g., ±20% of AttackPower)
            int variation = random.Next(-AttackPower / 5, AttackPower / 5);
            int damage = Math.Max(0, AttackPower + variation);

            opponent.Health = Math.Max(0, opponent.Health - damage);

            MessageBox.Show($"{Name} attacked {opponent.Name} for {damage} damage!");
        }
        
        public void Skills(BattleForm opponent)
        {
            int skillDamage = AttackPower + 30; // 15 extra damage
            opponent.Health = Math.Max(0, opponent.Health - skillDamage);

            MessageBox.Show($"{Name} used a SKILL ATTACK for {skillDamage} damage on {opponent.Name}!");
        }
    }

 
    
}

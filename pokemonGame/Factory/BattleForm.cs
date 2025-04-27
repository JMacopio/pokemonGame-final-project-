using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokemonGame
{
    public class BattleForm
    {
        private static Random random = new Random();
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Skill { get; set; }
        public bool IsMissed { get; set; }

        private BattleForm(string name, int health, int attackPower, int skill)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
            Skill = skill;
        }

        public void Attack(BattleForm opponent)
        {
            int variation = random.Next(-AttackPower / 5, AttackPower / 5);
            int damage = Math.Max(0, AttackPower + variation);
            opponent.Health = Math.Max(0, opponent.Health - damage);
            MessageBox.Show($"{Name} attacked {opponent.Name} for {damage} damage!");
        }

        public void Skills(BattleForm opponent)
        {
            int skillDamage = AttackPower + 30;
            opponent.Health = Math.Max(0, opponent.Health - skillDamage);
            MessageBox.Show($"{Name} used a SKILL ATTACK for {skillDamage} damage on {opponent.Name}!");
        }

        // Factory Method for Creating New Players
        public static BattleForm CreatePlayer(string name, int health, int attackPower, int skill)
        {
            return new BattleForm(name, health, attackPower, skill);
        }
    }

}

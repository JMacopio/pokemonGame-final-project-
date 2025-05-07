using pokemonGame.Model;
using pokemonGame.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace pokemonGame
{
    public partial class Battle: Form, IBattle
    {
        private BattleForm player1 = BattleForm.CreatePlayer("Player 1", 100, 30, 40);
        private BattleForm player2 = BattleForm.CreatePlayer("Player 2", 100, 20, 40);
        private BattleForm currentPlayer;
        private BattleForm opponent;
        private Timer DodgeTimer;
        private PlayerState savedState;
        WindowsMediaPlayer player;
        private Timer attackEffectTimer;
        public Battle()
        {
            InitializeComponent();
            InitializeGame();
            InitializeDodgeTimer();
            player = new WindowsMediaPlayer();
            PlayAudio();
            this.ControlBox = false;
            button5.Visible = false; 
            attackEffectTimer = new Timer { Interval = 500 }; // 0.5-second effect duration
            attackEffectTimer.Tick += AttackEffectTimer_Tick;

        }

        private void InitializeGame()
        {
            currentPlayer = player1;
            opponent = player2;
            progressBar1.Maximum = progressBar2.Maximum = 100;
            UpdateUI();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            currentPlayer.Attack(opponent);
            ApplyDamage(currentPlayer.AttackPower);
            pictureBox2.Image = Properties.Resources.slash; // Change image to attack effect
            attackEffectTimer.Start();
            UpdateUI();
            CheckDefeat();
            if (opponent.Health <= 0)
            {
                MessageBox.Show(currentPlayer.Name+ "Wins!", "Game Over");
                InitializeGame();
                EndBattle();
                player.controls.stop();
                return;
            }
            if (currentPlayer.Health <= 0) // Trigger RestoreState if defeated
            {
                RestoreState();
                return;
            }

            AutoDodge();
            Swapturns();
        }
        private void Swapturns()
        {
            BattleForm temp = currentPlayer;
            currentPlayer = opponent;
            opponent = temp;
            label1.Text = currentPlayer.Name + "Turn";

            //For computer attack
            if(currentPlayer == player2)
            {
                ComputerAttack();
                UpdateUI();
                if (opponent.Health <= 0)
                {
                    MessageBox.Show(currentPlayer.Name + "Wins!");
                    InitializeGame();
                    EndBattle();
                    return;
                }
                AutoDodge();
            }
        }
        private void ComputerAttack()
        {
            currentPlayer.Attack(opponent);
            //MessageBox.Show(currentPlayer.Name + " Attack!!");
            UpdateUI();

            if (opponent.Health <= 0)
            {
                MessageBox.Show(currentPlayer.Name + " Wins!", "Game Over");
                InitializeGame();
                return;
            }

            if (currentPlayer.Health <= 0) // Check if defeated
            {
                RestoreState();
                return;
            }

            AutoDodge();
        }

        private void UpdateUI()
        {
            label5.Text = player1.Health + "HP";
            label4.Text = player2.Health + "HP";
            progressBar1.Value = player1.Health;
            progressBar2.Value = player2.Health;
        }

        private void dodgeTimer(object sender, EventArgs e)
        {
            AutoDodge();
        }

        private void AutoDodge()
        {

            if (currentPlayer.IsMissed || opponent.IsMissed)
            {
                currentPlayer.IsMissed = true;
                MessageBox.Show("Dodge");
            }
            else
            {
                currentPlayer.IsMissed = false;
            }
        }

        private void InitializeDodgeTimer()
        {
            DodgeTimer = new Timer();
            DodgeTimer.Interval = 1000;
            DodgeTimer.Tick += new EventHandler(dodgeTimer);
            DodgeTimer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentPlayer.Skills(opponent);

            // **Trigger Attack Effect**
            pictureBox2.Image = Properties.Resources.flame; // Change image to attack effect
            attackEffectTimer.Start(); // Start timer to reset image after effect

            UpdateUI();
            if (opponent.Health <= 0)
            {
                MessageBox.Show(currentPlayer.Name + "Wins!", "Game Over");
                InitializeGame();
                EndBattle();
                player.controls.stop();
                return;
            }
            AutoDodge();
            Swapturns();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Inventory form = new Inventory();
            form.Show();
            this.Hide();
            player.controls.stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The player chose to run");
            player.controls.stop();
            LandingPage form = new LandingPage();
            form.Show();
            this.Hide();
            player.controls.stop();
        }

        
        private void button5_Click(object sender, EventArgs e)
        {
            int baseChance = 100 - player2.Health;
            baseChance += 10;

            Random rand = new Random();
            if (rand.Next(100) < baseChance)
            {
                label6.Text = "You caught the Pokémon!";
                EndBattle();
            }
            else
            {
                label6.Text = "The Pokémon broke free!";
                ComputerAttack();
            }
        }
        private void ApplyDamage(int damage)
        {
            player2.Health -= damage;
            // Prevent health from dropping below zero
            player2.Health = Math.Max(player2.Health, 0);
            UpdateButtonVisibility();
        }

        private void UpdateButtonVisibility()
        {
            if (player2.Health <= player2.Health * 0.5)
            {
                button5.Visible = true;
                label6.Visible = true;
            }
            else
            {
                button5.Visible = false;
                label6.Visible = false;
            }
        }
        private void EndBattle()
        {   
            MessageBox.Show("Battle Ended");
            this.Close();
            LandingPage form = new LandingPage();
            form.Show();
            player.controls.stop();
        }
        private void SaveState()
        {
            savedState = new PlayerState
            {
                Health = currentPlayer.Health,
                Position = currentPlayer.Position // Assuming Position is a valid Point
            };
            MessageBox.Show("Game Saved!");
        }

        private void RestoreState()
        {
            if (savedState != null)
            {
                currentPlayer.Health = savedState.Health;
                currentPlayer.Position = savedState.Position;
                MessageBox.Show("You were defeated, returning to save point!");
                UpdateUI();
                // Update player's position visually if needed
            }
            else
            {
                MessageBox.Show("No save point found!");
                InitializeGame();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveState();
        }
        private void CheckDefeat()
        {
            if (currentPlayer.Health <= 0)
            {
                RestoreState(); // Return to save point if defeated
                return;
            }

            if (opponent.Health <= 0)
            {
                InitializeGame();
                return;
            }
        }
        //Timer Event to Reset the Attack Effect
        private void AttackEffectTimer_Tick(object sender, EventArgs e)
        {
            attackEffectTimer.Stop();
            pictureBox2.Image = Properties.Resources.sprite_pikachu; // Reset to normal idle image
        }

        private void PlayAudio()
        {
            player.URL = "C:\\Users\\User\\source\\repos\\pokemonGame\\pokemonGame\\Resources\\Pokémon Ruby, Sapphire & Emerald - Trainer Battle Music (HQ) (mp3cut.net).wav";
            player.controls.play();
        }

        void IBattle.InitializeGame()
        {
            InitializeGame();
        }

        void IBattle.UpdateUI()
        {
            UpdateUI();
        }

        public void SwapTurns()
        {

        }

        void IBattle.AutoDodge()
        {
            AutoDodge();
        }

        void IBattle.ComputerAttack()
        {
            ComputerAttack();
        }

        void IBattle.InitializeDodgeTimer()
        {
            InitializeDodgeTimer();
        }

        void IBattle.SaveState()
        {
            SaveState();
        }

        void IBattle.RestoreState()
        {
            RestoreState();
        }

        void IBattle.CheckDefeat()
        {
            CheckDefeat();
        }
    }
}

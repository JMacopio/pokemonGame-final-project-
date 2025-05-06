using pokemonGame.Factory;
using pokemonGame.Model;
using pokemonGame.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace pokemonGame
{
    public partial class Battle2 : Form, IBattle2
    {
        private SecondBattleForm player1 = SecondBattleForm.CreatePlayer("Player 1", 100, 30, 40);
        private SecondBattleForm player2 = SecondBattleForm.CreatePlayer("Player 2", 100, 20, 40);
        private SecondBattleForm currentPlayer1;
        private SecondBattleForm opponent2;
        private Timer DodgeTimer;
        private PlayerState savedState;
        WindowsMediaPlayer player;
        private Timer attackEffectTimer;
        public Battle2()
        {
            InitializeComponent();
            InitializeGame();
            InitializeDodgeTimer();
            player = new WindowsMediaPlayer();
            PlayAudio();
            this.ControlBox = false;
            attackEffectTimer = new Timer { Interval = 500 }; // 0.5-second effect duration
            attackEffectTimer.Tick += AttackEffectTimer_Tick;

        }
        private void InitializeGame()
        {
            currentPlayer1 = player1;
            opponent2 = player2;
            progressBar1.Maximum = progressBar2.Maximum = 100;
            UpdateUI();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentPlayer1.Attack(opponent2);
            pictureBox2.Image = Properties.Resources.slash;
            attackEffectTimer.Start();
            UpdateUI();
            CheckDefeat();
            if (opponent2.Health <= 0)
            {
                MessageBox.Show(currentPlayer1.Name + "Wins!", "Game Over");
                InitializeGame();
                EndBattle();
                return;
            }
            if (currentPlayer1.Health <= 0) // Trigger RestoreState if defeated
            {
                RestoreState();
                return;
            }
            AutoDodge();
            Swapturns();
        }
        private void Swapturns()
        {
            SecondBattleForm temp = currentPlayer1;
            currentPlayer1 = opponent2;
            opponent2 = temp;
            label1.Text = currentPlayer1.Name + "Turn";

            //For computer attack
            if (currentPlayer1 == player2)
            {
                ComputerAttack();
                UpdateUI();
                if (opponent2.Health <= 0)
                {
                    MessageBox.Show(currentPlayer1.Name + "Wins!");
                    InitializeGame();
                    return;
                }
                AutoDodge();
            }
        }
        private void ComputerAttack()
        {
            currentPlayer1.Attack(opponent2);
            //MessageBox.Show(currentPlayer.Name + " Attack!!");
            UpdateUI();

            if (opponent2.Health <= 0)
            {
                MessageBox.Show(currentPlayer1.Name + " Wins!", "Game Over");
                InitializeGame();
                EndBattle();
                return;
            }

            if (currentPlayer1.Health <= 0) // Check if defeated
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

            if (currentPlayer1.IsMissed || opponent2.IsMissed)
            {
                currentPlayer1.IsMissed = true;
                MessageBox.Show("Dodge");
            }
            else
            {
                currentPlayer1.IsMissed = false;
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
            currentPlayer1.Skills(opponent2);
            pictureBox2.Image = Properties.Resources.lightning; // Change image to attack effect
            attackEffectTimer.Start(); // Start timer to reset image after effect
            UpdateUI();
            if (opponent2.Health <= 0)
            {
                MessageBox.Show(currentPlayer1.Name + "Wins!", "Game Over");
                InitializeGame();
                EndBattle();
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
            LandingPage form = new LandingPage();
            form.Show();
            this.Hide();
            player.controls.stop();
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
                Health = currentPlayer1.Health,
                Position = currentPlayer1.Position // Assuming Position is a valid Point
            };
            MessageBox.Show("Game Saved!");
        }

        private void RestoreState()
        {
            if (savedState != null)
            {
                currentPlayer1.Health = savedState.Health;
                currentPlayer1.Position = savedState.Position;
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
            if (currentPlayer1.Health <= 0)
            {
                RestoreState(); // Return to save point if defeated
                return;
            }

            if (opponent2.Health <= 0)
            {
                MessageBox.Show(currentPlayer1.Name + " Wins!", "Game Over");
                InitializeGame();
                return;
            }
        }
        private void PlayAudio()
        {
            player.URL = "C:\\Users\\User\\source\\repos\\pokemonGame v2\\pokemonGame\\Resources\\Pokémon Ruby, Sapphire & Emerald - Trainer Battle Music (HQ) (mp3cut.net).wav";
            player.controls.play();
        }
        //Timer Event to Reset the Attack Effect
        private void AttackEffectTimer_Tick(object sender, EventArgs e)
        {
            attackEffectTimer.Stop();
            pictureBox2.Image = Properties.Resources.enemey2; // Reset to normal idle image
        }
        
        void IBattle2.InitializeGame()
        {
            InitializeGame();
        }

        void IBattle2.UpdateUI()
        {
            UpdateUI();
        }

        public void SwapTurns()
        {
            
        }

        void IBattle2.AutoDodge()
        {
            AutoDodge();
        }

        void IBattle2.ComputerAttack()
        {
            ComputerAttack();
        }

        void IBattle2.InitializeDodgeTimer()
        {
            InitializeDodgeTimer();
        }

        void IBattle2.SaveState()
        {
            SaveState();
        }

        void IBattle2.RestoreState()
        {
            RestoreState();
        }

        void IBattle2.CheckDefeat()
        {
            CheckDefeat();
        }
    }
}

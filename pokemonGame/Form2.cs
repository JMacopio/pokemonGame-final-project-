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
    public partial class Form2: Form
    {
        private BattleForm player1 = new BattleForm("Player 1", 100, 30, 40);
        private BattleForm player2 = new BattleForm("Player 2", 100, 20, 40);
        private BattleForm currentPlayer;
        private BattleForm opponent;
        private Timer DodgeTimer;
        public Form2()
        {
            InitializeComponent();
            InitializeGame();
            InitializeDodgeTimer();
            this.ControlBox = false;
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
            UpdateUI();
            if(opponent.Health <= 0)
            {
                MessageBox.Show(currentPlayer.Name+ "Wins!", "Game Over");
                InitializeGame();
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
                    return;
                }
                AutoDodge();
            }
        }
        private void ComputerAttack()
        {
            currentPlayer.Attack(opponent);
            //MessageBox.Show(currentPlayer.Name + " Attack!!");
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
            UpdateUI();
            if (opponent.Health <= 0)
            {
                MessageBox.Show(currentPlayer.Name + "Wins!", "Game Over");
                InitializeGame();
                return;
            }
            AutoDodge();
            Swapturns();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The player chose to run");
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}

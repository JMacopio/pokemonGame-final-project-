using pokemonGame.Factory;
using pokemonGame.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokemonGame.Presenter
{
    public class SecondBattlePresenter
    {
        private IBattle2 view;
        private SecondBattleForm player1;
        private SecondBattleForm player2;
        private SecondBattleForm currentPlayer;
        private SecondBattleForm opponent;

        public SecondBattlePresenter(IBattle2 battleView)
        {
            view = battleView;
            InitializeGame();
        }

        private void InitializeGame()
        {
            player1 = SecondBattleForm.CreatePlayer("Player 1", 100, 30, 40);
            player2 = SecondBattleForm.CreatePlayer("Player 2", 100, 20, 40);
            currentPlayer = player1;
            opponent = player2;
            view.InitializeGame();
            view.UpdateUI();
        }

        public void HandleAttack()
        {
            currentPlayer.Attack(opponent);
            view.UpdateUI();
            CheckDefeat();
            SwapTurns();
        }

        private void SwapTurns()
        {
            SecondBattleForm temp = currentPlayer;
            currentPlayer = opponent;
            opponent = temp;
            view.SwapTurns();
            if (currentPlayer == player2)
            {
                ComputerAttack();
            }
        }

        private void ComputerAttack()
        {
            currentPlayer.Attack(opponent);
            view.UpdateUI();
            CheckDefeat();
        }

        private void CheckDefeat()
        {
            if (opponent.Health <= 0)
            {
                MessageBox.Show(currentPlayer.Name + " Wins!", "Game Over");
                InitializeGame();
            }
        }
    }
}

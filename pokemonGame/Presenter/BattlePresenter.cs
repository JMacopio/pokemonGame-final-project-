using pokemonGame.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokemonGame.Presenter
{
    public class BattlePresenter
    {
        private IBattle view;
        private BattleForm player1;
        private BattleForm player2;
        private BattleForm currentPlayer;
        private BattleForm opponent;

        public BattlePresenter(IBattle battleView)
        {
            view = battleView;
            InitializeGame();
        }

        private void InitializeGame()
        {
            player1 = BattleForm.CreatePlayer("Player 1", 100, 30, 40);
            player2 = BattleForm.CreatePlayer("Player 2", 100, 20, 40);
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
            BattleForm temp = currentPlayer;
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

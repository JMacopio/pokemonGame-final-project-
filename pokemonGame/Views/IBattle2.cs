using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemonGame.Views
{
    public interface IBattle2
    {
        void InitializeGame();
        void UpdateUI();
        void SwapTurns();
        void AutoDodge();
        void ComputerAttack();
        void InitializeDodgeTimer();
        void SaveState();
        void RestoreState();
        void CheckDefeat();
    }
}

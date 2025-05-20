using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemonGame.Views
{
    public interface IInventory
    {
        void UpdateDamageDisplay(double newDamage);
        void UpdateHealthDisplay(double newHealth);
        void ShowMessage(string message);
        void HideItem(string itemName);

    }
}

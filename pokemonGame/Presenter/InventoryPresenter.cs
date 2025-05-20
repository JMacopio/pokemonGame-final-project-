using pokemonGame.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemonGame.Presenter
{
    public class InventoryPresenter
    {
        private IInventory view;
        private double damage = 80;
        private bool powerUpUsed = false;
        private double health = 80;
        private bool healthUp = false;

        public InventoryPresenter(IInventory inventoryView)
        {
            view = inventoryView;
        }

        public void ApplyPowerUp()
        {
            if (!powerUpUsed)
            {
                damage *= 1.10;
                powerUpUsed = true;
                view.HideItem("pictureBox1");
                view.ShowMessage($"Power up! Damage increased to {damage}");
                view.UpdateDamageDisplay(damage);
            }
        }

        public void RecoverHealth()
        {
            if (!healthUp)
            {
                health *= 1.10;
                healthUp = true;
                view.HideItem("pictureBox2");
                view.ShowMessage($"Recovery Up! Health recovered to {health}");
                view.UpdateHealthDisplay(health);
            }
        }

        public void EquipUltraBall()
        {
            view.ShowMessage("Ultra Ball has been equipped");
        }

    }
}

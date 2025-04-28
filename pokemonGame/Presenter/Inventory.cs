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
    public partial class Inventory : Form
    {
        double damage = 80;
        bool powerUpUsed = false; // So it can’t be clicked multiple times
        double health = 80;
        bool healthUp = false;

        private ToolTip toolTip;
        public Inventory()
        {
            this.ControlBox = false;
            InitializeComponent();

            toolTip = new ToolTip();
            toolTip.SetToolTip(pictureBox1, "Attack +10%");
            toolTip.SetToolTip(pictureBox2, "Recover 10% hp");
            toolTip.SetToolTip(pictureBox3, "Remove status aliments");
            toolTip.SetToolTip(pictureBox4, "Ultra Ball");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Battle form = new Battle();
            form.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!powerUpUsed)
            {
                damage *= 1.10; // Increase by 10%
                powerUpUsed = true; // disable after one use

                // Optional: give visual feedback
                pictureBox1.Visible = false; // Hide it after click
                MessageBox.Show("Power up! Damage increased to " + damage);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!healthUp)
            {
                health *= 1.10; // Increase by 10%
                powerUpUsed = true; // disable after one use

                // Optional: give visual feedback
                pictureBox1.Visible = false; // Hide it after click
                MessageBox.Show("Recovery Up! Health has been recoverd to " + health);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ultra Ball has been equiped");
        }
    }
}

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
    public partial class Form4 : Form
    {
        double damage = 80;
        bool powerUpUsed = false; // So it can’t be clicked multiple times
        double health = 80;
        bool healthUp = false;

        private ToolTip toolTip;
        public Form4()
        {
            this.ControlBox = false;
            InitializeComponent();

            toolTip = new ToolTip();
            toolTip.SetToolTip(pictureBox1, "Attack +10%");
            toolTip.SetToolTip(pictureBox2, "Remove status aliments");
            toolTip.SetToolTip(pictureBox3, "Recover 10% hp");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
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
    }
}

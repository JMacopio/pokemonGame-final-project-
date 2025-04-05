using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokemonGame
{
    public partial class Form1: Form 
    {
        private PlayerMovement playerMovement;
        private BattleForm battleForm;

        public Form1()
        {
            InitializeComponent();
            playerMovement = new PlayerMovement(pictureBox1, this );
            AddWildPokemon();
            BattleStart();
            
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            playerMovement.KeyDowns(e);

        }

        private void keyUp(object sender, KeyEventArgs e) { }

        private void AddWildPokemon()
        {
            PictureBox wildpokemon = new PictureBox
            {
                Image = Properties.Resources._0025,
                SizeMode = PictureBoxSizeMode.AutoSize,
                Size = new Size(17, 23),
                BackColor = Color.Transparent,
                Visible = false,
                Tag = "WildPokemon"
            };
        }

        public void BattleStart()
        {
            if (pictureBox1 != null && pictureBox2 != null && pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                pictureBox1.BringToFront();
                MessageBox.Show("Battle Start");
                Form2 form = new Form2();
                form.Show();
                this.Hide();
            }
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox && control.Tag != null && control.Tag.ToString() == "WildPokemon")
                {
                    control.Visible = false;
                }
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}

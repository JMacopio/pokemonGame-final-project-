using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using WMPLib;


namespace pokemonGame
{
    public partial class StartUp: Form
    {
        SoundPlayer player = new SoundPlayer(Properties.Resources.Pokémon_Ruby___Opening__mp3cut_net_);
        public StartUp()
        {
            InitializeComponent();
            this.ControlBox = false;
            bgmusic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LandingPage form = new LandingPage();
            form.Show();
            this.Hide();
            player.Stop();
        }

        private void bgmusic()
        {
            player.Play();
        }
    }
}

using pokemonGame.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;


namespace pokemonGame
{
    public partial class LandingPage: Form, ILandingPage
    {
        WindowsMediaPlayer player;
        private PlayerMovement playerMovement;
        private BattleForm battleForm;
        private bool npcSpeaking = false;

        public LandingPage()
        {
            InitializeComponent();
            playerMovement = new PlayerMovement(pictureBox1, wall, this);
            AddWildPokemon();
            BattleStart();
            player = new WindowsMediaPlayer();
            PlayAudio();
            this.ControlBox = false;

            Timer timer = new Timer { Interval = 1000 };
            timer.Tick += Timer_Tick;
            timer.Start();

            conversationLabel.Visible = false;
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            playerMovement.KeyDowns(e);

            if (npcSpeaking && e.KeyCode == Keys.Enter)
            {
                conversationLabel.Text = "Hey! Watch where you're going!!";
                npcSpeaking = false;
                Timer transitionTimer = new Timer { Interval = 1000 }; // 1 second delay
                transitionTimer.Tick += (senderTimer, args) =>
                {
                    transitionTimer.Stop();
                    Battle2 newForm = new Battle2();
                    newForm.Show();
                    this.Hide();
                };
                transitionTimer.Start();

            }
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
            wildpokemon.Location = new Point(300, 200);
            this.Controls.Add(wildpokemon);
        }

        public void BattleStart()
        {
            if (pictureBox1 != null && pictureBox2 != null && pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                pictureBox1.BringToFront();
                MessageBox.Show("Battle Start");
                player.controls.stop();
                Battle form = new Battle();
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

        private void PlayAudio()
        {
            player.URL = "C:\\Users\\User\\source\\repos\\pokemonGame\\pokemonGame\\Resources\\Pokemon RubySapphireEmerald- Oldale Town (mp3cut.net).wav";
            player.controls.play();
        }

        void ILandingPage.AddWildPokemon()
        {
            AddWildPokemon();
        }

        void ILandingPage.PlayAudio()
        {
            PlayAudio();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                conversationLabel.Visible = true;
                conversationLabel.Text = "Let's fight";
                npcSpeaking = true; 
            }
            else if (!npcSpeaking)
            {
                conversationLabel.Text = "";
            }
        }
    }
}

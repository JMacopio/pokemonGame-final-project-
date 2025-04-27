using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokemonGame
{
    public class PlayerMovement
    {
        private PictureBox player;
        private int charspeed = 15;
        private LandingPage mainforms;
        public bool MoveUp, MoveRight, MoveLeft, MoveDown;
        public bool Wildpokemon;
        


        public PlayerMovement(PictureBox player, LandingPage form)
        {
            this.player = player;
            this.mainforms = form;
        }


        public void KeyDowns(KeyEventArgs e)
        {
            
                switch (e.KeyCode)
                {
                    case Keys.Up:
                    case Keys.W:
                        player.Top -= charspeed;
                        player.Image = Properties.Resources.UpIdlePlayer;
                        break;

                    case Keys.Down:
                    case Keys.S:
                        player.Top += charspeed;
                        player.Image = Properties.Resources.DownIdlePlayer;
                        break;

                    case Keys.Left:
                    case Keys.A:
                        player.Left -= charspeed;
                        player.Image = Properties.Resources.LeftIdlePlayer;
                        break;

                    case Keys.Right:
                    case Keys.D:
                        player.Left += charspeed;
                        player.Image = Properties.Resources.RightIdlePlayer;
                        break;
                }
            
            mainforms.BattleStart();
            player.Refresh();
        }
        public void KeyUps(KeyEventArgs e)
        {

        }



        public void CollidePokemon(KeyEventArgs e, bool CollidingWithPokemon)
        {
            if (CollidingWithPokemon == true)
            {
                mainforms.BattleStart();
                return;
            }
            else
            {
                player.Location = new Point(player.Top, player.Left);
                MoveUp = MoveRight = MoveLeft = MoveDown = true;
            }
        }

        
    }
}

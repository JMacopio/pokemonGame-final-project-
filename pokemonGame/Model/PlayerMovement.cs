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
        private PictureBox wall;
        private int charspeed = 15;
        private LandingPage mainforms;
        public bool MoveUp, MoveRight, MoveLeft, MoveDown;
        public bool Wildpokemon;

        public PlayerMovement(PictureBox player,PictureBox wall, LandingPage form)
        {
            this.player = player;
            this.wall = wall;
            this.mainforms = form;
        }

        public void KeyDowns(KeyEventArgs e)
        {
            int newX = player.Left, newY = player.Top;

            switch (e.KeyCode)
            {
                    case Keys.Up:
                    case Keys.W:
                        newY -= charspeed;
                        player.Image = Properties.Resources.UpIdlePlayer;
                        break;

                    case Keys.Down:
                    case Keys.S:
                        newY += charspeed;
                        player.Image = Properties.Resources.DownIdlePlayer;
                        break;

                    case Keys.Left:
                    case Keys.A:
                        newX -= charspeed;
                        player.Image = Properties.Resources.LeftIdlePlayer;
                        break;

                    case Keys.Right:
                    case Keys.D:
                        newX += charspeed;
                        player.Image = Properties.Resources.RightIdlePlayer;
                        break;
            }
            //Collision Detection Before Moving
            var futureBounds = new Rectangle(newX, newY, player.Width, player.Height);
            if (!futureBounds.IntersectsWith(wall.Bounds))
            {
                player.Left = newX;
                player.Top = newY;
            }

            mainforms.BattleStart();
            player.Refresh();
        }
        public void KeyUps(KeyEventArgs e)
        {

        }
    }
}

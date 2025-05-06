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
        private List<PictureBox> walls;
        private LandingPage mainforms;
        public bool MoveUp, MoveRight, MoveLeft, MoveDown;
        public bool Wildpokemon;

        public PlayerMovement(PictureBox player, LandingPage form)
        {
            this.player = player;
            this.mainforms = form;

            walls = new List<PictureBox>();
            foreach (Control control in form.Controls)
            {
                if (control is PictureBox && control.Tag?.ToString() == "wall")
                {
                    walls.Add((PictureBox)control);
                }
            }
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
            bool collidesWithWall = false;

            foreach (PictureBox wall in walls)
            {
                if (futureBounds.IntersectsWith(wall.Bounds))
                {
                    collidesWithWall = true;
                    break;
                }
            }

            //Move Only If There Is No Wall Collision
            if (!collidesWithWall)
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

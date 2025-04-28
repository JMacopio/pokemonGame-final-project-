using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokemonGame.Model
{
    public class PlayerState
    {
        public int Health { get; set; }
        public Point Position { get; set; } = new Point(0, 0);
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChickenShooter
{
    class Piece : PictureBox
    {
        public int eggLandCount = 0, eggDownSpeed = 20;
        public Piece (int width, int height)
        {
            Width = width;
            Height = height;
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackColor = Color.Transparent;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace USRS46_Jeu_De_La_Vie_Graphique.Controls
{
    public class MainPictureBox : PictureBox
    {
        public MainPictureBox(int n)
        {
            Name = "main_picture_box";
            BackColor = Color.DarkSlateGray;
            Size = new Size(5*n, 5*n);
        }
    }
}

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace USRS46_Jeu_De_La_Vie_Graphique.Controls
{
    public class MainWindow : PictureBox
    {
        public MainWindow(int n)
        {
            BackColor = Color.MidnightBlue;
            Size = new Size(n * 5, n * 5);
        }
    }
}
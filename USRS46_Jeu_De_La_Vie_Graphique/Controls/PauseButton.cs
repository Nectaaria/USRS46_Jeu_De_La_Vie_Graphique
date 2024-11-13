using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace USRS46_Jeu_De_La_Vie_Graphique.Controls
{
    public class PauseButton : Button
    {
        public PauseButton()
        {
            Name = "btn_pause";
            Text = "Pause Simulation";
            TextAlign = ContentAlignment.MiddleCenter;
            BackColor = Color.LightGray;
            ForeColor = Color.Black;
            Size = new Size(300, 40);
            Dock = DockStyle.None;
            Font = new Font("Arial", 14);
            Cursor = Cursors.Hand;
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
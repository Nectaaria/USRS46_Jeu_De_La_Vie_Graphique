using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace USRS46_Jeu_De_La_Vie_Graphique.Controls
{
    public class TextBox : Label
    {
        public TextBox()
        {
            BorderStyle = BorderStyle.FixedSingle;
            Text = String.Empty;
            TextAlign = ContentAlignment.MiddleCenter;
            Size = new Size(100,23);
        }
    }
}
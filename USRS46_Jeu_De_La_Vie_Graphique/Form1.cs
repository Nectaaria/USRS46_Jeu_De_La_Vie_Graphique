using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using USRS46_Jeu_De_La_Vie_Graphique.Controls;

namespace USRS46_Jeu_De_La_Vie_Graphique
{
    public partial class Interface : Form
    {
        Label main_label;
        PictureBox main_picturebox;
        Game game = new Game(4, 10);
        private System.Windows.Forms.Timer MyTimer;
        int n = 40;
        int generation = 0;
        Grid grid;
        public Interface()
        {
            main_label = new MainLabel();
            main_picturebox = new MainPictureBox(n);
            InitializeComponent();
            MyTimer =  new System.Windows.Forms.Timer();
            MyTimer.Interval = (200);
            MyTimer.Tick += new EventHandler(UpdateGrid);
            main_picturebox.Paint += new PaintEventHandler(main_picturebox_Paint);
            Controls.Add(main_label);
            Controls.Add(main_picturebox);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size = new Size(500, 500);
            Text = "Interface";
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void UpdateGrid(object sender, EventArgs e)
        {
            grid.UpdateGrid();
            generation++;
            main_picturebox.Refresh();
            main_label.Text = $"Generation: {generation}";
        }
        private void main_picturebox_Paint(object sender, PaintEventArgs e)
        {
            // Définir une brush blanche
            // Boucler sur l’ensemble de la grille
            // Si la cellule à cet emplacement est vivante :
            // Dessiner un rectangle plein à partir de la
            // brush blanche de 5 par 5 pixels
        }
    }
}

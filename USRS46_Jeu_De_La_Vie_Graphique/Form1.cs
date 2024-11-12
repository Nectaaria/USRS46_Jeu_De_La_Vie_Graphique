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
using USRS46_Jeu_De_La_Vie_Graphique.Controls;
using TextBox = USRS46_Jeu_De_La_Vie_Graphique.Controls.TextBox;

namespace USRS46_Jeu_De_La_Vie_Graphique
{
    public partial class Interface : Form
    {
        private int n;
        private int generation;
        public Game game;
        private Timer _timer;
        private MainWindow _mainWindow;
        private TextBox _textBox;
        
        public Form1()
        {
            main_label = new MainLabel();
            main_picturebox = new MainPictureBox(n);
            InitializeComponent();
            
            // Initialisation de la variable contenant la taille de notre MainWindow
            n = 125;
            
            // Initialisation de la variable coorespondant à la génération actuelle de cellules
            generation = 0;
            
            // Initialisation du jeu à partir de notre classe Game
            game = new Game(20,10);
            
            // Initialisation du timer
            _timer = new Timer();
            _timer.Interval = 200;
            _timer.Tick += new EventHandler(UpdateGrid);
            
            // Initialisation de la MainWindow en utilisant notre classe
            _mainWindow = new MainWindow(n);
            _mainWindow.Location = new Point((Size.Width - n) / 2, 50);
            _mainWindow.Paint += new PaintEventHandler(_mainWindow_Paint);
            
            // Initialisation de la TextBox en utilisant notre classe
            _textBox = new TextBox();
            _textBox.Location = new Point(_mainWindow.Location.X, _mainWindow.Location.Y + 50);
            
            // Ajout des éléments à notre fenêtre
            Controls.Add(_mainWindow);
            Controls.Add(_textBox);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size = new Size(1920, 1080);
            WindowState = FormWindowState.Maximized;
            Text = "Jeu de la vie";
        }
        
        private void UpdateGrid(object sender, EventArgs e)
        {
            // Mise à jour de la grille du jeu
            game.grid.UpdateGrid();
            
            // Incrémentation de 1 de la variable generation
            generation++;
            
            // Mise à jour du label avec la valeur contenue dans generation
            _textBox.Text = generation.ToString();

            //Mise à jour de la fenêtre graphique
            
        }

        private void _mainWindow_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(_mainWindow.BackColor);
            // Définir une brush blanche
            SolidBrush whiteBrush = new SolidBrush(Color.White);

            // Boucler sur l’ensemble de la grille
            for(int i = 0; i < game.grid._n; i++)
            {
                for (int j = 0; j < game.grid._n; j++)
                {
                    // Si la cellule à cet emplacement est vivante
                    if (game.grid.TabCells[i,j].isAlive)
                    {
                        // Dessiner un rectangle plein à partir de la brush blanche de 5 par 5 pixels
                        g.FillRectangle(whiteBrush, 5 * i, 5 * j, 5, 5);
                    }
                }
            }
        }

    }
}

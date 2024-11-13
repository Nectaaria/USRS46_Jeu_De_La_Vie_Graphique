using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USRS46_Jeu_De_La_Vie_Graphique.Controls;
using TextBox = USRS46_Jeu_De_La_Vie_Graphique.Controls.TextBox;

namespace USRS46_Jeu_De_La_Vie_Graphique
{
    public partial class Form1 : Form
    {
        private int n;
        private int generation;
        private Game _game;
        private Timer _timer;
        private MainWindow _mainWindow;
        private TextBox _textBox;
        private PlayButton _playButton;
        private PauseButton _pauseButton;
        private RestartButton _restartButton;
        
        public Form1()
        {
            InitializeComponent();
            
            // Initialisation de la variable contenant la taille de notre MainWindow
            n = 40;
            
            // Initialisation de la variable coorespondant à la génération actuelle de cellules
            generation = 0;
            
            // Initialisation du jeu à partir de notre classe Game
            _game = new Game(n,10);
            
            // Initialisation du timer
            _timer = new Timer();
            _timer.Interval = 200;
            _timer.Tick += new EventHandler(UpdateGrid);
            
            // Initialisation de la MainWindow en utilisant notre classe
            _mainWindow = new MainWindow(n);
            _mainWindow.Location = new Point((ClientSize.Width - _mainWindow.Width) / 2, (this.ClientSize.Height - _mainWindow.Height) / 2);
            _mainWindow.Anchor = AnchorStyles.None;
            _mainWindow.Paint += new PaintEventHandler(_mainWindow_Paint);
            
            // Initialisation du bouton Play
            _playButton = new PlayButton();
            _playButton.Location = new Point((ClientSize.Width - _playButton.Width) / 2, _mainWindow.Location.Y + _mainWindow.Height + 25);
            _playButton.Anchor = AnchorStyles.None;
            _playButton.Click += new EventHandler(btn_play_Click);
            
            // Initialisation du bouton Pause
            _pauseButton = new PauseButton();
            _pauseButton.Location = new Point(ClientSize.Width + 18, ClientSize.Height + _mainWindow.Height - 45);
            _pauseButton.Anchor = AnchorStyles.None;
            _pauseButton.Click += new EventHandler(btn_pause_Click);
            
            // Initialisation du bouton Restart
            _restartButton = new RestartButton();
            _restartButton.Location = new Point(ClientSize.Width + 18, ClientSize.Height + _mainWindow.Height);
            _restartButton.Anchor = AnchorStyles.None;
            _restartButton.Click += new EventHandler(btn_restart_Click);
            
            // Initialisation de la TextBox en utilisant notre classe
            _textBox = new TextBox();
            _textBox.Location = new Point((ClientSize.Width - _textBox.Width) / 2, _mainWindow.Location.Y - 50);
            _textBox.Anchor = AnchorStyles.None;
            _textBox.Text = generation.ToString();
            
            // Ajout des éléments à notre fenêtre
            Controls.Add(_mainWindow);
            Controls.Add(_textBox);
            Controls.Add(_playButton);
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
            _game.RunGame();
            _mainWindow.Invalidate();
            
            // Incrémentation de 1 de la variable generation
            generation++;
            
            // Mise à jour du label avec la valeur contenue dans generation
            _textBox.Text = generation.ToString();

            //Mise à jour de la fenêtre graphique
            _mainWindow.Refresh();
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            _timer.Start();
            Controls.Remove(_playButton);
            Controls.Add(_pauseButton);
            Controls.Remove(_restartButton);
        }
        
        private void btn_pause_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            Controls.Remove(_pauseButton);
            Controls.Add(_playButton);
            Controls.Add(_restartButton);
        }
        
        private void btn_restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Controls.Remove(_pauseButton);
            Controls.Add(_playButton);
            Controls.Remove(_restartButton);
        }

        private void _mainWindow_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(_mainWindow.BackColor);
            // Définir une brush blanche
            Brush whiteBrush = Brushes.White;

            // Boucler sur l’ensemble de la grille
            for(int i = 0; i < _game.grid._n; i++)
            {
                for (int j = 0; j < _game.grid._n; j++)
                {
                    // Si la cellule à cet emplacement est vivante
                    if (_game.grid.TabCells[i, j].isAlive)
                        // Dessiner un rectangle plein à partir de la brush blanche de 5 par 5 pixels
                        g.FillRectangle(whiteBrush, 5 * i, 5 * j, 5, 5);
                }
            }
        }
    }
}

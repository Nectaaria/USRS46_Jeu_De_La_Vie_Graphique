using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using USRS46_Jeu_De_La_Vie_Graphique.Controls;

namespace USRS46_Jeu_De_La_Vie_Graphique
{

    public class Game
    {
        private Random rnd = new Random();
        // taille de la grille
        private int n;
        // nombre d’itérations de la simulation
        private int iter;
        // grille des emplacements possibles
        public Grid grid;
        // liste des coordonnées des cellules vivantes en début de simulation.
        private readonly List<Coords> AliveCellsCoords;

        // Constructeur de la class Game
        public Game(int nbCells, int nbIterations)
        {
            n = nbCells;
            iter = nbIterations;
            AliveCellsCoords = new List<Coords>();

            for (int i = 0; i < rnd.Next(100, 200); i++)
            {
                int x = rnd.Next(n);
                int y = rnd.Next(n);
                AliveCellsCoords.Add(new Coords(x, y));
            }

            grid = new Grid(n, AliveCellsCoords);

            foreach (Coords coords in AliveCellsCoords)
            {
                grid.TabCells[coords._x, coords._y].ComeAlive();
            }
        }

        // Méthode de supervisation qui implémente le mécanisme au coeur de la simulation d’après les étapes suivantes.
        public void RunGameConsole()
        {
                grid.UpdateGrid();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using USRS46_Jeu_De_La_Vie_Graphique.Controls;

namespace USRS46_Jeu_De_La_Vie_Graphique
{

    public class Game
    {
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
            AliveCellsCoords = new List<Coords>() { new Coords(1, 2), new Coords(2, 2), new Coords(3, 2) };

            grid = new Grid(nbCells, AliveCellsCoords);
        }

        // Méthode de supervisation qui implémente le mécanisme au coeur de la simulation d’après les étapes suivantes.
        public void RunGameConsole()
        {
            // Affiche en console une représentation graphique de la grille et des cellules vivantes.
            grid.DisplayGrid();
            for (int i = 0; i < iter; i++)
            {
                /* Applique les règles du jeu et détermine quelles seront les cellules vivantes au prochain pas de la
                simulation. */
                grid.UpdateGrid();
                grid.DisplayGrid();
                // Met en pause le programme 1s avant d’entamer le prochain passage dans la boucle.
                Thread.Sleep(1000);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USRS46_Jeu_De_La_Vie_Graphique.Controls;

namespace USRS46_Jeu_De_La_Vie_Graphique
{
    public class Grid
    {
        // taille de la grille
        public int _n { get; set; }

        // Tableau à deux dimensions contenant des objets de type Cell
        public Cell[,] TabCells;

        // Constructeur de la classe Grid
        public Grid(int nbCells, List<Coords> AliveCellsCoords)
        {
            // Initialisation de l’attribut _n au travers de l’accesseur en écriture
            this._n = nbCells;

            // Création d’un tableau à deux dimensions de taille _n,_n
            TabCells = new Cell[_n, _n];

            /* Remplissage du tableau avec à chaque emplacement une instance d’une cellule Cell créée vivante (true) si les
            coordonnées sont dans la liste AliveCellsCoords ou absente (false) sinon. */
            for (int i = 1; i <= _n; i++)
            {
                for (int j = 1; j <= _n; j++)
                {
                    TabCells[i - 1, j - 1] = new Cell(AliveCellsCoords.Exists(coords => coords._x == j && coords._y == i));
                }
            }
        }

        // Méthode qui permet de déterminer le nombre de cellules vivantes autour d’un emplacement de coordonnées (i,j)
        public int getNbAliveNeighboor(int i, int j)
        {
            int nbAliveNeighboors = 0;
            foreach (var coords in getCoordsCellsAlive())
            {
                if (getCoordsNeighboors(i, j).Exists(coordinates => coordinates._x == coords._x && coordinates._y == coords._y))
                    nbAliveNeighboors++;
            }
            return nbAliveNeighboors;
        }

        /* Méthode qui permet de déterminer toutes les coordonnées valides autour d’un emplacement de
        coordonnées (i,j) (attention à la gestion des cas particulier en bordure de grille) */
        public List<Coords> getCoordsNeighboors(int i, int j)
        {
            List<Coords> coordsNeighboors = new List<Coords>();

            for (int k = (i - 1 >= 0 ? i - 1 : i); k < (i + 1 < _n ? i + 2 : i + 1); k++)
            {
                for (int l = (j - 1 >= 0 ? j - 1 : j); l < (j + 1 < _n ? j + 2 : j + 1); l++)
                {
                    if (!(k == i && l == j))
                        coordsNeighboors.Add(new Coords(k, l));
                }
            }
            return coordsNeighboors;
        }

        public List<Coords> getCoordsCellsAlive()
        {
            List<Coords> cellsAlive = new List<Coords>();

            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _n; j++)
                {
                    if (TabCells[i, j].isAlive)
                        cellsAlive.Add(new Coords(i, j));
                }
            }

            return cellsAlive;
        }

        public void DisplayGrid()
        {
            for (int i = 0; i < _n; i++)
            {
                Console.WriteLine("+" + String.Concat(Enumerable.Repeat("---+", _n)));
                Console.Write("|");
                for (int j = 0; j < _n; j++)
                {
                    Console.Write(" " + (TabCells[i, j].isAlive ? "X" : " ") + " |");
                }
                Console.WriteLine();
            }
            Console.WriteLine("+" + String.Concat(Enumerable.Repeat("---+", _n)));
        }

        /* Méthode qui parcourt chaque cellule et qui met à jour leur attribut _nextStep, via son accesseur en écriture, en
        fonction des règles de la simulation. L’attribut est mis à true si la cellule reste en vie ou apparaît et à false si
        la cellule à cet emplacement disparaît ou reste absente. Une fois toute la grille parcourue, une deuxième passe est
        effectué pour associer la valeur de nexStep à l’attribut isAlive de chaque cellule. */
        public void UpdateGrid()
        {
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _n; j++)
                {
                    if (!TabCells[i, j].isAlive && getNbAliveNeighboor(i, j) == 3)
                        TabCells[i, j].ComeAlive();
                    else if (TabCells[i, j].isAlive && getNbAliveNeighboor(i, j) != 2 && getNbAliveNeighboor(i, j) != 3)
                        TabCells[i, j].PassAway();
                    else
                        TabCells[i, j].nextState = TabCells[i, j].isAlive;
                }
            }
            foreach (var cell in TabCells)
            {
                cell.Update();
            }
        }
    }
}

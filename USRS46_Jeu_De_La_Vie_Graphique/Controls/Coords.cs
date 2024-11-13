using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USRS46_Jeu_De_La_Vie_Graphique.Controls
{
    public struct Coords
    {
        public int _x { get; set; }
        public int _y { get; set; }

        public Coords(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            return $"Coordonnées: X = {_x} | Y = {_y}";
        }
    }
    
}

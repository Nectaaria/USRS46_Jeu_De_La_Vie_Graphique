using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USRS46_Jeu_De_La_Vie_Graphique.Controls
{
    public class Cell
    {
        public bool isAlive { get; set; }
        public bool nextState { get; set; }


        public Cell(bool state)
        {
            isAlive = state;
        }

        public void ComeAlive()
        {
            nextState = true;
        }

        public void PassAway()
        {
            nextState = false;
        }

        public void Update()
        {
            isAlive = nextState;
        }
    }
}

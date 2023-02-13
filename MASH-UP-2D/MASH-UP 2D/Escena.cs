using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASH_UP_2D
{
    public class Escena
    {
        public List<Figure> Figures;
        public List<Figure> FiguresGuardadas;
        public Escena()
        {
            Figures = new List<Figure>();
        }
        public void GuardarFiguras()
        
        {
            FiguresGuardadas = new List<Figure>();

            for (int f = 0; f < Figures.Count; f++)
            {    
                FiguresGuardadas.Add(Figures[f]);
            }
           
        }


    }
}

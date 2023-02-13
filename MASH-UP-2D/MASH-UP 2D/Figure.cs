using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASH_UP_2D
{
    public class Figure
    {
        public List<PointF> puntos;
        public PointF centroid, last;

        //Haremos arrays para cada dato que podamos necesitar
        public bool[] animFramesGuardados; //este será para facilitarnos saber si ya guardamos algo en un frame o no
        public PointF[] animPosiciones;
        public float[] animRotaciones;
        public float[] animEscalas;

        //Historial de Cambios
        public float rotacionActual = 0;
        public float escalaActual = 1;

        public Figure(MashUp formBase) 
        {
            puntos= new List<PointF>();

            int frames = formBase.scrollAnimacion.Maximum + 1; //El tamaño de datos que necesitaremos será la cantidad de frames necesarios, así si haces mas grande la barra podrás tener mas frames sin problema
            animFramesGuardados = new bool[frames];
            animPosiciones = new PointF[frames];
            animRotaciones = new float[frames];
            animEscalas = new float[frames];

            //vovlemos todos los frames falso, para indicar que no hay nada guardado
            for (int i = 0; i < frames - 1; i++)
            {
                animFramesGuardados[i] = false;
            }
        }

        public void AddFigure(PointF a)
        {
            puntos.Add(a);
            centroid = new PointF();
            GetCenter();

            last = a; 
        }

        public void GetCenter()
        {
            for (int p = 0; p < puntos.Count; p++)
            {
                centroid.X += puntos[p].X;
                centroid.Y += puntos[p].Y;
            }

            centroid.X /= puntos.Count;
            centroid.Y /= puntos.Count;
        }

        public void Scale(float value)
        {
            for (int p = 0; p < puntos.Count; p++)
            {
                puntos[p] = new PointF(puntos[p].X * value, puntos[p].Y * value);
            }
        }

        public void Rotate(float angle)
        {
            for (int p = 0; p < puntos.Count; p++)
                puntos[p] = Util.Ins.Rotate(puntos[p], angle);
        }

        public void TranslatePoints(PointF a)
        {
            for (int p = 0; p < puntos.Count; p++)
            {
                puntos[p] = new PointF(puntos[p].X + a.X, puntos[p].Y + a.Y);
            }
        }

        public void TranslateToOrigin()
        {
            for (int p = 0; p < puntos.Count; p++)
            {
                puntos[p] = new PointF(puntos[p].X - centroid.X, puntos[p].Y - centroid.Y);
            }
        }

        public void UpdateAttributes()
        {
            centroid = new PointF();

            for (int p = 0; p < puntos.Count; p++)
            {
                centroid.X += puntos[p].X;
                centroid.Y += puntos[p].Y;
            }
            if(puntos.Count > 0)
                last = puntos[puntos.Count - 1];

            centroid.X /= puntos.Count;
            centroid.Y /= puntos.Count;
        }

        public void UpdateCentroid(float x, float y)
        {
            centroid.X = x; 
            centroid.Y = y;
        }

        //Añadido
        public void Follow(PointF a, PointF b, float value)
        {
            PointF pos = Util.Ins.NextStep(a, b, value);

            TranslateToOrigin();
            TranslatePoints(pos);
            UpdateAttributes();
        }
    }
}

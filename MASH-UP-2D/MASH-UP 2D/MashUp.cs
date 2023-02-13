
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MASH_UP_2D
{
    public partial class MashUp : Form
    {
        //Base
        Figure figure;
        Canvas c;     
        Escena escena;

        Bitmap bmpY, bmpX;
        Graphics gY, gX;

        //Posiciones de Mouse
        bool mouseDown = false;
        bool mouseDownY = false;
        bool ButtonPress = false;

        bool IsMouseDownX = false;
        bool IsMouseDownY = false;

        Point ptX, ptY, mouse;

        //Cambios
        float deltaX = 0;
        float deltaY = 1;

        //Animacion
        private bool play = false;
        int frameTotal;

        public MashUp()
        {
            InitializeComponent();
            Init();
            mouseDown = false;
            scrollAnimacion.Maximum = 100;

          
        }
        public void Init()
        {
            bmpX = new Bitmap(PCT_SLIDER_X.Width, PCT_SLIDER_X.Height);
            bmpY = new Bitmap(PCT_SLIDER_Y.Width, PCT_SLIDER_Y.Height);

            gX = Graphics.FromImage(bmpX);
            gY = Graphics.FromImage(bmpY);

            PCT_SLIDER_X.Image = bmpX;
            PCT_SLIDER_Y.Image = bmpY;

            gX.DrawLine(Pens.Black, 0, bmpX.Height / 2, bmpX.Width, bmpX.Height / 2);
            gX.FillEllipse(Brushes.Red, bmpX.Width / 2, bmpX.Height / 4, bmpX.Height / 2, bmpX.Height / 2);

            gY.DrawLine(Pens.Black, bmpY.Width / 2, 0, bmpY.Width / 2, bmpY.Height);
            gY.FillEllipse(Brushes.Red, bmpY.Width / 4, bmpY.Height / 2, bmpX.Height / 2, bmpX.Height / 2);

            escena = new Escena();
            c = new Canvas(canvas);

        }


        //-----------INTERFAZ
        //Figuras
        private void botonnewFigure_Click(object sender, EventArgs e)
        {
            newFigure(); //Lo moví a una función para que nos ea necesario crear una nueva forma la inicio
        }
        private void treeFiguras_AfterSelect(object sender, TreeViewEventArgs e)
        {
            figure = (Figure)treeFiguras.SelectedNode.Tag;
            addButton.Select();
        }

        private void newFigure()
        {
            figure = new Figure(this);
            escena.Figures.Add(figure);
            TreeNode node = new TreeNode("Fig" + (treeFiguras.Nodes.Count + 1));
            node.Tag = figure;
            treeFiguras.Nodes.Add(node);
            treeFiguras.SelectedNode = node;
        }
        

        //Canvas
        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                figure.UpdateCentroid(e.Location.X, e.Location.Y);
            }
        }

        private void canvas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (figure == null)
                newFigure(); //Si no hay figuras y das doble click, automaticamente te hace una nueva


            c.DrawPixel(e.X, e.Y, Color.White);
            figure.AddFigure(new PointF(e.X, e.Y));

        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            mouse = e.Location;
            mouseDown = true;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown && figure != null)
            {
                mouse.X -= e.X;
                mouse.Y -= e.Y;
                figure.TranslatePoints(new Point(-mouse.X, -mouse.Y));
                figure.UpdateAttributes(); //Actualizar el centroide cada vez
                mouse = e.Location;
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            canvas.Select();
        }





        //-----------Animación

        //Acutalizaciones
        private void temporizador_Tick(object sender, EventArgs e)
        {
            if (figure != null && (IsMouseDownX || IsMouseDownY))
            {
                figure.TranslateToOrigin();
                figure.Scale(deltaY);
                figure.Rotate(deltaX);
                figure.TranslatePoints(figure.centroid);

                figure.escalaActual *= deltaY; //Guarda la escala hasta que se actualice. Guardaremos las escalas para saber en que escala se encuentra en este momento ya que el delta se borra
            }

            deltaX = 0;
            deltaY = 1;
            c.Render(escena);

            /*if (ButtonPress)
            {
                c.showcanvas(escena);

            }
            */

            c.Render(escena);

            ButtonPress = false;

            if(play) //Es el encargado de la animación, si es verdadero empezará a reprodcir cuadro por cuadro y al terminar reiniciará en 0
            {
                if (scrollAnimacion.Value < scrollAnimacion.Maximum)
                {
                    scrollAnimacion.Value++;
                    Animate(); //En una función porque asi lo podremos usar manual y automaticamente
                }

                else if (scrollAnimacion.Value > 0)
                {
                    scrollAnimacion.Value = 0;
                    Animate(); //En una función porque asi lo podremos usar manual y automaticamente
                }
            }
            c.Render(escena);
        }

        private void actualizacionContinua(Figure figuraSeleccionada, float x, float y) //Funciona igual que el tick, pero solo para guardar valores, así no tenemos que esperar a la computadora para guardar valores
        {

            if (figuraSeleccionada != null)
            {
                figuraSeleccionada.TranslateToOrigin();
                figuraSeleccionada.Scale(1 / figuraSeleccionada.escalaActual); //Cada que avancemos o retrocedamos un frame de la animación, elimina la escala que tenga volviendola 1
                figuraSeleccionada.escalaActual *= 1 / figuraSeleccionada.escalaActual;
                figuraSeleccionada.Scale(y); //Para despues modificar la escala por el valor que mandamos a pedir
                figuraSeleccionada.Rotate(-figuraSeleccionada.rotacionActual + x); //Cada que avancemos o retrocedamos un frame de la animación, elimina la rotación que tenga dejandolo en el angulo 0, y despues le añade la rotación que mandamos
                figuraSeleccionada.rotacionActual = x; //una vez modificado guardamos la nueva rotacion
                figuraSeleccionada.escalaActual = y; //una vez modificado guardamos la nueva escala
                figuraSeleccionada.TranslatePoints(figuraSeleccionada.centroid);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (figure == null)
                return false;

            if (keyData == Keys.Space)
            {
                figure.UpdateAttributes();
            }
            canvas.Select();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //Scroll Animacion
        private void scrollAnimacion_Scroll(object sender, EventArgs e)
        {
            Animate(); //Lo mismo que el play pero cuando movamos manualmente la animación
        }

        private void Animate()
        {
          
            if (checkfillBlankss.Checked) //Si queremos ver todas las animaciones de las figuras a la vez
                AnimateAll();

            else 
                fillBlanks(figure);
        }

        private void AnimateAll()
        {
            foreach (Figure figuraIndividual in escena.Figures) //para cada figura existente
            {
                fillBlanks(figuraIndividual); //La misma función cada figura
            }
        }

        private void fillBlanks(Figure figuraSeleccionada)
        {
            int inicio = -1; //Guardaremos el primer frame que tenga algo guardado
            int final = -1; //Guardaremos el ultimo frame que tenga algo guardado
            float valor; //La posicion en la que estamos entre el inicial y el final, del 0 al 1 (algo asi como un porcentaje)

            float rotationAngle; //Cuanto va a rotar este frame
            float scaleFactor; //Cuanto va a escalar

            if (escena.Figures.Count == 0) //Si no tenemos figuras, evitamos el código para no tener erroes
                return;

            if (figuraSeleccionada.animFramesGuardados[scrollAnimacion.Value]) //Si la figura es un frame guardado no hace nada, ya que no requiere inicio ni fin;
                return;

            else
            {
                for (int i = scrollAnimacion.Value; i >= 0; i--) //Recorreremos todos los frames desde el que estamos hacia atras a ver cual es el que se encuentra guardado mas cercano
                {
                    if (figuraSeleccionada.animFramesGuardados[i])
                    {
                        inicio = i;

                        break;
                    }
                }

                for (int i = scrollAnimacion.Value; i <= figuraSeleccionada.animPosiciones.Length - 1; i++) //Recorreremos todos los frames desde el que estamos hacia adeltabe a ver cual es el que se encuentra guardado mas cercano
                {
                    if (figuraSeleccionada.animFramesGuardados[i])
                    {
                        final = i;
                        break;
                    }
                }
            }

            if (inicio != -1 && final != -1) //Ya que verifiquemos que hay uno inicial y un final
            {
                
                valor = ((float)scrollAnimacion.Value - inicio) / (final - inicio); //obtenemos el porcentaje de en que posicion me encuentro del inicio al final

                rotationAngle = ((figuraSeleccionada.animRotaciones[final] - figuraSeleccionada.animRotaciones[inicio]) * valor) + figuraSeleccionada.animRotaciones[inicio]; //la rotacion guardada en el frame siguiente (guardado), menos la rotacion del frame anterior (guardado) podemos obtener cuantos grados hay entre ellos. Luego obtejemos el valor del punto en el que estamos con el porcentaje. Finalmente le sumamos los grados del inicio para poder obtener la rotacion inicial
                scaleFactor = ((figuraSeleccionada.animEscalas[final] - figuraSeleccionada.animEscalas[inicio]) * valor) + figuraSeleccionada.animEscalas[inicio];

                figuraSeleccionada.Follow(figuraSeleccionada.animPosiciones[inicio], figuraSeleccionada.animPosiciones[final], valor); //Para seguir al punto que sigue (Código de tu profesor)
                actualizacionContinua(figuraSeleccionada, rotationAngle, scaleFactor); //En vez de esperar al tick, guardamos nuestros valores manualmente
            }
        }

        private void setFrameTotal_Click(object sender, EventArgs e)
        {
            try
            {
                //frameTotal = Int32.Parse(frameTotalBox.Text)*10;
                scrollAnimacion.Maximum= frameTotal;
                //labelSteps.Text = "STEP: " + scrollAnimacion.Value / 10 + "/" + scrollAnimacion.Maximum / 10;
            }
            catch(Exception) { }
        }

        

        private void AddFigureButton_Click(object sender, EventArgs e)
        {
            newFigure();
        }

        private void saveStepButton_Click(object sender, EventArgs e)
        {
            //Guarda toda la información en Arrays
            figure.animFramesGuardados[scrollAnimacion.Value] = true;
            figure.animPosiciones[scrollAnimacion.Value] = figure.centroid;
            figure.animRotaciones[scrollAnimacion.Value] = figure.rotacionActual;
            figure.animEscalas[scrollAnimacion.Value] = figure.escalaActual;
            if (scrollAnimacion.Value +10 < scrollAnimacion.Maximum)
            {
                scrollAnimacion.Value += 10;
               // labelSteps.Text = "STEP: " + scrollAnimacion.Value / 10 + "/" + scrollAnimacion.Maximum / 10;
            }
            else
            {
                scrollAnimacion.Value = scrollAnimacion.Maximum;
               // labelSteps.Text = "STEP: " + scrollAnimacion.Value / 10 + "/" + scrollAnimacion.Maximum / 10;
            }
          //  setFrameTotal.Enabled = false;
        }

        private void FormAnimacionDeFiguras_Load(object sender, EventArgs e)
        {

        }

        

        private void PCT_SLIDER_Y_MouseDown(object sender, MouseEventArgs e)
        {
            ptY = e.Location;
            IsMouseDownY = true;
        }

        private void PCT_SLIDER_Y_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDownY)
            {
                gY.Clear(Color.Transparent);
                gY.DrawLine(Pens.DimGray, bmpY.Width / 2, 0, bmpY.Width / 2, bmpY.Height);
                gY.FillEllipse(Brushes.Red, bmpY.Width / 4, e.Y, bmpX.Height / 2, bmpX.Height / 2);

                PCT_SLIDER_Y.Invalidate();
                deltaY += (float)(ptY.Y - e.Location.Y) / 500;//------------------
                ptY.Y = e.Location.Y;

            }
        }

        private void PCT_SLIDER_X_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDownX)
            {
                gX.Clear(Color.Transparent);
                gX.DrawLine(Pens.DimGray, 0, PCT_SLIDER_X.Height / 2, PCT_SLIDER_X.Width, PCT_SLIDER_X.Height / 2);
                gX.FillEllipse(Brushes.Red, e.X, PCT_SLIDER_X.Height / 4, PCT_SLIDER_X.Height / 2, PCT_SLIDER_X.Height / 2);

                PCT_SLIDER_X.Invalidate();
                deltaX += (float)(e.Location.X - ptX.X) / 3;//------------------
                ptX.X = e.Location.X;
            }
        }

        private void PCT_SLIDER_X_MoveUp(object sender, MouseEventArgs e)
        {
            IsMouseDownX = false;
            gX.Clear(Color.Transparent);
            gX.DrawLine(Pens.DimGray, 0, PCT_SLIDER_X.Height / 2, PCT_SLIDER_X.Width, PCT_SLIDER_X.Height / 2);
            gX.FillEllipse(Brushes.Red, PCT_SLIDER_X.Width / 2, PCT_SLIDER_X.Height / 4, PCT_SLIDER_X.Height / 2, PCT_SLIDER_X.Height / 2);

            PCT_SLIDER_X.Invalidate();

        }

        private void Form_Resize(object sender, EventArgs e)
        {
            c = new Canvas(canvas);
        }

        private void PCT_SLIDER_Y_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDownY = false;
            gY.Clear(Color.Transparent);
            gY.DrawLine(Pens.DimGray, bmpY.Width / 2, 0, bmpY.Width / 2, bmpY.Height);
            gY.FillEllipse(Brushes.Red, bmpY.Width / 4, bmpY.Height / 2, bmpX.Height / 2, bmpX.Height / 2);

            PCT_SLIDER_Y.Invalidate();
        }

        private void PCT_SLIDER_X_MouseDown(object sender, MouseEventArgs e)
        {
            ptX = e.Location;
            IsMouseDownX = true;
        }



        //-----------Guardado y reproducción
        private void buttonGuardarFrame_Click(object sender, EventArgs e)
        {
            //Guarda toda la información en Arrays
            figure.animFramesGuardados[scrollAnimacion.Value] = true;
            figure.animPosiciones[scrollAnimacion.Value] = figure.centroid;
            figure.animRotaciones[scrollAnimacion.Value] = figure.rotacionActual;
            figure.animEscalas[scrollAnimacion.Value] = figure.escalaActual;
            if(scrollAnimacion.Value < scrollAnimacion.Maximum)
            {
                scrollAnimacion.Value += 10;
                
            }
            //setFrameTotal.Enabled= false;
        }

        private void buttonReproducir_Click(object sender, EventArgs e)
        {
            //Cambia si reproducir o no
            play = !play;

            if (play)
            {
                buttonReproducir.Text = "PAUSA";
              //PlayState.Text = "Playing";
            }
            else
                buttonReproducir.Text = "PLAY";
        }
    }
}

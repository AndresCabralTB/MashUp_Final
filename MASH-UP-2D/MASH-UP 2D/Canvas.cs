using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using MASH_UP_2D;

namespace MASH_UP_2D
{
    public class Canvas
    {
        static Bitmap bmp, foreground;
        static Graphics g;
        int stride;
        int pixelFormatSize;
        public byte[] bits;
        PictureBox pct;

        public Canvas(PictureBox pct)
        {
            this.pct = pct;
            foreground = new Bitmap(pct.Width, pct.Height);
            bmp = new Bitmap(pct.Width, pct.Height);

            Init();
        }

        private void Init()
        {
            PixelFormat format;
            GCHandle handle;
            IntPtr bitPtr;
            int padding;

            format = PixelFormat.Format32bppArgb;

            pixelFormatSize = Image.GetPixelFormatSize(format) / 8; // 8 bits = 1 byte
            stride = bmp.Width * pixelFormatSize;              // total pixels (width) times ARGB (4)
            padding = (stride % 4);                         // PADD = move every pixel in bytes
            stride += padding == 0 ? 0 : 4 - padding;       // pad out to multiple of 4
            bits = new byte[stride * bmp.Height];
            handle = GCHandle.Alloc(bits, GCHandleType.Pinned);// TO LOCK THE MEMORY FOR GB
            bitPtr = Marshal.UnsafeAddrOfPinnedArrayElement(bits, 0);
            bmp = new Bitmap(bmp.Width, bmp.Height, stride, format, bitPtr);

            g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            pct.Image = bmp;
            pct.Invalidate();
        }

        public void DrawPixel(int x, int y, Color c)
        {
            int res = (int)((x * pixelFormatSize) + (y * stride));

            bits[res + 0] = c.B;// (byte)oldBlue;
            bits[res + 1] = c.G;// (byte)oldGreen;
            bits[res + 2] = c.R;// (byte)oldRed;
            bits[res + 3] = c.A;// (byte)oldALPHA;

            pct.Invalidate();
        }

       

        public void Render(Escena scene)
        {
            g.Clear(Color.Black);
            for (int f = 0; f < scene.Figures.Count; f++)
            {

                for (int p = 0; p < scene.Figures[f].puntos.Count; p++)
                {
                    //Draws an Ellipse for each Point of the Figure f
                    g.FillEllipse(Brushes.Violet, scene.Figures[f].puntos[p].X - 3, scene.Figures[f].puntos[p].Y - 3, 9, 9);

                }
                if (scene.Figures[f].puntos.Count > 1)
                {

                    g.FillPolygon(Brushes.DarkSlateGray, scene.Figures[f].puntos.ToArray());

                    g.DrawPolygon(Pens.Goldenrod, scene.Figures[f].puntos.ToArray());
                    g.FillEllipse(Brushes.Violet, scene.Figures[f].puntos[scene.Figures[f].puntos.Count - 1].X - 3, scene.Figures[f].puntos[scene.Figures[f].puntos.Count - 1].Y - 3, 6, 6);
                    g.FillEllipse(Brushes.Yellow, scene.Figures[f].centroid.X - 3, scene.Figures[f].centroid.Y - 3, 6, 6);//*/

                }
            }
            pct.Invalidate();
        }

    }
}

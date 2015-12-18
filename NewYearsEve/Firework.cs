using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace NewYearsEve
{
    class Firework
    {
        private static Random random = new Random();
        private float X, Y;
        private Color color;
        private float rotoff;
        public int DetonationTimer { get; private set; }

        private float wiggleDirection;

        public Firework(float X, float Y, float wiggleDirection,Color color,float rotoff)
        {
            this.X = X;
            this.Y = Y;
            this.wiggleDirection = wiggleDirection;
            this.color=color;
            this.rotoff = rotoff;
        }

        public void Move()
        {
            if (Y > 100f) DetonationTimer = 101;
            if ((DetonationTimer > 0 || (random.Next(0, 100) == 0 && Y>-30f)))
            {
                DetonationTimer += 1;
            }
            else
            {
                X += (float)Math.Sin(wiggleDirection);
                Y += (float)Math.Cos(wiggleDirection);
                if (!(Math.Abs(wiggleDirection) < 0.785398163f)) return;
                //wiggleDirection *= 1.1f;
                //return;
                if (wiggleDirection > 0)
                {
                    wiggleDirection += 0.0074532925f;
                }
                else
                {
                    wiggleDirection -= 0.0074532925f; 
                }
            }
        }

        private const double step = 0.78539816339d;

        public void Render()
        {
            GL.Color3(color);
            GL.LineWidth(3f);
            GL.Begin(PrimitiveType.Lines);
            if (DetonationTimer > 0)
            {
                //Explode
                for (var i = 0; i < 8; i++)
                {
                    var xb = Math.Cos(i * step+rotoff);
                    var yb = Math.Sin(i * step+rotoff);
                    GL.Vertex2(xb * 3 * DetonationTimer / 10 + X, yb * 3 * DetonationTimer / 10 + Y);
                    GL.Vertex2(xb * 5 * DetonationTimer / 10 + X, yb * 5 * DetonationTimer / 10 + Y);
                }
            }
            else
            {
                //Run
                GL.Vertex2(X-Math.Sin(wiggleDirection)*5,Y-Math.Cos(wiggleDirection)*5);
                GL.Vertex2(X,Y);
            }
            GL.End();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace NewYearsEve
{
    public partial class frmMain : Form
    {
        #region Variables

        private static Random random=new Random();

        private bool fireworksAdded = false;
        
        private readonly Color[] colors = {Color.Red,Color.Blue,Color.LimeGreen, Color.Yellow,Color.DeepPink};

        private GameWindow gameWindow;
        private RectangleF Bounds;
        private Rectangle ScreenBounds;

        private List<Firework> fireworks = new List<Firework>();

        //render vars

        private PointF Hours = new PointF(0f,50);
        private PointF Minutes = new PointF(10f,75f);
        private PointF Seconds = new PointF(20f, 90);

        #endregion

        public frmMain()
        {
            InitializeComponent();
            numericUpDown1.Maximum = Screen.AllScreens.Count() - 1;
        }

        private void btBegin_Click(object sender, EventArgs e)
        {
            //removing old gamewindow if exists
            if (gameWindow != null)
            {
                gameWindow.Close();
                gameWindow.Dispose();
                gameWindow = null;
            }
            //Setting up bounds
            ScreenBounds = Screen.AllScreens[(int)numericUpDown1.Value].Bounds;

            Bounds.Y = -100f;
            Bounds.Height = 200f;

            var p200 = ScreenBounds.Height/200f;
            var totalWidth = ScreenBounds.Width/p200;
            Bounds.X = -totalWidth/2;
            Bounds.Width = totalWidth;

            //Setting up gamewindow
            gameWindow = new GameWindow(ScreenBounds.Width, ScreenBounds.Height,
                new GraphicsMode(32, 24, 0, cbAntiAlias.Checked ? 4 : 0), "New Years Eve", GameWindowFlags.Fullscreen,DisplayDevice.AvailableDisplays[(int)numericUpDown1.Value]);
            gameWindow.RenderFrame += gameWindow_RenderFrame;
            gameWindow.UpdateFrame += gameWindow_UpdateFrame;
            gameWindow.KeyDown += gameWindow_KeyDown;
            //running
            gameWindow.Run(60, 60);
        }

        private void gameWindow_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Keyboard.IsKeyDown(Key.Escape))
            {
                gameWindow.Close();
            }
            if (e.Keyboard.IsKeyDown(Key.C))
            {
                gameWindow.CursorVisible =!gameWindow.CursorVisible;
            }
            if (e.Keyboard.IsKeyDown(Key.M))
            {
                createFireworks();
            }
        }

        private void createFireworks()
        {
            fireworksAdded = true;
            //add 10 fireworks when hour = 0 and fireworks haven't been added
            for (int i = 0; i < 10; i++)
            {
                fireworks.Add(new Firework(random.Next(-100, 100), -100, random.Next(-10, 10) * 0.0001f, colors[random.Next(0, colors.Count() - 1)], (float)random.NextDouble()));
            }
        }

        private void gameWindow_UpdateFrame(object sender, FrameEventArgs e)
        {
            //Remove and reacreate fireworks
            foreach (var firework in fireworks)
            {
                firework.Move();
            }
            int removed = fireworks.RemoveAll(f => f.DetonationTimer >= 60);
            for (int i=0; i < removed; i++)
            {
                fireworks.Add(new Firework(random.Next(-100,100),-100,random.Next(-10,10)*0.0001f,colors[random.Next(0,colors.Count()-1)],(float)random.NextDouble()));
            }

            var now = DateTime.Now;

            if (now.Hour == 0 && !fireworksAdded)
            {
                createFireworks();
            }

            double hour = now.Hour > 12 ? now.Hour - 12 : now.Hour;
            double minute = now.Minute;
            double second = now.Second;
            double milis = now.Millisecond;


            if (cbSmoothTime.CheckState == CheckState.Checked)
            {
                second += milis/1000;
            }
            if (cbSmoothTime.Checked)
            {
                minute += second / 60;
                hour += minute / 60f;
            }

            //seconds
            var secondAngle = DegreeToRad(second * 6d);
            Seconds = new PointF((float)Math.Sin(secondAngle) * 85f, (float)Math.Cos(secondAngle) * 85f);
            //minutes
            var minuteAngle = DegreeToRad(minute * 6d);
            Minutes = new PointF((float)Math.Sin(minuteAngle) * 75f, (float)Math.Cos(minuteAngle) * 75f);
            //hours
            var hourAngle = DegreeToRad(hour * 30d);
            Hours = new PointF((float)Math.Sin(hourAngle) * 60f, (float)Math.Cos(hourAngle) * 60f);
        }

        private void gameWindow_RenderFrame(object sender, FrameEventArgs e)
        {
            //setup viewport etc
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.ClearColor(Color.Black);
            GL.Ortho(Bounds.Left, Bounds.Right, Bounds.Top, Bounds.Bottom, -1, 1);
            GL.Viewport(0, 0, ScreenBounds.Width, ScreenBounds.Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            if (cbLogo.Checked)
            {
                //UtjMeel Logo
                GL.Color3(0.1f, 0.1f, 0.1f);
                FillCircle(-10f, 0, 20, 4);
                GL.Color3(0.8f, 0.8f, 0.8f);
                FillCircle(10f, 0, 20, 4);
            }

            //Draw clock body
            GL.LineWidth(8f);
            GL.Color3(Color.White);
            DrawCircle(0f, 0f, 90f, 4);

            //Draw lines of 15 minutes
            GL.LineWidth(6f);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(0f, 90f); GL.Vertex2(0f, 80f);
            GL.Vertex2(0f, -90f); GL.Vertex2(0f, -80f);
            GL.Vertex2(90f,0f); GL.Vertex2(80f,0f);
            GL.Vertex2(-90f,0f); GL.Vertex2(-80f,0f);
            GL.End();

            //Draw Hour handle
            GL.LineWidth(15f);
            GL.Begin(BeginMode.Lines);
            GL.Vertex2(0f,0f);GL.Vertex2(Hours.X,Hours.Y);
            GL.End();

            //Draw minute handle
            GL.LineWidth(5f);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(0f, 0f); GL.Vertex2(Minutes.X, Minutes.Y);
            GL.End();

            //Draw second handle
            GL.Color3(Color.Red);
            GL.LineWidth(2f);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(0f, 0f); GL.Vertex2(Seconds.X, Seconds.Y);
            GL.End();

            //Draw middle dot
            GL.Color3(Color.White);
            GL.PointSize(50f);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(0, 0);
            GL.End();


            //fireworks
            foreach (var firework in fireworks)
            {
                firework.Render();
            }

            gameWindow.SwapBuffers();
        }

        #region drawingCode

        /// <summary>
        /// Draws an circle on a specific position, pens and color are unchanged and used by this method
        /// </summary>
        /// <param name="x">horizontal position</param>
        /// <param name="y">vertical position</param>
        /// <param name="size">Size of circle</param>
        /// <param name="precision">amount of points to skip(preformance)</param>
        private void DrawCircle(float x, float y, float size, int precision)
        {
            double rad;
            GL.Begin(PrimitiveType.LineLoop);
            for (var i = 0; i < 360; i += precision)
            {
                rad = DegreeToRad(i);
                GL.Vertex2(Math.Cos(rad)*size + x, Math.Sin(rad)*size + y);
            }
            GL.End();
        }

        /// <summary>
        /// Fills an cirlce on a specific position, pens and color are unchanged and used by this method
        /// </summary>
        /// <param name="x">horizontal position</param>
        /// <param name="y">vertical position</param>
        /// <param name="size">Size of circle</param>
        /// <param name="precision">amount of points to skip(preformance)</param>
        private void FillCircle(float x, float y, float size, int precision)
        {
            double rad;
            GL.Begin(PrimitiveType.TriangleFan);
            for (var i = 0; i < 360; i += precision)
            {
                rad = DegreeToRad(i);
                GL.Vertex2(Math.Cos(rad) * size + x, Math.Sin(rad) * size + y);
            }
            GL.End();
        }

        #endregion

        #region caclulateFuncions

        //Constant for degreeToRad
        private const double DegreeToRadConst = (Math.PI/180);

        /// <summary>
        /// Converts a degree to radians
        /// </summary>
        /// <param name="degree">input degree</param>
        /// <returns></returns>
        private double DegreeToRad(double degree)
        {
            return DegreeToRadConst*degree;
        }

        //Constant for degreeToRadF
        private const float DegreeToRadConstF = (float) (Math.PI/180);

        /// <summary>
        /// Converts a degree to radians(float version)
        /// </summary>
        /// <param name="degree">input degree</param>
        /// <returns></returns>
        private float DegreeToRadF(int degree)
        {
            return DegreeToRadConstF*degree;
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createFireworks();
        }
    }
}
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schipor
{
    class Fereastra3D:GameWindow

    {
        Color DEFAULT_COLOR = Color.AliceBlue;
        Randomizer rando;
        KeyboardState priviewsKeyboard;
        MouseState priviewsMouse;
        private Triunghi triunghi1;
        public Fereastra3D(): base(1080, 720, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;
            displayHelp();
            rando = new Randomizer();
            triunghi1 = new Triunghi(rando);

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.ClearColor(Color.AliceBlue);

            GL.Viewport(0, 0, this.Width, this.Height);

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / (float)this.Height, 1, 250);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            Matrix4 camera = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref camera);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState CurrentKeyBoard = Keyboard.GetState();
            MouseState CurrentMouse = Mouse.GetState();

            if (CurrentKeyBoard[Key.Escape])
            {
                Exit();
            }
            if (CurrentKeyBoard[Key.Q] && !priviewsKeyboard[Key.Q])
            {
                displayHelp();
            }
            if (CurrentKeyBoard[Key.W] && !priviewsKeyboard[Key.W])
            {
                GL.ClearColor(rando.GenerateRandomColor());
            }
            if (CurrentKeyBoard[Key.E] && !priviewsKeyboard[Key.E])
            {
                GL.ClearColor(DEFAULT_COLOR);
               
            }
            if (CurrentKeyBoard[Key.R] && !priviewsKeyboard[Key.R])
            {
                triunghi1.DiscoModeT(rando);

            }
            if (CurrentKeyBoard[Key.T] && !priviewsKeyboard[Key.T])
            {
                triunghi1.TogglevisibilityT();

            }
            if (CurrentKeyBoard[Key.Y] && !priviewsKeyboard[Key.Y])
            {
                triunghi1.morph();

            }
            if (CurrentKeyBoard[Key.U] && !priviewsKeyboard[Key.U])
            {
                triunghi1.morph2();

            }

            if (CurrentKeyBoard[Key.I] && !priviewsKeyboard[Key.I])
            {
                triunghi1.TogglePolygonMode();

            }


            priviewsKeyboard = CurrentKeyBoard;

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            triunghi1.DrawT();

            SwapBuffers();
        }
        private void displayHelp()
        {

            Console.WriteLine("==================== MENIU ====================");
            Console.WriteLine("ESC - Iesire din program");
            Console.WriteLine("  Q - Meniu");
            Console.WriteLine("  W - Schimba culoarea fundalului");
            Console.WriteLine("  E - Revino la culoarea initiala a ecranului");
            Console.WriteLine("  R - Schimba culoarea triunghiului");
            Console.WriteLine("  T - Vizibiliutatea triunghiului");
            Console.WriteLine("  Y - Schimba forma triunghiului");
            Console.WriteLine("  U - Schimba forma triunghiului(2)");
            Console.WriteLine("  I - Schimba modul de desenare al triunghiului");
        }
    }
}

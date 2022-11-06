using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schipor
{
    class Triunghi
    {
        private Vector3 A;
        private Vector3 B;
        private Vector3 C;

        private bool visibility;
        private float size;
        private Color color;
        private float BIG_SIZE = 5.0f;
        private float DEFAULT_SIZE = 1.0f;
        private Randomizer localRando;
        private PolygonMode polMode;


        public Triunghi(Randomizer r)
        {
            A = r.GenerateRandomPoint3D();
            B = r.GenerateRandomPoint3D();
            C = r.GenerateRandomPoint3D();

            visibility = true;
            size = DEFAULT_SIZE;
            color = r.GenerateRandomColor();
            localRando = r;
            polMode = PolygonMode.Fill;



        }
        public void DrawT()
        {
            if (visibility)
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, polMode);
                GL.PointSize(size);
                GL.Begin(PrimitiveType.Triangles);
                GL.Color3(color);
                GL.Vertex3(A);
                GL.Vertex3(B);
                GL.Vertex3(C);
                GL.End();

            }
        }

        public void TogglePolygonMode()
        {
            if (polMode == PolygonMode.Fill)
            {
                polMode = PolygonMode.Line;
            }
            else if (polMode == PolygonMode.Line)
            {
                polMode = PolygonMode.Point;
            }
            else
            {
                polMode = PolygonMode.Fill;
            }
        }

        public void TogglevisibilityT()
        {
            visibility = !visibility;
        }

       

        public void DiscoModeT(Randomizer r)
        {
            color = r.GenerateRandomColor();
        }

        public void morph()
        {
            int select = localRando.GeneratePositiveInt(3);
            Vector3 tmp = localRando.GenerateRandomPoint3D();
            if (select == 0)
            {
                A = tmp;
            }
            else if (select == 1)
            {
                B = tmp;
            }
            else { C = tmp; }
        }

        public void morph2()
        {
            Vector3 tmp = localRando.GenerateRandomPoint3Dspecial(5);

            C = tmp;

        }

    }
}

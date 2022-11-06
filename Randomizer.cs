using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schipor
{
    class Randomizer
    {
        private Random r;
        private const int MIN_VAL = -25;
        private const int MAX_VAL = 25;

        public Randomizer()
        {
            r = new Random();
        }

        public Color GenerateRandomColor()
        {
            int genR;
            int genG;
            int genB;

            genR = r.Next(0, 255);
            genG = r.Next(0, 255);
            genB = r.Next(0, 255);

            Color col = Color.FromArgb(genR, genG, genB);

            return col;

        }
        public Vector3 GenerateRandomPoint3D()
        {
            int a;
            int b;
            int c;

            a = r.Next(MIN_VAL, MAX_VAL);
            b = r.Next(MIN_VAL, MAX_VAL);
            c = r.Next(MIN_VAL, MAX_VAL);

            Vector3 punct = new Vector3(a, b, c);

            return punct;

        }

        public Vector3 GenerateRandomPoint3Dspecial(int spec)
        {
            int a;
            int b;
            int c;

            a = r.Next(-1 * spec, spec);
            b = r.Next(-1 * spec, spec);
            c = r.Next(-1 * spec, spec);

            Vector3 punct = new Vector3(a, b, c);

            return punct;

        }


        public int GeneratePositiveInt(int limit)
        {
            int k = r.Next(0, limit);

            return k;
        }

    }
}

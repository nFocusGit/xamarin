using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slide03
{
    public class Vector3D
    {
        private float x, y, z;
        public float X { get { return x; } set { x = value; } }
        public float Y { get { return y; } set { y = value; } }
        public float Z { get { return z; } set { z = value; } }

        public Vector3D(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vector3D AddVector(Vector3D vector)
        {
            Vector3D result = new Vector3D(this.x + vector.x, this.y + vector.y, this.z + vector.z);
            return result;
        }

        public float CalculateLength()
        {
            return (float) Math.Sqrt(Math.Pow(x, 2) + y*y + z*z);
        }

    }
}

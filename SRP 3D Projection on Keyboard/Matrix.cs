using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SRP_3D_Projection_on_Keyboard {
    class Matrix {

        //Matrix multiplikation
        public static void Multiply(float[][] a, float[][] b) {
            var aRow = a[0].Length;
            var aCol = a.Length;

            var bRow = b[0].Length;
            var bCol = b.Length;

        }

        //Matrix rotation 
        public static PointF3D Rotate(PointF3D rotation, PointF3D vertex) {
            return null;
        }

        //Matrix projektion
        public static PointF Project(PointF3D vertex) {
            return new PointF();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SRP_3D_Projection_on_Keyboard {
    class Matrix {

        //Matrix multiplikation
        public static float[,] Multiply(float[,] a, float[,] b) {
            var aRows = a.GetLength(0);
            var aCols = a.GetLength(1);

            var bRows = b.GetLength(0);
            var bCols = b.GetLength(1);

            if (aCols != bRows)
            {
                Console.WriteLine("Columns of A must match rows of B");
                return null;
            }

            float[,] result = new float[aRows, bCols];

            for (int i = 0; i < aRows; i++) {
                for (int j = 0; j < bCols; j++) {

                    float sum = 0;

                    for (int k = 0; k < aCols; k++) {
                        sum += a[i, k] * b[k, j];
                    }

                    result[i, j] = sum;
                }
            }

            return result;
        }

        //Matrix rotation 
        public static PointF3D Rotate(PointF3D rotation, PointF3D vertex) {
            return null;
        }

        //Matrix projektion
        public static PointF Project(PointF3D vertex) {
            float[,] projectionM = {
                    {1, 0, 0},
                    {0, 1, 0}
            };

            return Matrix.Multiply(projectionM, vertex);
        }

        public static float[,] ToMatrix(PointF3D p) {
            float[,] m = new float[3, 1];
            m[0, 0] = p.x;
            m[1, 0] = p.y;
            m[2, 0] = p.z;
            return m;
        }

        public static float[,] ToMatrix(PointF p) {
            float[,] m = new float[2, 1];
            m[0, 0] = p.X;
            m[1, 0] = p.Y;
            return m;
        }

        public static PointF3D ToPoint3D(float[,] m) {
            var p = new PointF3D();
            p.x = m[0, 0];
            p.y = m[1, 0];
            p.z = m[2, 0];
            return p;
        }

        public static PointF ToPoint(float[,] m) {
            var p = new PointF();
            p.X = m[0, 0];
            p.Y = m[1, 0];
            return p;
        }

        public static PointF Multiply(float[,] a, PointF3D b) {
            return ToPoint(Multiply(a, ToMatrix(b)));
        }

        public static void Log(float[,] m) {
            var rows = m.GetLength(0);
            var cols = m.GetLength(1);

            Console.WriteLine(rows + "x" + cols);
            Console.WriteLine("----------------");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(m[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void Log(PointF3D p) {
            Log(ToMatrix(p));
        }

        public static void Log(PointF p)
        {
            Log(ToMatrix(p));
        }
    }
}
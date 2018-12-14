using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SRP_3D_Projection_on_Keyboard.Basic_Projection;

namespace SRP_3D_Projection_on_Keyboard.Different_Platforms.Console {
    public class Draw {
        ConsoleColor[,] DrawMatrix;
        Size canvSize;

        public Draw(Size canvSize) {
            this.canvSize = canvSize;
            System.Console.CursorVisible = false;
        }

        public void Update() {
            System.Console.Clear();

            var rows = DrawMatrix.GetLength(1);
            var cols = DrawMatrix.GetLength(0);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    System.Console.ForegroundColor = DrawMatrix[j, i];
                    System.Console.Write("■ ");
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
        }

        //Clear Console
        public void Clear() {
            DrawMatrix = new ConsoleColor[canvSize.Width, canvSize.Height];
        }

        //Draw points(ps) with color(c) on keyboard(k)
        public void DrawAt(ConsoleColor c, PointF[] ps) {
            foreach (var p in ps) {
                DrawAt(c, (int)p.X, (int)p.Y);
            }
        }

        //Draw points(ps) with color(c) and offset on keyboard(k)
        public void DrawAt(ConsoleColor c, PointF[] ps, PointF offset) {
            foreach (var p in ps) {
                DrawAt(c, (int)(p.X + offset.X), (int)(p.Y + offset.Y));
            }
        }

        //Draw point(p) with color(c) on keyboard(k)
        public void DrawAt(ConsoleColor c, PointF p) {
            DrawAt(c, (int)p.X, (int)p.Y);
        }

        //Draw line between pStart and pEnd with color(c) on keyboard(k)
        public void DrawLineAt(ConsoleColor c, PointF pStart, PointF pEnd) {
            int res = 200;
            for (int x = 0; x < res; x++) {
                DrawAt(c, PointF3D.Lerp(pStart, pEnd, x / (float)res));
            }
        }

        //W:23 H:6 hvor 7 punkter ikke er der, og nogle punkter med samme lys, da de dækker over mere.
        public void DrawAt(ConsoleColor c, int x, int y) {
            try { DrawMatrix[x, y] = c; } catch { }
        }
    }
}

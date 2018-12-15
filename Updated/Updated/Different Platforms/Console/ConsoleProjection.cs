using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SRP_3D_Projection_on_Keyboard.Basic_Projection;

namespace SRP_3D_Projection_on_Keyboard.Different_Platforms.Console {
    class Projection {
        public static void Main(Model model) {
            model.Translation(new PointF(22, 12)); //Flyt den ind i midten af tastaturet
            model.Translation(new PointF3D(0,-200)); //Flyt modellen
            model.Rotation(new PointF3D(0,0,(float)Math.PI));
            model.Scaler(0.01f);
            const double rotateAmount = 128d;
            var canvSize = new Size(55, 25);
            var canvas = new Draw(canvSize);

            while (true) {
                model.RotateBy(new PointF3D((float)(Math.PI / rotateAmount), (float)(Math.PI / rotateAmount), (float)(Math.PI / rotateAmount)));
                canvas.Clear();
                model.Draw(canvas, ConsoleColor.Red, ConsoleColor.Green);
                canvas.Update();
            }
        }
    }
}
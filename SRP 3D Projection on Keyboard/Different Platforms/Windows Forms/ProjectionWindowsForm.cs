using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SRP_3D_Projection_on_Keyboard.Basic_Projection;

namespace SRP_3D_Projection_on_Keyboard.Different_Platforms.WindowsForm {
    class Projection {
        public static void Main(Model model) {
            model.Translation(new PointF(6, 2)); //Flyt den ind i midten af tastaturet
            model.Translation(new PointF3D(0)); //Flyt modellen

            while (true) {
                model.RotateBy(new PointF3D(/*(float)(Math.PI / 32d)*/0, (float)(Math.PI / 32d), (float)(Math.PI / 32d)));

                //Console.WriteLine("Model points");
                //foreach (var point in model.GetPoints()) {
                //    Matrix.Log(point);
                //}

                //Console.WriteLine("Translator");
                //Matrix.Log(model.GetTranslater());

                //Console.WriteLine("Translator2D");
                //Matrix.Log(model.GetTranslater2D());

                //Console.WriteLine("Rotation");
                //Matrix.Log(model.GetRotation());

                System.Console.Clear();

                model.Draw(, Color.Red, Color.Green);

                Thread.Sleep((int)(0.1*1000));
            }
            System.Console.Read();
        }
    }
}
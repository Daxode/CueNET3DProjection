﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SRP_3D_Projection_on_Keyboard.Basic_Projection;

namespace SRP_3D_Projection_on_Keyboard.Different_Platforms.WindowsForm {
    class Projection {
        public static void Main(Model model) {
            System.Console.Clear();
            var canvas = new WindowsForms(model);
            canvas.ShowDialog();
        }

        //Windows forms skal selv kører det
        public static void ActualStuff(Model model, WindowsForms canvas) {
            model.Translation(new PointF(200, 200)); //Flyt den ind i midten af tastaturet
            model.Translation(new PointF3D(0)); //Flyt modellen
            model.Scaler(100.0f);
            double rotateAmount = 64d;

            while (true)
            {
                model.RotateBy(new PointF3D((float)(Math.PI / rotateAmount), (float)(Math.PI / rotateAmount), (float)(Math.PI / rotateAmount)));

                canvas.Clear();
                model.Draw(canvas, Color.Red, Color.Green);

                Thread.Sleep((int)(0.03 * 1000));
            }
        }
    }
}
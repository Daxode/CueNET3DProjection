using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CUE.NET;
using CUE.NET.Brushes;
using CUE.NET.Devices;
using CUE.NET.Devices.Generic;
using CUE.NET.Devices.Generic.Enums;
using CUE.NET.Effects;
using CUE.NET.Exceptions;
using CUE.NET.Gradients;
using CUE.NET.Groups;
using CUE.NET.Devices.Keyboard;
using CUE.NET.Devices.Keyboard.Enums;
using CUE.NET.Devices.Mouse;
using CUE.NET.Devices.Mouse.Enums;
using Console = System.Console;
using SRP_3D_Projection_on_Keyboard.Basic_Projection;

namespace SRP_3D_Projection_on_Keyboard.Different_Platforms.CUE {
    class Projection {
        public static void Main(Model model) {
            try {
                CueSDK.Initialize();
                System.Console.WriteLine("Initialized with " + CueSDK.LoadedArchitecture + "-SDK");

                CorsairKeyboard keyboard = CueSDK.KeyboardSDK;
                if (keyboard == null)
                    throw new WrapperException("No keyboard found");

                keyboard.Brush = (SolidColorBrush)Color.Transparent;

                model.Translation(new PointF(10, 3)); //Flyt den ind i midten af tastaturet
                model.Translation(new PointF3D(0)); //Flyt modellen
                model.Scaler(2.0f);

                while (true) {
                    model.RotateBy(new PointF3D(/*(float)(Math.PI / 32d)*/0, (float)(Math.PI / 32d), (float)(Math.PI / 32d)));

                    Draw.LEDClear(keyboard);
                    System.Console.Clear();

                    //System.Console.WriteLine("Model points");
                    //foreach (var point in model.GetPoints()) {
                    //    Matrix.Log(point);
                    //}

                    System.Console.WriteLine("Scaler");
                    Matrix.Log(model.GetScaler());

                    System.Console.WriteLine("Translator");
                    Matrix.Log(model.GetTranslater());

                    System.Console.WriteLine("Translator2D");
                    Matrix.Log(model.GetTranslater2D());

                    System.Console.WriteLine("Rotation");
                    Matrix.Log(model.GetRotation());

                    model.Draw(keyboard, Color.Red, Color.Green);
                    keyboard.Update();

                    Thread.Sleep((int)(0.1*1000));
                }

            } catch (CUEException ex) {
                System.Console.WriteLine("CUE Exception! ErrorCode: " + Enum.GetName(typeof(CorsairError), ex.Error));
            } catch (WrapperException ex) {
                System.Console.WriteLine("Wrapper Exception! Message:" + ex.Message);
            }

            System.Console.Read();
        }
    }
}
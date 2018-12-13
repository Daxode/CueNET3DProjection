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

namespace SRP_3D_Projection_on_Keyboard {
    class Program {
        static void Main(string[] args) {
            Random rd = new Random();

            try {
                CueSDK.Initialize();
                Console.WriteLine("Initialized with " + CueSDK.LoadedArchitecture + "-SDK");

                CorsairKeyboard keyboard = CueSDK.KeyboardSDK;
                if (keyboard == null)
                    throw new WrapperException("No keyboard found");

                keyboard.Brush = (SolidColorBrush)Color.Transparent;

                //Dette er en simpel kasse
                PointF3D[] modelVertexes = {
                    new PointF3D(-2f,  2f, -2f), //Back upper left
                    new PointF3D( 2f,  2f, -2f), //Back upper right
                    new PointF3D(-2f, -2f, -2f), //Back lower left
                    new PointF3D( 2f, -2f, -2f), //Back lower right

                    new PointF3D(-1,  1, 1), //Front upper left
                    new PointF3D( 1,  1, 1), //Front upper right
                    new PointF3D(-1, -1, 1), //Front lower left
                    new PointF3D( 1, -1, 1), //Front lower right
                };

                Model model = new Model(modelVertexes); //Skab modellen med sine vertexer
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

                    Draw.LEDClear(keyboard);
                    Console.Clear();

                    model.Draw(keyboard, Color.Red, Color.Green);
                    keyboard.Update();

                    Thread.Sleep((int)(0.1*1000));
                }

            } catch (CUEException ex) {
                Console.WriteLine("CUE Exception! ErrorCode: " + Enum.GetName(typeof(CorsairError), ex.Error));
            } catch (WrapperException ex) {
                Console.WriteLine("Wrapper Exception! Message:" + ex.Message);
            }

            Console.Read();
        }

        public static PointF Lerp(PointF fP, PointF sP, float by) {
            float retX = Lerp(fP.X, sP.X, by);
            float retY = Lerp(fP.Y, sP.Y, by);
            return new PointF(retX, retY);
        }

        public static float Lerp(float firstFloat, float secondFloat, float by) {
            return firstFloat * (1 - by) + secondFloat * by;
        }
    }
}
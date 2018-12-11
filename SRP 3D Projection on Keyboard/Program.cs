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
                while (true) {
                    var p1 = new PointF(0.0f, 0.0f);
                    var p2 = new PointF(22.0f, 5.0f);
                    var p3 = new PointF(0.0f, 5.0f);
                    var p4 = new PointF(22.0f, 0.0f);

                    for (int x = 0; x < 23; x++) {
                        //LEDClear(keyboard);

                        Draw.LEDDrawAt(keyboard, Color.Green, Lerp(p1, p2, x/23.0f));
                        Draw.LEDDrawAt(keyboard, Color.Blue, Lerp(p1, p3, x / 23.0f));
                        Draw.LEDDrawAt(keyboard, Color.Purple, Lerp(p1, p4, x / 23.0f));
                        Draw.LEDDrawAt(keyboard, Color.Purple, Lerp(p2, p3, x / 23.0f));
                        Draw.LEDDrawAt(keyboard, Color.Blue, Lerp(p2, p4, x / 23.0f));
                        Draw.LEDDrawAt(keyboard, Color.Green, Lerp(p3, p4, x / 23.0f));
                    }

                    Draw.LEDDrawAt(keyboard, Color.Red, p1);
                    Draw.LEDDrawAt(keyboard, Color.Red, p2);
                    Draw.LEDDrawAt(keyboard, Color.Red, p3);
                    Draw.LEDDrawAt(keyboard, Color.Red, p4);
                    keyboard.Update();
                }

            } catch (CUEException ex) {
                Console.WriteLine("CUE Exception! ErrorCode: " + Enum.GetName(typeof(CorsairError), ex.Error));
            } catch (WrapperException ex) {
                Console.WriteLine("Wrapper Exception! Message:" + ex.Message);
            }

            Console.Read();
        }

        private static void LEDClear(CorsairKeyboard keyboard) {
            keyboard.RestoreColors();
            keyboard.Update();
        }

        private static PointF Lerp(PointF fP, PointF sP, float by) {
            float retX = Lerp(fP.X, sP.X, by);
            float retY = Lerp(fP.Y, sP.Y, by);
            return new PointF(retX, retY);
        }

        private static float Lerp(float firstFloat, float secondFloat, float by) {
            return firstFloat * (1 - by) + secondFloat * by;
        }
    }
}
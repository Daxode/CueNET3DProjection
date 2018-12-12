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

                    keyboard.Update();
                }

            } catch (CUEException ex) {
                Console.WriteLine("CUE Exception! ErrorCode: " + Enum.GetName(typeof(CorsairError), ex.Error));
            } catch (WrapperException ex) {
                Console.WriteLine("Wrapper Exception! Message:" + ex.Message);
            }

            Console.Read();
        }

        public static void LEDClear(CorsairKeyboard keyboard) {
            keyboard.RestoreColors();
            keyboard.Update();
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
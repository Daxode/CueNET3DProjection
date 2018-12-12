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
    class Draw {
        public static void LEDDrawAt(CorsairKeyboard k, Color c, PointF[] ps) {
            foreach (var p in ps) {
                LEDDrawAt(k, c, (int)p.X, (int)p.Y); 
            }
        }

        public static void LEDDrawAt(CorsairKeyboard k, Color c, PointF p)  {
            LEDDrawAt(k, c, (int)p.X, (int)p.Y);
        }

        public static void LEDDrawLineAt(CorsairKeyboard k, Color c, PointF pStart, PointF pEnd) {
            int res = 23;
            for (int x = 0; x < res; x++) {
                Draw.LEDDrawAt(k, c, Program.Lerp(pStart, pEnd, x / (float)res));
            }
        }

        //W:23 H:6 hvor 7 punkter ikke er der, og nogle punkter med samme lys, da de dækker over mere.
        public static void LEDDrawAt(CorsairKeyboard k, Color c, int x, int y) {
            switch (y) {
                default:
                    switch (x) {
                        default:
                            k[CorsairKeyboardLedId.G3].Color = c;
                            break;
                        case 1:
                            k[CorsairLedId.Escape].Color = c;
                            break;
                        case 2:
                            //k[CorsairLedId.Escape].Color = c;
                            break;
                        case 3:
                            k[CorsairLedId.F1].Color = c;
                            break;
                        case 4:
                            k[CorsairLedId.F2].Color = c;
                            break;
                        case 5:
                            k[CorsairLedId.F3].Color = c;
                            break;
                        case 6:
                            k[CorsairLedId.F4].Color = c;
                            break;
                        case 7:
                            k[CorsairLedId.F5].Color = c;
                            break;
                        case 8:
                            k[CorsairLedId.F6].Color = c;
                            break;
                        case 9:
                            k[CorsairLedId.F7].Color = c;
                            break;
                        case 10:
                            k[CorsairLedId.F8].Color = c;
                            break;
                        case 11:
                            //k[CorsairLedId.Escape].Color = c;
                            break;
                        case 12:
                            k[CorsairLedId.F9].Color = c;
                            break;
                        case 13:
                            k[CorsairLedId.F10].Color = c;
                            break;
                        case 14:
                            k[CorsairLedId.F11].Color = c;
                            break;
                        case 15:
                            k[CorsairLedId.F12].Color = c;
                            break;
                        case 16:
                            k[CorsairLedId.PrintScreen].Color = c;
                            break;
                        case 17:
                            k[CorsairLedId.ScrollLock].Color = c;
                            break;
                        case 18:
                            k[CorsairLedId.PauseBreak].Color = c;
                            break;
                        case 19:
                            k[CorsairLedId.Stop].Color = c;
                            break;
                        case 20:
                            k[CorsairLedId.ScanPreviousTrack].Color = c;
                            break;
                        case 21:
                            k[CorsairLedId.PlayPause].Color = c;
                            break;
                        case 22:
                            k[CorsairLedId.ScanNextTrack].Color = c;
                            break;
                    }
                    break;

                case 1:
                    switch (x) {
                        default:
                            k[CorsairLedId.G6].Color = c;
                            break;
                        case 1:
                            k[CorsairLedId.GraveAccentAndTilde].Color = c;
                            break;
                        case 2:
                            k[CorsairLedId.D1].Color = c;
                            break;
                        case 3:
                            k[CorsairLedId.D2].Color = c;
                            break;
                        case 4:
                            k[CorsairLedId.D3].Color = c;
                            break;
                        case 5:
                            k[CorsairLedId.D4].Color = c;
                            break;
                        case 6:
                            k[CorsairLedId.D5].Color = c;
                            break;
                        case 7:
                            k[CorsairLedId.D6].Color = c;
                            break;
                        case 8:
                            k[CorsairLedId.D7].Color = c;
                            break;
                        case 9:
                            k[CorsairLedId.D8].Color = c;
                            break;
                        case 10:
                            k[CorsairLedId.D9].Color = c;
                            break;
                        case 11:
                            k[CorsairLedId.D0].Color = c;
                            break;
                        case 12:
                            k[CorsairLedId.MinusAndUnderscore].Color = c;
                            break;
                        case 13:
                            k[CorsairLedId.EqualsAndPlus].Color = c;
                            break;
                        case 14:
                            k[CorsairLedId.Backspace].Color = c;
                            break;
                        case 15:
                            k[CorsairLedId.Backspace].Color = c;
                            break;
                        case 16:
                            k[CorsairLedId.Insert].Color = c;
                            break;
                        case 17:
                            k[CorsairLedId.Home].Color = c;
                            break;
                        case 18:
                            k[CorsairLedId.PageUp].Color = c;
                            break;
                        case 19:
                            k[CorsairLedId.NumLock].Color = c;
                            break;
                        case 20:
                            k[CorsairLedId.KeypadSlash].Color = c;
                            break;
                        case 21:
                            k[CorsairLedId.KeypadAsterisk].Color = c;
                            break;
                        case 22:
                            k[CorsairLedId.KeypadMinus].Color = c;
                            break;
                    } break;

                case 2:
                    switch (x) {
                        default:
                            k[CorsairLedId.G9].Color = c;
                            break;
                        case 1:
                            k[CorsairLedId.Tab].Color = c;
                            break;
                        case 2:
                            k[CorsairLedId.Q].Color = c;
                            break;
                        case 3:
                            k[CorsairLedId.W].Color = c;
                            break;
                        case 4:
                            k[CorsairLedId.E].Color = c;
                            break;
                        case 5:
                            k[CorsairLedId.R].Color = c;
                            break;
                        case 6:
                            k[CorsairLedId.T].Color = c;
                            break;
                        case 7:
                            k[CorsairLedId.Y].Color = c;
                            break;
                        case 8:
                            k[CorsairLedId.U].Color = c;
                            break;
                        case 9:
                            k[CorsairLedId.I].Color = c;
                            break;
                        case 10:
                            k[CorsairLedId.O].Color = c;
                            break;
                        case 11:
                            k[CorsairLedId.P].Color = c;
                            break;
                        case 12:
                            k[CorsairLedId.BracketLeft].Color = c;
                            break;
                        case 13:
                            k[CorsairLedId.BracketRight].Color = c;
                            break;
                        case 14:
                            k[CorsairLedId.Enter].Color = c;
                            break;
                        case 15:
                            k[CorsairLedId.Enter].Color = c;
                            break;
                        case 16:
                            k[CorsairLedId.Delete].Color = c;
                            break;
                        case 17:
                            k[CorsairLedId.End].Color = c;
                            break;
                        case 18:
                            k[CorsairLedId.PageDown].Color = c;
                            break;
                        case 19:
                            k[CorsairLedId.Keypad7].Color = c;
                            break;
                        case 20:
                            k[CorsairLedId.Keypad8].Color = c;
                            break;
                        case 21:
                            k[CorsairLedId.Keypad9].Color = c;
                            break;
                        case 22:
                            k[CorsairLedId.KeypadPlus].Color = c;
                            break;
                    } break;

                case 3:
                    switch (x) {
                        default:
                            k[CorsairLedId.G12].Color = c;
                            break;
                        case 1:
                            k[CorsairLedId.CapsLock].Color = c;
                            break;
                        case 2:
                            k[CorsairLedId.A].Color = c;
                            break;
                        case 3:
                            k[CorsairLedId.S].Color = c;
                            break;
                        case 4:
                            k[CorsairLedId.D].Color = c;
                            break;
                        case 5:
                            k[CorsairLedId.F].Color = c;
                            break;
                        case 6:
                            k[CorsairLedId.G].Color = c;
                            break;
                        case 7:
                            k[CorsairLedId.H].Color = c;
                            break;
                        case 8:
                            k[CorsairLedId.J].Color = c;
                            break;
                        case 9:
                            k[CorsairLedId.K].Color = c;
                            break;
                        case 10:
                            k[CorsairLedId.L].Color = c;
                            break;
                        case 11:
                            k[CorsairLedId.SemicolonAndColon].Color = c;
                            break;
                        case 12:
                            k[CorsairLedId.ApostropheAndDoubleQuote].Color = c;
                            break;
                        case 13:
                            k[CorsairLedId.NonUsTilde].Color = c;
                            break;
                        case 14:
                            k[CorsairLedId.Enter].Color = c;
                            break;
                        case 15:
                            k[CorsairLedId.Enter].Color = c;
                            break;
                        case 16:
                            //k[CorsairLedId.Escape].Color = c;
                            break;
                        case 17:
                            //k[CorsairLedId.Escape].Color = c;
                            break;
                        case 18:
                            //k[CorsairLedId.Escape].Color = c;
                            break;
                        case 19:
                            k[CorsairLedId.Keypad4].Color = c;
                            break;
                        case 20:
                            k[CorsairLedId.Keypad5].Color = c;
                            break;
                        case 21:
                            k[CorsairLedId.Keypad6].Color = c;
                            break;
                        case 22:
                            k[CorsairLedId.KeypadPlus].Color = c;
                            break;
                    } break;

                case 4:
                    switch (x) {
                        default:
                            k[CorsairLedId.G15].Color = c;
                            break;
                        case 1:
                            k[CorsairLedId.LeftShift].Color = c;
                            break;
                        case 2:
                            k[CorsairLedId.NonUsBackslash].Color = c;
                            break;
                        case 3:
                            k[CorsairLedId.Z].Color = c;
                            break;
                        case 4:
                            k[CorsairLedId.X].Color = c;
                            break;
                        case 5:
                            k[CorsairLedId.C].Color = c;
                            break;
                        case 6:
                            k[CorsairLedId.V].Color = c;
                            break;
                        case 7:
                            k[CorsairLedId.B].Color = c;
                            break;
                        case 8:
                            k[CorsairLedId.N].Color = c;
                            break;
                        case 9:
                            k[CorsairLedId.M].Color = c;
                            break;
                        case 10:
                            k[CorsairLedId.CommaAndLessThan].Color = c;
                            break;
                        case 11:
                            k[CorsairLedId.PeriodAndBiggerThan].Color = c;
                            break;
                        case 12:
                            k[CorsairLedId.SlashAndQuestionMark].Color = c;
                            break;
                        case 13:
                            k[CorsairLedId.RightShift].Color = c;
                            break;
                        case 14:
                            k[CorsairLedId.RightShift].Color = c;
                            break;
                        case 15:
                            k[CorsairLedId.RightShift].Color = c;
                            break;
                        case 16:
                            //k[CorsairLedId.Escape].Color = c;
                            break;
                        case 17:
                            k[CorsairLedId.UpArrow].Color = c;
                            break;
                        case 18:
                            //k[CorsairLedId.Escape].Color = c;
                            break;
                        case 19:
                            k[CorsairLedId.Keypad1].Color = c;
                            break;
                        case 20:
                            k[CorsairLedId.Keypad2].Color = c;
                            break;
                        case 21:
                            k[CorsairLedId.Keypad3].Color = c;
                            break;
                        case 22:
                            k[CorsairLedId.KeypadEnter].Color = c;
                            break;
                    } break;

                case 5:
                    switch (x) {
                        default:
                            k[CorsairLedId.G18].Color = c;
                            break;
                        case 1:
                            k[CorsairLedId.LeftCtrl].Color = c;
                            break;
                        case 2:
                            k[CorsairLedId.LeftGui].Color = c;
                            break;
                        case 3:
                            k[CorsairLedId.LeftAlt].Color = c;
                            break;
                        case 4:
                            k[CorsairLedId.Space].Color = c;
                            break;
                        case 5:
                            k[CorsairLedId.Space].Color = c;
                            break;
                        case 6:
                            k[CorsairLedId.Space].Color = c;
                            break;
                        case 7:
                            k[CorsairLedId.Space].Color = c;
                            break;
                        case 8:
                            k[CorsairLedId.Space].Color = c;
                            break;
                        case 9:
                            k[CorsairLedId.Space].Color = c;
                            break;
                        case 10:
                            k[CorsairLedId.Space].Color = c;
                            break;
                        case 11:
                            k[CorsairLedId.Space].Color = c;
                            break;
                        case 12:
                            k[CorsairLedId.RightAlt].Color = c;
                            break;
                        case 13:
                            k[CorsairLedId.RightGui].Color = c;
                            break;
                        case 14:
                            k[CorsairLedId.Application].Color = c;
                            break;
                        case 15:
                            k[CorsairLedId.RightCtrl].Color = c;
                            break;
                        case 16:
                            k[CorsairLedId.LeftArrow].Color = c;
                            break;
                        case 17:
                            k[CorsairLedId.DownArrow].Color = c;
                            break;
                        case 18:
                            k[CorsairLedId.RightArrow].Color = c;
                            break;
                        case 19:
                            k[CorsairLedId.Keypad0].Color = c;
                            break;
                        case 20:
                            k[CorsairLedId.Keypad0].Color = c;
                            break;
                        case 21:
                            k[CorsairLedId.KeypadPeriodAndDelete].Color = c;
                            break;
                        case 22:
                            k[CorsairLedId.KeypadEnter].Color = c;
                            break;
                    } break;
            }
        }
    }
}
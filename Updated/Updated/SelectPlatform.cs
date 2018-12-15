using System;
using SRP_3D_Projection_on_Keyboard.Basic_Projection;
using SRP_3D_Projection_on_Keyboard.Different_Platforms;
using System.IO;
using System.Windows.Forms;

namespace SRP_3D_Projection_on_Keyboard {
    class SelectPlatform {
        static void Main(string[] args) {
            var model = AskModel();

            Console.WriteLine("Her er så selve SRP programet, det kan vises på de tre forskellige måder som er blevet programmeret");
            Console.WriteLine("Skriv 'k' for at projektere på Corsair Platinum K95 Tastaturet");
            Console.WriteLine("Skriv 'w' for at projektere i et Windows Forms vindue");
            Console.WriteLine("Skriv 'c' for at projektere i en konsol");

            while (true) {
                Console.Write("Skriv her: ");
                var which = Console.ReadKey().KeyChar;
                if (which == 'k') {
                    Different_Platforms.CUE.Projection.Main(model);
                } else if (which == 'w') {
                    Different_Platforms.WindowsForm.Projection.Main(model);
                } else if (which == 'c') {
                    Different_Platforms.Console.Projection.Main(model);
                } else {
                    Console.Write("Ikke en af valgene, ");
                }
                Console.WriteLine("prøv noget andet");
            }
        }

        public static Model AskModel() {
            Console.WriteLine("Dette er så en udvidelse af programmet, til at starte med kan du vælge om du vil prøve et projektere en kasse, et standard objekt eller et valgfrit objekt");
            Console.WriteLine("Skriv 'b' for at vælge kassen");
            Console.WriteLine("Skriv 'd' for at vælge det valgfrie objekt");
            Console.WriteLine("Alle andre taster for at vælge et objekt selv");
            Console.Write("Skriv her: ");
            var which = Console.ReadKey().KeyChar;

            if (which == 'b') {
                return GetBox();
            } else if (which == 'd') {
                float scale = 0.003f;
                PointF3D translationToMid = new PointF3D(0, -200);
                PointF3D rotation = new PointF3D(0, 0, (float)Math.PI);

                return OBJExtractor.GetModel(Path.GetFullPath(@"Files to try out\deer.obj"), translationToMid, rotation, scale);
            } else {
                string path = "";
                float scale = AskForFloatProperty("");
                PointF3D translationToMid = AskForPoint3DProperty("");
                PointF3D rotation = AskForPoint3DProperty("");

                Console.WriteLine("Super, vi prøver altså at vise fra denne sti: \n" + path + "\n");
                Console.WriteLine("Med scale: \n" + scale + "\n");

                return OBJExtractor.GetModel(path, translationToMid, rotation, scale);
            }
        }

        public static string AskForPath() {
            return "";
        }

        public static float AskForFloatProperty(string msg) {
            return 1f;
        }

        public static PointF3D AskForPoint3DProperty(string msg) {
            return null;
        }


        public static Model GetBox() {
            //Dette er en simpel kasse
            PointF3D[] modelVertexes = {
                new PointF3D(-1,  1, -1), //Back upper left
                new PointF3D( 1,  1, -1), //Back upper right
                new PointF3D(-1, -1, -1), //Back lower left
                new PointF3D( 1, -1, -1), //Back lower right

                new PointF3D(-1,  1, 1), //Front upper left
                new PointF3D( 1,  1, 1), //Front upper right
                new PointF3D(-1, -1, 1), //Front lower left
                new PointF3D( 1, -1, 1)  //Front lower right
            };

            PolyLine[] modelLines = {
                new PolyLine(0, 4),
                new PolyLine(1, 5),
                new PolyLine(2, 6),
                new PolyLine(3, 7)
            };

            PolyLine[] modelFaces = {
                new PolyLine(0, 1, 3, 2), //Front square
                new PolyLine(4, 5, 7, 6)  //Back square
            };

            return new Model(modelVertexes, modelLines, modelFaces); //Skab modellen med sine vertexer
        }
    }
}
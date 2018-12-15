using System;
using SRP_3D_Projection_on_Keyboard.Basic_Projection;
using SRP_3D_Projection_on_Keyboard.Different_Platforms;

namespace SRP_3D_Projection_on_Keyboard {
    class SelectPlatform {
        static void Main(string[] args) {
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

            //Model model = new Model(modelVertexes, modelLines, modelFaces); //Skab modellen med sine vertexer
            Model model = OBJExtractor.GetModel(@"C:\Users\dka\source\repos\CueNET3DProjection\Updated\Updated\deer.obj");

            Console.WriteLine("Her er så SRP programet, det kan vises på de tre forskellige måder som er blevet programmeret");
            Console.WriteLine("Skriv 'k' for at projektere på Corsair Platinum K95 Tastaturet");
            Console.WriteLine("Skriv 'w' for at projektere i et Windows Forms vindue");
            Console.WriteLine("Skriv 'c' for at projektere i en konsol");

            while (true) {
                Console.Write("Skriv her: ");
                var which = Console.ReadLine();
                if (which == "k") {
                    Different_Platforms.CUE.Projection.Main(model);
                } else if (which == "w") {
                    Different_Platforms.WindowsForm.Projection.Main(model);
                } else if (which == "c") {
                    Different_Platforms.Console.Projection.Main(model);
                } else {
                    Console.Write("Ikke en af valgene, ");
                }
                Console.WriteLine("prøv noget andet");
            }
        }
    }
}
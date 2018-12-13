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
                new PolyLine(0,  1, 2, 3, 0), //Front square
                new PolyLine(4,  5, 6, 7, 4)  //Back square
            };

            Model model = new Model(modelVertexes, modelLines); //Skab modellen med sine vertexer

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
                    Console.WriteLine("Ikke en af valgene, prøv igen");
                }
            }
        }
    }
}
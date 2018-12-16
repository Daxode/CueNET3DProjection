using System;
using SRP_3D_Projection_on_Keyboard.Basic_Projection;
using SRP_3D_Projection_on_Keyboard.Different_Platforms;
using System.IO;
using System.Windows.Forms;

namespace SRP_3D_Projection_on_Keyboard {
    class SelectPlatform {
        [STAThread]
        static void Main(string[] args) {
            var modelProps = new ModelProps();

            Start:
            var model = AskModel(modelProps);

            AfterAsking:
            Console.Clear();
            Console.WriteLine("Her er så selve SRP programet, det kan vises på de tre forskellige måder som er blevet programmeret");
            Console.WriteLine("Skriv 'k' for at projektere på Corsair Platinum K95 Tastaturet");
            Console.WriteLine("Skriv 'w' for at projektere i et Windows Forms vindue");
            Console.WriteLine("Skriv 'c' for at projektere i en konsol");
            Console.WriteLine("Skriv 'm' for at vælge en anden model");
            Console.WriteLine("Skriv 'p' for at ændre indstillinger på visning");

            while (true) {
                Console.Write("Skriv her: ");
                var which = Console.ReadKey().KeyChar;
                Console.WriteLine("");
                model.properties = modelProps;
                if (which == 'k') {
                    Different_Platforms.CUE.Projection.Main(model);
                } else if (which == 'w') {
                    Different_Platforms.WindowsForm.Projection.Main(model);
                } else if (which == 'c') {
                    Different_Platforms.Console.Projection.Main(model);
                } else if (which == 'm') {
                    goto Start;
                } else if (which == 'p') {
                    AskModelProps(modelProps);
                    goto AfterAsking;
                } else {
                    Console.Write("Ikke en af valgene, ");
                }
                Console.WriteLine("prøv noget andet");
            }
        }

        public static void AskModelProps(ModelProps props) {
            Console.Clear();
            Console.WriteLine("Her er der 7 instillinger at komme igennem.");
            props.displayCenterOfRotation = AskBool("Her angives om man ønsker at tegne punktet der roteres omkring.","Vis center rotations punkt");

            Console.WriteLine("\n");
            props.displayPoints = AskBool("Her angives om man ønsker at tegne modellens vertexer.", "Vis vertexer");

            Console.WriteLine("\n");
            props.displayFaces = AskBool("Her angives om man ønsker at tegne facaderne på modellen.", "Vis ansigter");

            Console.WriteLine("\n");
            props.displayLines = AskBool("Her angives om man ønsker at tegne 'linjer' mellem vertexerne, \nnogen typer modeller anvender dette istedet for ansigter.", "Vis linjer");


            Console.WriteLine("\n");
            props.rotateAmount = AskForFloatProperty("Her angives hvor meget man ønsker modellen skal roteres per billede tegnet.", "Rotations mængde", (float)(Math.PI/8d));

            Console.WriteLine("");
            props.wFLineSize = AskForFloatProperty("Her angives hvor store man ønsker linjer.", "Linje tykkelse", 1);

            Console.WriteLine("");
            props.wFPointSize = AskForFloatProperty("Her angives hvor store man ønsker punkter.", "Punkt størrelse", 2);
        }

        public static bool AskBool(string msg, string propName) {
            if (msg != "") {
                Console.WriteLine(msg);
                Console.WriteLine("Angiv 'f' for at sige nej, og 't' for at sige ja.");
            }

            while (true) {
                Console.Write(propName + ": ");
                var which = Console.ReadKey().KeyChar;
                if (which == 't') {
                    return true;
                } else if (which == 'f') {
                    return false;
                } else {
                    Console.Write("Ikke en af valgene, ");
                }
                Console.WriteLine("prøv noget andet");
            }
        }

        public static Model AskModel(ModelProps modelProps) {
            Console.Clear();
            Console.WriteLine("Dette er så en udvidelse af programmet, til at starte med kan du vælge om du vil \nprøve at projektere en kasse, et standard objekt eller et valgfrit objekt");
            Console.WriteLine("Skriv 'b' for at vælge kassen");
            Console.WriteLine("Skriv 'd' for at vælge det standard objekt");
            Console.WriteLine("Alle andre taster for at vælge et objekt selv");
            Console.Write("Skriv her: ");
            var whichA = Console.ReadKey();
            var which = whichA.KeyChar;

            if (which == 'b') {
                return GetBox(modelProps);
            } else if (which == 'd') {
                float scale = 0.002f;
                PointF3D translationToMid = new PointF3D(0, -500);
                PointF3D rotation = new PointF3D(0, 0, (float)Math.PI);
                var model = OBJExtractor.GetModel(Path.GetFullPath(@"Files to try out\deer.obj"), translationToMid, rotation, scale);
                modelProps.rotateAmount = Math.PI/16d;
                modelProps.wFLineSize = 1;
                modelProps.wFPointSize = 2;
                modelProps.displayPoints = false;
                modelProps.displayFaces = true;

                return model;
            } else {
                Console.Clear();
                Console.WriteLine("Du har valgt at vælge selv. ");
                string path = AskForPath();
                Console.WriteLine("");
                float scale = AskForFloatProperty("Her angives modellens størrelse", "Scale", 1f);
                Console.WriteLine("");
                PointF3D translationToMid = AskForPoint3DProperty("Her angives hvor meget modellen skal skubbes for at rotationsaksen ligger i midten", new PointF3D());
                Console.WriteLine("");
                PointF3D rotation = AskForPoint3DProperty("Her angives modellen starts rotation i radianer, hvor x, y, og z er aksen den rotere omkring", new PointF3D());

                Console.WriteLine("");
                modelProps.rotateAmount = AskForFloatProperty("Her angives hvor meget man ønsker modellen skal roteres per billede tegnet.", "Rotations mængde", (float)(Math.PI / 8d));

                Console.Clear();
                Console.WriteLine("Super, vi prøver altså at vise fra denne sti: \n" + path + "\n");
                Console.WriteLine("Med scale: \n" + scale + "\n");
                Console.WriteLine("Med translator til rotations midtpunkt: \n" + translationToMid + "\n");
                Console.WriteLine("Og med starts rotation: \n" + translationToMid + "\n");

                Console.Write("Tryk en vilkårlig tast for at fortsætte");
                Console.ReadKey();
                return OBJExtractor.GetModel(path, translationToMid, rotation, scale);
            }
        }

        public static string AskForPath() {
            var filePath = Path.GetFullPath(@"Files to try out\deer.obj");

            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.InitialDirectory = Path.GetFullPath(@"Files to try out\");
                openFileDialog.Filter = "OBJ Wavefront Filer (*.obj)|*.obj|Alle Filer (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    Console.WriteLine("Du har valgt filen: "+ filePath + "\n");
                }
            }

            return filePath;
        }

        public static float GetNum(String num) {
            try { return (float)Convert.ToDouble(num); } catch { return -2893.2483f; }
        }   

        public static float AskForFloatProperty(string msg, string propName, float defaultVal) {
            if (msg != "") {
                Console.WriteLine(msg);
                Console.WriteLine("Angiv et decimal tal, eller efterlad tom for standard værdi");
            }

            bool shouldWriteAgain = false;
            float maybeReturn = -2893.2483f;

            while (true) {
                if (shouldWriteAgain) {
                    Console.WriteLine("Prøv igen...");
                }
                Console.Write(propName + ": ");
                string c = Console.ReadLine().Replace('.',',');
                if (c == "") {
                    return defaultVal;
                } else {
                    maybeReturn = GetNum(c);

                    if (maybeReturn != -2893.2483f) {
                        return maybeReturn;
                    } 
                }
                shouldWriteAgain = true;
                Console.WriteLine("");
            }
        }

        public static PointF3D AskForPoint3DProperty(string msg, PointF3D defaultVal) {
            var returnPoint = new PointF3D();

            if (msg != "") {
                Console.WriteLine(msg);
                Console.WriteLine("Angiv et decimal tal, eller efterlad tom for standard værdi");
            }

            returnPoint.x = AskForFloatProperty("","x", defaultVal.x);
            returnPoint.y = AskForFloatProperty("", "y", defaultVal.y);
            returnPoint.z = AskForFloatProperty("", "z", defaultVal.z);

            return returnPoint;
        }


        public static Model GetBox(ModelProps modelProps) {
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
            var m = new Model(modelVertexes, modelLines, modelFaces); //Skab modellen med sine vertexer
            modelProps.rotateAmount = Math.PI / 256d;
            modelProps.wFLineSize = 5;
            modelProps.wFPointSize = 10;
            modelProps.displayPoints = true;
            return m;
        }
    }
}
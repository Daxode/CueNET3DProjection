using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SRP_3D_Projection_on_Keyboard.Basic_Projection;

namespace SRP_3D_Projection_on_Keyboard.Basic_Projection {
    public class OBJExtractor {
        public static Model GetModel(string path, PointF3D translationToMid, PointF3D rotation, float scale) {
            StreamReader fileReader = new StreamReader(path);
            List<PointF3D[]> vertexLines = new List<PointF3D[]>();
            List<PolyLine[]> lineLines = new List<PolyLine[]>();
            List<PolyLine[]> faceLines = new List<PolyLine[]>();

            if (fileReader != null) {
                while (!fileReader.EndOfStream) {
                    var line = fileReader.ReadLine();
                    if (line.StartsWith("v ")) {
                        vertexLines.Add(GetVertexes(fileReader, line, translationToMid, rotation, scale));
                    } else if (line.StartsWith("l ")) {
                        lineLines.Add(GetLines(fileReader, line));
                    } else if (line.StartsWith("f ")) { 
                        faceLines.Add(GetFaces(fileReader, line));
                    }
                }
            }

            PointF3D[] vertexes;
            PolyLine[] polyLines;
            PolyLine[] faces;

            if (vertexLines.Count == 0) {
                vertexes = new PointF3D[0];
            } else {
                vertexes = vertexLines[0];
            }

            if (faceLines.Count == 0) {
                faces = new PolyLine[0];
            } else {
                faces = faceLines[0];
            }

            if (lineLines.Count == 0) {
                polyLines = new PolyLine[0];
            } else {
                polyLines = lineLines[0];
            }

            return new Model(vertexes, polyLines, faces);
        }

        public static PointF3D[] GetVertexes(StreamReader fileReader, string current, PointF3D translationToMid, PointF3D rotation, float scale) {
            List<PointF3D> returnList = new List<PointF3D>();
            var line = current;
            do {
                var point = line.Replace('.',',').Split(' ');
                PointF3D vertex = null;
                try {
                    if (point[1] != "") {
                        vertex = new PointF3D((float)Convert.ToDouble(point[1]), (float)Convert.ToDouble(point[2]), (float)Convert.ToDouble(point[3])); 
                    } else {
                        vertex = new PointF3D((float)Convert.ToDouble(point[2]), (float)Convert.ToDouble(point[3]), (float)Convert.ToDouble(point[4]));
                    }
                } catch { continue; }

                //Translate it
                vertex += translationToMid;
                
                //Scale it
                vertex *= scale;

                //Rotate it
                vertex = Matrix.Rotate(rotation, vertex);

                returnList.Add(vertex);
                line = fileReader.ReadLine();
            } while (line.StartsWith("v "));

            return returnList.ToArray();
        }

        public static PolyLine[] GetFaces(StreamReader fileReader, string current) {
            return GetIndexes(fileReader, current, "f ");
        }

        public static PolyLine[] GetLines(StreamReader fileReader, string current) {
            return GetIndexes(fileReader, current, "l ");
        }

        public static PolyLine[] GetIndexes(StreamReader fileReader, string current, string which) {
            List<PolyLine> returnList = new List<PolyLine>();
            var line = current;
            do {
                if (line != "") {
                    //For hver eneste linje i filen hvor den stadig starter med "which"
                    //Separer linjen op til hver mellemrum (og sørg for korrekt decimal forståelse)
                    var point = line.Replace('.', ',').Split(' ');
                    var indexes = new List<int>();

                    /*Og for hver eneste index klat,
                    split den op til kun at få indexerne som skal tegnes sammen.
                    og tilføj det til vores index liste, med 1 mindre, 
                    da der her i programmet køres nul indexsering, hvorimod OBJ ikke gør. */
                    for (int i = 0; i < point.Length - 1; i++) {
                        var index = point[i + 1].Split('/')[0];
                        if (index != "") {
                            indexes.Add(Convert.ToInt32(index)-1); 
                        }
                    }

                    /*Tilsidst laver vi index listen til en PolyLine, 
                    og tilføjer den til vores liste af linjer/ansigter.*/
                    returnList.Add(new PolyLine(indexes.ToArray()));
                    line = fileReader.ReadLine();
                    if (line == null) {
                        break;
                    }
                }
            } while (line.StartsWith(which));

            return returnList.ToArray();
        }
    }
}
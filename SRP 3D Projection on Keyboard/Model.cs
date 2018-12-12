using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using CUE.NET.Devices.Keyboard;

namespace SRP_3D_Projection_on_Keyboard {
    class Model {
        private PointF3D[] vertexes;
        private PointF3D rotation;
        private PointF3D translater;

        private PointF[] calc2DPoints;

        //Constructor - Main
        public Model(PointF3D[] vertexes) {
            this.vertexes = vertexes;
            calc2DPoints = new PointF[vertexes.Length];
        }

        //Constructor - With rotation
        public Model(PointF3D[] vertexes, PointF3D rotation) {
            this.vertexes = vertexes;
            this.rotation = rotation;
        }

        public void Draw(CorsairKeyboard keyboard, Color colorPoints, Color colorLines) {
            //Draw points
            DrawPoints(keyboard, colorPoints);

            //Draw lines between them
            DrawLines(keyboard, colorLines);
        }

        private void DrawLines(CorsairKeyboard keyboard, Color color) {

        }

        private void DrawPoints(CorsairKeyboard keyboard, Color color) {
            foreach (var point in calc2DPoints) {
                SRP_3D_Projection_on_Keyboard.Draw.LEDDrawAt(keyboard, color, point);
            }
        }

        private void CalcNewPoints() {
            //For each vertex in model
            for (int i = 0; i < vertexes.Length; i++) {
                //Translate the vertex
                var Vertex = new PointF3D(vertexes[i].x + translater.x, vertexes[i].y + translater.y, vertexes[i].z + translater.z);

                //Rotate it
                Vertex = Matrix.Rotate(rotation, Vertex);

                //Project it
                var point = Matrix.Project(Vertex);

                //Add it to calc2DPoints
                calc2DPoints[i] = point;
            }
        }

        public void Rotation(PointF3D rotation) {
            //Edit rotation
            this.rotation = rotation;

            //Calculate new points
            CalcNewPoints();
        }

        public void RotateBy(PointF3D rotateBy)
        {
            //Edit rotater
            rotation.x += rotateBy.x;
            rotation.y += rotateBy.y;
            rotation.z += rotateBy.z;

            //Calculate new points
            CalcNewPoints();
        }

        public void Translation(PointF3D translation)
        {
            //Edit translater
            this.translater = translation;

            //Calculate new points
            CalcNewPoints();
        }
        public void TranslateBy(PointF3D translateBy) {
            //Edit translater
            translater.x += translateBy.x;
            translater.y += translateBy.y;
            translater.z += translateBy.z;

            //Calculate new points
            CalcNewPoints();
        }
    }
}
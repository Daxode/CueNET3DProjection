using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using CUE.NET.Devices.Keyboard;

namespace SRP_3D_Projection_on_Keyboard {
    class Model {
        private PointF3D[] vertexes;
        private PointF3D rotation;
        private PointF3D translator;
        private PointF translator2D;

        private PointF[] calc2DPoints;

        //Constructor - Main
        public Model(PointF3D[] vertexes) {
            this.vertexes = vertexes;
            Setup();
        }

        //Constructor - With rotation
        public Model(PointF3D[] vertexes, PointF3D rotation) {
            this.vertexes = vertexes;
            this.rotation = rotation;
            Setup();
        }

        private void Setup() {
            calc2DPoints = new PointF[vertexes.Length];
            rotation = new PointF3D();
            translator = new PointF3D();
            translator2D = new PointF();
            CalcNewPoints();
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
            SRP_3D_Projection_on_Keyboard.Draw.LEDDrawAt(keyboard, color, calc2DPoints, translator2D);
        }

        private void CalcNewPoints() {
            //For each vertex in model
            for (int i = 0; i < vertexes.Length; i++) {
                //Translate the vertex
                var Vertex = new PointF3D(vertexes[i].x + translator.x, vertexes[i].y + translator.y, vertexes[i].z + translator.z);

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

        public void RotateBy(PointF3D rotateBy) {
            //Edit rotater
            rotation.x += rotateBy.x;
            rotation.y += rotateBy.y;
            rotation.z += rotateBy.z;

            //Calculate new points
            CalcNewPoints();
        }

        public void Translation(PointF3D translation) {
            //Edit translater
            this.translator = translation;

            //Calculate new points
            CalcNewPoints();
        }

        public void TranslateBy(PointF3D translateBy) {
            //Edit translater
            translator.x += translateBy.x;
            translator.y += translateBy.y;
            translator.z += translateBy.z;

            //Calculate new points
            CalcNewPoints();
        }

        public void Translation(PointF translation) {
            //Edit translater
            this.translator2D = translation;

            //Calculate new points
            CalcNewPoints();
        }

        public void TranslateBy(PointF translateBy) {
            //Edit translater
            translator2D.X += translateBy.X;
            translator2D.Y += translateBy.Y;

            //Calculate new points
            CalcNewPoints();
        }

        public PointF3D GetRotation() {
            return rotation;
        }

        public PointF3D GetTranslater() {
            return translator;
        }

        public PointF GetTranslater2D() {
            return translator2D;
        }

        public PointF[] GetPoints() {
            return calc2DPoints;
        }
    }
}
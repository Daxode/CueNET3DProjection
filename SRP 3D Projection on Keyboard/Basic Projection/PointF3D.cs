using System.Drawing;

namespace SRP_3D_Projection_on_Keyboard.Basic_Projection {
    class PointF3D {
        public float x = 0;
        public float y = 0;
        public float z = 0;

        public PointF3D(float x = 0.0f, float y = 0.0f, float z = 0.0f) {
            this.x = x;
            this.y = y;
            this.z = z;
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
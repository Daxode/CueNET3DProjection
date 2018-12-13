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

        public static PointF3D operator+ (PointF3D p1, PointF3D p2) {
            var returnP = (PointF3D)p1.MemberwiseClone();
            returnP.x += p2.x;
            returnP.y += p2.y;
            returnP.z += p2.z;
            return returnP;
        }

        public static PointF3D operator* (PointF3D p1, PointF3D p2) {
            var returnP = (PointF3D)p1.MemberwiseClone();
            returnP.x *= p2.x;
            returnP.y *= p2.y;
            returnP.z *= p2.z;
            return returnP;
        }

        public static PointF3D operator* (PointF3D p1, float scaler) {
            var returnP = (PointF3D)p1.MemberwiseClone();
            returnP.x *= scaler;
            returnP.y *= scaler;
            returnP.z *= scaler;
            return returnP;
        }

        public static PointF3D operator+ (PointF3D p1, float adder) {
            var returnP = (PointF3D)p1.MemberwiseClone();
            returnP.x += adder;
            returnP.y += adder;
            returnP.z += adder;
            return returnP;
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
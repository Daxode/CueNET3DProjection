using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using CUE.NET.Devices.Keyboard;
using SRP_3D_Projection_on_Keyboard.Different_Platforms.WindowsForm;
using SRP_3D_Projection_on_Keyboard.Different_Platforms.Console;

namespace SRP_3D_Projection_on_Keyboard.Basic_Projection {
    public class ModelProps {
        public bool displayPoints = false;
        public bool displayFaces = true;
        public bool displayLines = true;
        public bool displayCenterOfRotation = true;
        public float wFLineSize = 1;
        public float wFPointSize = 2;
        public double rotateAmount = Math.PI / 8d;
    }
}
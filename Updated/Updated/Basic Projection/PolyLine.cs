using System.Drawing;
using System.Collections.Generic;

namespace SRP_3D_Projection_on_Keyboard.Basic_Projection {
    class PolyLine {
        public int[] indexesInModel;

        public PolyLine(params int[] values) {
            indexesInModel = values;
        }
    }
}
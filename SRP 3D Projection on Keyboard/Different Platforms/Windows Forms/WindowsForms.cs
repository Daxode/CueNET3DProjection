using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SRP_3D_Projection_on_Keyboard.Different_Platforms.Windows_Forms {
    public partial class WindowsForms : Form {
        public WindowsForms() {
            InitializeComponent();
        }

        private void WindowsForms_Painter(object sender, PaintEventArgs e) {
            var gr = e.Graphics;
        }
    }
}

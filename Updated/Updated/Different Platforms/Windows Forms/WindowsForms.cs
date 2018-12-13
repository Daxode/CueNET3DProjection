using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SRP_3D_Projection_on_Keyboard.Basic_Projection;

namespace SRP_3D_Projection_on_Keyboard.Different_Platforms.WindowsForm {
    public partial class WindowsForms : Form {
        public WindowsForms() {
            InitializeComponent();
        }

        private void WindowsForms_Painter(object sender, PaintEventArgs e) {
            var gr = e.Graphics;
        }

        //Clear form
        public void Clear()
        {

        }

        //Draw points(ps) with color(c) on keyboard(k)
        public void DrawAt(Color c, PointF[] ps)
        {
            foreach (var p in ps)
            {
                DrawAt(c, (int)p.X, (int)p.Y);
            }
        }

        //Draw points(ps) with color(c) and offset on keyboard(k)
        public void DrawAt(Color c, PointF[] ps, PointF offset)
        {
            foreach (var p in ps)
            {
                DrawAt(c, (int)(p.X + offset.X), (int)(p.Y + offset.Y));
            }
        }

        //Draw point(p) with color(c) on keyboard(k)
        public void DrawAt(Color c, PointF p)
        {
            DrawAt(c, (int)p.X, (int)p.Y);
        }

        //Draw line between pStart and pEnd with color(c) on keyboard(k)
        public void DrawLineAt(Color c, PointF pStart, PointF pEnd)
        {
            int res = 23;
            for (int x = 0; x < res; x++)
            {
                DrawAt(c, PointF3D.Lerp(pStart, pEnd, x / (float)res));
            }
        }

        //W:23 H:6 hvor 7 punkter ikke er der, og nogle punkter med samme lys, da de dækker over mere.
        public void DrawAt(Color c, int x, int y)
        {
        }
    }
}

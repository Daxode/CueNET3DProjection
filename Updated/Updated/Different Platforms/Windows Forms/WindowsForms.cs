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
        private Graphics gr;
        private const float lineWidth = 5;
        private const float pointRadius = 10;
        private Model model;

        public WindowsForms(Model model) {
            InitializeComponent();
            this.model = model;
        }

        private void WindowsForms_Painter(object sender, PaintEventArgs e) {
            gr = e.Graphics;
            Projection.ActualStuff(model, this);
        }

        //Clear form
        public void Clear() {
            try { gr.Clear(Color.Black); } catch { }
        }

        //Draw points(ps) with color(c)
        public void DrawAt(Color c, PointF[] ps) {
            foreach (var p in ps) {
                DrawAt(c, (int)p.X, (int)p.Y);
            }
        }

        //Draw point(p) with color(c) on keyboard(k)
        public void DrawAt(Color c, PointF p)
        {
            DrawAt(c, (int)p.X, (int)p.Y);
        }

        //Draw line between pStart and pEnd with color(c) on keyboard(k)
        public void DrawLineAt(Color c, PointF pStart, PointF pEnd) {
            try { gr.DrawLine(new Pen(c, lineWidth), pStart, pEnd); } catch { }
        }

        //W:23 H:6 hvor 7 punkter ikke er der, og nogle punkter med samme lys, da de dækker over mere.
        public void DrawAt(Color c, int x, int y) {
            try { gr.FillEllipse(new SolidBrush(c), x-(pointRadius/2f), y-(pointRadius/2f), pointRadius, pointRadius); } catch { }
        }
    }
}

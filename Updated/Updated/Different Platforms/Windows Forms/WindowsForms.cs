using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SRP_3D_Projection_on_Keyboard.Basic_Projection;

namespace SRP_3D_Projection_on_Keyboard.Different_Platforms.WindowsForm {
    public partial class WindowsForms : Form {
        public Graphics gr;
        private Model model;

        public WindowsForms(Model model) {
            InitializeComponent();
            model.Translation(new PointF(200, 200)); //Flyt den ind i midten af tastaturet
            model.Translation(new PointF3D()); //Flyt modellen
            model.Scaler(100f);
            this.model = model;
        }

        private void WindowsForms_Painter(object sender, PaintEventArgs e) {
            gr = e.Graphics;

            //Drawing
            while (gr != null) {
                Projection.ActualStuff(model, this);
            }
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
            try { gr.DrawLine(new Pen(c, model.properties.wFLineSize), pStart, pEnd); } catch { }
        }

        public void DrawAt(Color c, int x, int y) {
            DrawAt(c, x, y, model.properties.wFPointSize);
        }

        public void DrawAt(Color c, int x, int y, float radius) {
            //Prøv at tegne cirklen indenfor området.
            try { gr.FillEllipse(new SolidBrush(c), x-(radius / 2f), y-(radius / 2f), radius, radius); } catch { }
        }
    }
}

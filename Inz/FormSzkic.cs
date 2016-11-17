using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace Inz
{
    public partial class FormSzkic : Form
    {
        
        List<XYZ> listaWspolrzednych;
        public List<LiniePointPoint> LiniaPktPkt;


        public FormSzkic(List<XYZ> listaWsp, List<LiniePointPoint> listaLiniaPktPkt)
        {
            InitializeComponent();
            LiniaPktPkt = listaLiniaPktPkt;
            listaWspolrzednych = listaWsp;
        }

        private void RysujLinie(Pen MyPen, double xp, double yp, double xk, double yk, Graphics gfx)
        {
            var xpe = Convert.ToInt32(xp);
            var ype = Convert.ToInt32(yp);
            var xke = Convert.ToInt32(xk);
            var yke = Convert.ToInt32(yk);
            Point[] Pkty = {new Point(ype, xpe), new Point(yke, xke)};
            gfx.DrawLines(MyPen, Pkty);
        }

        private void Rysujpkt(double x, double y, string nazwa, Graphics gfx)
        {
            // g = panel1.CreateGraphics();
            Pen MyPen = new Pen(Color.Black);
            MyPen.Width = 4;
            var xe = Convert.ToInt32(x);
            var ye = Convert.ToInt32(y);
            Point pkt = new Point(ye + 3, xe + 3);
            gfx.DrawRectangle(MyPen, ye, xe, 4, 4);
            gfx.DrawString(nazwa, new Font("Segoe UI Light", 14), Brushes.Blue, pkt);
        }


        private void szkic(Graphics gfx)
        {
            //gfx.Clear(Color.White);
            double minx = listaWspolrzednych.Min(wartosc => wartosc.X);
            double miny = listaWspolrzednych.Min(wartosc => wartosc.Y);
            double maxx = listaWspolrzednych.Max(wartosc => wartosc.X);
            double maxy = listaWspolrzednych.Max(wartosc => wartosc.Y);
            double skala;
            var xekr = pBox.Height;
            var yekr = pBox.Width;
            var skalax = (xekr)/(Math.Abs(maxx - minx));
            var skalay = (yekr)/(Math.Abs(maxy - miny));
            string XY;
            if (skalay > skalax)
            {
                skala = skalax;
                XY = "X";
            }
            else
            {
                skala = skalay;
                XY = "Y";

            }
            skala*=0.9;
            Skalax.Text = String.Format("Skala X {0} | Skala Y {1} | {2}", skalax, skalay, XY);
            Pen myPen = new Pen(Color.Black);
            myPen.Width = 1;
            dataGridView1.Rows.Clear();
            foreach (var item in listaWspolrzednych)
            {
                var xpekr = xekr - (skala*(item.X - minx)+30 );
                var ypekr = skala*(item.Y - miny)+15;
                Rysujpkt(xpekr, ypekr, item.Nazwa, gfx);
                dataGridView1.Rows.Add(item.Nazwa, xpekr, ypekr);
            }
            if (LiniaPktPkt.Count > 0)
            {
                foreach (var linia in LiniaPktPkt)
                {
                    try
                    {
                        XYZ poczatek =
                            listaWspolrzednych.Where(wartosc => wartosc.Nazwa.Equals(linia.Poczatek)).FirstOrDefault();
                        XYZ koniec =
                            listaWspolrzednych.Where(wartosc => wartosc.Nazwa.Equals(linia.Koniec)).FirstOrDefault();

                        var xpekr = xekr - (skala*(poczatek.X - minx)+30);
                        var ypekr = skala*(poczatek.Y - miny)+15;
                        var xkekr = xekr - (skala*(koniec.X - minx)+30 );
                        var ykekr = skala*(koniec.Y - miny)+15;
                        RysujLinie(myPen, xpekr, ypekr, xkekr, ykekr, gfx);
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
           //

        }

        private void FormSzkic_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            DoubleBuffer(dataGridView1, true);

        }

        private void FormSzkic_Paint(object sender, PaintEventArgs e)
        {

        }
        private void FormSzkic_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }


        private void pBox_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            szkic(g);
        }

        private void pBox_Move(object sender, EventArgs e)
        {

        }

        private void pBox_MouseMove(object sender, MouseEventArgs e)
        {
            int X = Cursor.Position.X-pBox.Location.X;
            int Y = Cursor.Position.Y-pBox.Location.Y;
            MousePosition.Text = string.Format("Kursor: X {1} | Y {0}", X, Y);
        }
        public static void DoubleBuffer(DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}

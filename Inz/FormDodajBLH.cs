using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inz
{
    public partial class FormDodajBLH : Form
    {
        public FormDodajBLH()
        {
            InitializeComponent();
        }

        private void KonwertujNaBlh(double fi, double lambda, double h, out double Xk, out double Yk, out double Zk)
        {
            fi = fi/180*Math.PI;
            lambda = lambda/180*Math.PI;
            var a = Properties.Settings.Default.elipsoida_a;
            var b = Properties.Settings.Default.elipsoida_b;
            var e2 = (Math.Pow(a, 2) - Math.Pow(b, 2))/Math.Pow(a, 2);
            var n = a/Math.Sqrt(1 - e2*Math.Pow(Math.Sin(fi), 2));
            Xk = (n + h)*Math.Cos(fi)*Math.Cos(lambda);
            Yk = (n + h)*Math.Cos(fi)*Math.Sin(lambda);
            Zk = (n*(1 - e2) + h)*Math.Sin(fi);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                double b, l, h;
                var x = row.Cells["B"].Value;
                if (row.Cells["B"].Value != null && row.Cells["L"].Value != null && row.Cells["H"].Value != null)
                {
                    bool ifB = double.TryParse(row.Cells["B"].Value.ToString(), out b);
                    bool ifL = double.TryParse(row.Cells["L"].Value.ToString(), out l);
                    bool ifH = double.TryParse(row.Cells["H"].Value.ToString(), out h);

                    if (ifB && ifH && ifL)
                    {
                        double X, Y, Z;
                        KonwertujNaBlh(b, l, h, out X, out Y, out Z);
                        row.Cells["X"].Value = X;
                        row.Cells["Y"].Value = Y;
                        row.Cells["Z"].Value = Z;
                    }
                }
            }
        }

        private void FormDodajBLH_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int id;
                if (wspolrzedneBindingSource.Count > 0)
                {
                    id = database1DataSet.Wspolrzedne.Max(wartosc => wartosc.Id) + 1;
                }
                else
                {
                    id = 0;
                }
                double x, y, z;
                if (row.Cells["X"].Value != null && row.Cells["Y"].Value != null && row.Cells["Z"].Value != null)
                {
                    bool ifX = double.TryParse(row.Cells["X"].Value.ToString(), out x);
                    bool ifY = double.TryParse(row.Cells["Y"].Value.ToString(), out y);
                    bool ifZ = double.TryParse(row.Cells["Z"].Value.ToString(), out z);

                    if (ifX && ifY && ifZ)
                    {
                        string nazwa = row.Cells["Nazwa"].Value.ToString();
                        bool staly = Convert.ToBoolean(row.Cells["Staly"].Value);
                        wspolrzedneTableAdapter1.Insert(id,nazwa, x, y, z, staly);
                    }

                }
            }
        }

        private void FormDodajBLH_Load(object sender, EventArgs e)
        {
            this.wspolrzedneTableAdapter1.Fill(this.database1DataSet.Wspolrzedne);
        }
    }
}

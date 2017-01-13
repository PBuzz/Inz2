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
        double X, Y, Z;

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
        

        private void FormDodajBLH_Load(object sender, EventArgs e)
        {
            this.wspolrzedneTableAdapter1.Fill(this.database1DataSet.Wspolrzedne);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var fi = Convert.ToDouble(textBox1.Text);
            var lambda = Convert.ToDouble(textBox2.Text);
            var h = Convert.ToDouble(textBox3.Text);
            KonwertujNaBlh(fi,lambda,h,out X,out Y,out Z);
            textBox11.Text = X.ToString();
            textBox12.Text = Y.ToString();
            textBox13.Text = Z.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            var fi = Convert.ToDouble(textBox4.Text)+ Convert.ToDouble(textBox5.Text)/60+ Convert.ToDouble(textBox6.Text)/3600;
            var lambda = Convert.ToDouble(textBox9.Text)+ Convert.ToDouble(textBox8.Text)/60+ Convert.ToDouble(textBox7.Text)/3600;
            var h = Convert.ToDouble(textBox10.Text);
            KonwertujNaBlh(fi, lambda, h, out X, out Y, out Z);
            textBox11.Text = X.ToString();
            textBox12.Text = Y.ToString();
            textBox13.Text = Z.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            wspolrzedneTableAdapter1.Insert(null, X, Y, Z, false);
        }
    }
}

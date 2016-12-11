using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inz
{
    public partial class FormUstawienia : Form
    {
        public FormUstawienia()
        {
            InitializeComponent();
            var ust = Properties.Settings.Default;
            numericUpDown1.Value = Convert.ToDecimal(ust.bladkierunkucc);
            tBgeoida.Text = ust.sciezkageoidy;
            tBa.Text = ust.elipsoida_a.ToString("N5");
            tBb.Text = ust.elipsoida_b.ToString("N5");
            tBf.Text = ust.elipsoida_f.ToString("N5");
            tBConfig.Text = ust.config.ToString();
            tBrtklib.Text = ust.rtklibPath.ToString();
            tBoutput.Text = ust.outputPath.ToString();
            propertyGrid1.SelectedObject = Properties.Settings.Default;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonsave_Click(object sender, EventArgs e)
        {
            
           Properties.Settings.Default.bladkierunkucc= Convert.ToDouble(numericUpDown1.Value);
            if (tBgeoida.Text != null)
            {
                Properties.Settings.Default.sciezkageoidy = tBgeoida.Text;
            }
            Properties.Settings.Default.elipsoida_a = Convert.ToDouble(tBa.Text);
                Properties.Settings.Default.elipsoida_b= Convert.ToDouble(tBb.Text);
            Properties.Settings.Default.elipsoida_f= Convert.ToDouble(tBf.Text);
            Properties.Settings.Default.rtklibPath = tBrtklib.Text;
            Properties.Settings.Default.config = tBConfig.Text;
            Properties.Settings.Default.outputPath = tBoutput.Text;
        }

        private void textBox4_DoubleClick(object sender, EventArgs e)
        {
            //Wczytaj model geoidy
            //Dodaj sciezke
            openFileDialog1.FileName = "Model geoidy w formacie B L KSI";
            openFileDialog1.Title = "Wczytywanie geoidy";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tBgeoida.Text = openFileDialog1.FileName;

            }
        }

        private void Tab1_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = Properties.Settings.Default;
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tBrtklib.Text = openFileDialog1.FileName;

            }
        }

        private void textBox1_DoubleClick_1(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tBConfig.Text = openFileDialog1.FileName;

            }
        }

        private void tBoutput_DoubleClick(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tBoutput.Text = folderBrowserDialog1.SelectedPath;

            }
        }
    }
}

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
    public partial class FormUstawienia : Form
    {
        public FormUstawienia()
        {
            InitializeComponent();
            numericUpDown1.Value = Convert.ToDecimal(Properties.Settings.Default.bladkierunkucc);
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
        }
    }
}

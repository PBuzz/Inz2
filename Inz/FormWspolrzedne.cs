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
    public partial class FormWspolrzedne : Form
    {
        public FormWspolrzedne()
        {
            InitializeComponent();
            DoubleBuffer(wspolrzedneDataGridView,true);
        }


        private void wspolrzedneBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.wspolrzedneBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void FormWspolrzedne_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'database1DataSet.Wspolrzedne' . Możesz go przenieść lub usunąć.
            this.wspolrzedneTableAdapter.Fill(this.database1DataSet.Wspolrzedne);

        }
        public static void DoubleBuffer(DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }

        private void wspolrzedneDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Tylko cyfry");
        }
    }
}

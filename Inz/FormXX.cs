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
    public partial class FormXX : Form
    {
        public FormXX()
        {
            InitializeComponent();
        }

        private void wektory2BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.wektory2BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void FormXX_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'database1DataSet.Wektory2' . Możesz go przenieść lub usunąć.
            this.wektory2TableAdapter.Fill(this.database1DataSet.Wektory2);

        }
    }
}

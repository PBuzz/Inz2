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
    public partial class FormDlugosci : Form
    {
        public FormDlugosci()
        {
            InitializeComponent();
        }

        private void dlugosciBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dlugosciBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void FormDlugosci_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'database1DataSet.Dlugosci' . Możesz go przenieść lub usunąć.
            this.dlugosciTableAdapter.Fill(this.database1DataSet.Dlugosci);

        }
    }
}

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
    public partial class FormKaty : Form
    {
        public FormKaty()
        {
            InitializeComponent();
        }



        private void FormKaty_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'database1DataSet.Katy' . Możesz go przenieść lub usunąć.
            this.katyTableAdapter.Fill(this.database1DataSet.Katy);

        }

        private void katyBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.katyBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inz
{
    public partial class FormTachimetr : Form
    {
        SqlConnection con;
        SqlDataAdapter adap;
        DataSet ds;
        SqlCommandBuilder cmdb;
        public int x = 8;
        public FormTachimetr()
        {
            InitializeComponent();
            DoubleBuffer(tachimetrDataGridView, true);
            int idcount = tachimetrBindingSource.Count;

        }

        public static void DoubleBuffer(DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }

        private void tachimetrBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tachimetrBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);
        }

        private void FormTachimetr_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'database1DataSet.Tachimetr' . Możesz go przenieść lub usunąć.
            this.tachimetrTableAdapter.Fill(this.database1DataSet.Tachimetr);
        }

        public void UnikatowePunkty()
        {

            var table = new DataTable();
            using (
                var da = new SqlDataAdapter("SELECT * FROM Tachimetr",
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projekty C\Inz\Inz\Database1.mdf;Integrated Security=True")
                )
            {
                da.Fill(table);
            }

            /*// var unikatPkt = (from t in database1DataSet.Tachimetr
            //     select t.Stanowisko ).Distinct();
            var unikatPkt1 =
                database1DataSet.Tachimetr.Select (i=>new{i.Stanowisko}
                    ).Distinct().ToList();
            var unikatPkt2 =
               database1DataSet.Tachimetr.Select(i => new { i.Cel }
                   ).Distinct().ToList();
            List<string> unikatPkt = new List<string>(); 
            foreach (var wiersz in unikatPkt1)
            { unikatPkt.Add(wiersz.ToString());}
            foreach (var wiersz in unikatPkt2)
            { unikatPkt.Add(wiersz.ToString()); }
            var unikatPkt4 =unikatPkt.Distinct().ToList();
            MessageBox.Show(unikatPkt.ToString());

          /*  List<String> columnData = new List<String>();

            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projekty C\Inz\Inz\Database1.mdf;Integrated Security=True"))
            {
                string query = "SELECT Cel FROM Tachimetr";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columnData.Add(reader.GetString(0));
                        }
                    }
                }
            }*/
            //MessageBox.Show(unikatPkt.ToString());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string message = tachimetrBindingSource.Count.ToString();
            MessageBox.Show(message);
        }

        private void tachimetrBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.tachimetrBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {

            con = new SqlConnection();
            try
            {
                con.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
                con.Open();
                adap =
                    new SqlDataAdapter(
                        "select Id, Stanowisko,Cel,Odczyt_poziomy,Odczyt_pionowy,Odleglosc as 'Odległość',H_stanowiska,H_celu from Tachimetr",
                        con);
                ds = new DataSet();
                adap.Fill(ds, "Tachimetr");
                dataGridView1.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd " + ex, "Błąd", MessageBoxButtons.OK);
                throw;
            }


        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            cmdb = new SqlCommandBuilder(adap);
            adap.Update(ds, "Tachimetr");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.tachimetrTableAdapter.Fill(this.database1DataSet.Tachimetr);
        }


        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn c in tachimetrDataGridView.Columns)
            {
                x--; 
                c.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", x);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn c in tachimetrDataGridView.Columns)
            {
                x++;
                c.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", x);
            }
        }

        private void tachimetrDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Tylko cyfry");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MathNet.Numerics.LinearAlgebra;

namespace Inz
{
    public partial class FormWyrownanie : Form
    {
        public FormWyrownanie()
        {
            InitializeComponent();
        }

        private void wektory2BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.wektory2BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void FormWyrownanie_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'database1DataSet.Wyrownanie' . Możesz go przenieść lub usunąć.
            this.wyrownanieTableAdapter.Fill(this.database1DataSet.Wyrownanie);
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'database1DataSet.Wektory2' . Możesz go przenieść lub usunąć.
            this.wektory2TableAdapter.Fill(this.database1DataSet.Wektory2);
            wyrownanieTableAdapter.Fill(this.database1DataSet.Wyrownanie);
        }

        private void wyrownanie()
        {
            this.wspolrzedneTableAdapter1.Fill(database1DataSet.Wspolrzedne);
            double bkier = Properties.Settings.Default.bladkierunkucc;
            double ro = 2000000 / Math.PI;
            var dt = new DataTable();

            var dt2 = new DataTable();
            DataColumn newColumnNazwadt2 = new DataColumn("Nazwa", typeof(double));
            DataColumn newColumnXdt2 = new DataColumn("X", typeof(double));
            DataColumn newColumnYdt2 = new DataColumn("Y", typeof(double));
            DataColumn newColumnHdt2 = new DataColumn("Z", typeof(double));
            newColumnXdt2.DefaultValue = 0;
            newColumnHdt2.DefaultValue = 0;
            newColumnYdt2.DefaultValue = 0;
            dt2.Columns.Add(newColumnNazwadt2);
            dt2.Columns.Add(newColumnXdt2);
            dt2.Columns.Add(newColumnYdt2);
            dt2.Columns.Add(newColumnHdt2);

            var listapkt = new List<string>();
            var lList = new List<double>();
            var pList = new List<double>();
            var obliczenia = new Wspprzyb();
            foreach (DataRow row in database1DataSet.Wektory2.Rows)
            {
                var baza = row["Poczatek"].ToString();
                var rover = row["Koniec"].ToString();
                bool bazaistnieje =
                        database1DataSet.Wspolrzedne.Any(punkt => punkt.Nazwa.Equals(baza)&&punkt.Staly.Equals(true));
                bool roveristnieje = database1DataSet.Wspolrzedne.Any(punkt => punkt.Nazwa.Equals(rover) && punkt.Staly.Equals(true));
                if (bazaistnieje == false && roveristnieje == false)
                {
                    listapkt.Add(baza);
                    listapkt.Add(rover);
                }
            }
            var hashListaPkt = new HashSet<string>(listapkt);

            foreach (var row in hashListaPkt)
            {
             
                    //tworzy tabele macierz A, pustą
                     string nazwa = row;
                    string nazwaX = "__X__" + nazwa;
                    string nazwaY = "__Y__" + nazwa;
                    string nazwaK = "__Z__" + nazwa;
                    DataColumn newColumnX = new DataColumn(nazwaX, typeof(double));
                    DataColumn newColumnY = new DataColumn(nazwaY, typeof(double));
                    DataColumn newColumnZ = new DataColumn(nazwaK, typeof(double));
                    newColumnX.DefaultValue = 0;
                    newColumnZ.DefaultValue = 0;
                    newColumnY.DefaultValue = 0;
                    dt.Columns.Add(newColumnX);
                    dt.Columns.Add(newColumnY);
                    dt.Columns.Add(newColumnZ);
                
            }

            foreach (DataRow row in database1DataSet.Wektory2.Rows)
            {
                
                var baza = row["Poczatek"].ToString();
                var rover = row["Koniec"].ToString();
                var row1 = dt.NewRow();
                var row2 = dt.NewRow();
                var row3 = dt.NewRow();
                bool bazaistnieje =
                         database1DataSet.Wspolrzedne.Any(punkt => punkt.Nazwa.Equals(baza) && punkt.Staly.Equals(true));
                if (bazaistnieje)
                {
                    var bazaRow = database1DataSet.Wspolrzedne.Where(
                        rowcel => rowcel.Nazwa.Equals(baza) && rowcel.Staly.Equals(true)).FirstOrDefault();
                    row1["__X__" + rover] = 1;
                    row2["__Y__" + rover] = 1;
                    row3["__Z__" + rover] = 1;
                    var DX = Convert.ToDouble(row["DX"]);
                    var DY = Convert.ToDouble(row["DY"]);
                    var DZ = Convert.ToDouble(row["DZ"]);

                    var mx = Convert.ToDouble(row["mx"]);
                    var my = Convert.ToDouble(row["my"]);
                    var mz = Convert.ToDouble(row["mz"]);

                    lList.Add(bazaRow.X+DX);
                    lList.Add(bazaRow.Y + DY);
                    lList.Add(bazaRow.Z + DZ);
                    pList.Add(mx);
                    pList.Add(my);
                    pList.Add(mz);
                }
                else
                {
                    var DX = Convert.ToDouble(row["DX"]);
                    var DY = Convert.ToDouble(row["DY"]);
                    var DZ = Convert.ToDouble(row["DZ"]);

                    var mx = Convert.ToDouble(row["mx"]);
                    var my = Convert.ToDouble(row["my"]);
                    var mz = Convert.ToDouble(row["mz"]);

                    row1["__X__" + rover] = 1;
                    row2["__Y__" + rover] = 1;
                    row3["__Z__" + rover] = 1;
                    row1["__X__" + baza] = -1;
                    row2["__Y__" + baza] = -1;
                    row3["__Z__" + baza] = -1;
                    lList.Add( DX);
                    lList.Add(DY);
                    lList.Add(DZ);
                    pList.Add(mx);
                    pList.Add(my);
                    pList.Add(mz);
                }
                dt.Rows.Add(row1);
                dt.Rows.Add(row2);
                dt.Rows.Add(row3);
            }


            int liczbakolumn = dt.Columns.Count;
            int liczbawierszy = dt.Rows.Count;
            Matrix<double> A = Matrix<double>.Build.Dense(liczbawierszy, liczbakolumn);
            for (int i = 0; i < liczbawierszy; i++)
            {
                for (int j = 0; j < liczbakolumn; j++)
                {
                    if (dt.Rows[i][j] == DBNull.Value)
                    {
                        A[i, j] = 0;
                    }
                    else
                    {

                        A[i, j] = Convert.ToDouble(dt.Rows[i][j]);

                    }


                }
            }
            Matrix<double> L = Matrix<double>.Build.Dense(lList.Count, 1);
            for (int i = 0; i < lList.Count; i++)
            {
                L[i, 0] = lList[i];
            }
            Matrix<double> P = Matrix<double>.Build.Dense(pList.Count, pList.Count);
            for (int i = 0; i < pList.Count; i++)
            {
                P[i, i] = pList[i];
            }
            P = P.Inverse();
            var x1 = (A.Transpose()*P*A);
            x1 = x1.Inverse();
            var x2 = A.Transpose()*P*L;
            var x = x1*x2;
            int licznik = 0;
            foreach (var row in hashListaPkt)
            {
                wyrownanieTableAdapter1.Insert(row, x[licznik, 0], x[licznik + 1, 0], x[licznik + 2, 0], x1[licznik, licznik], x1[licznik + 1, licznik + 1],
                    x1[licznik + 2, licznik + 2]);
                licznik += 3;

            }
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            wyrownanieTableAdapter.Fill(this.database1DataSet.Wyrownanie);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wyrownanie();
            
        }
    }
}

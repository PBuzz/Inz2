using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Inz.Database1DataSetTableAdapters;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Inz
{
    public partial class FormTest : Form
    {

        public FormTest()
        {
            InitializeComponent();
            DoubleBuffer(punktyNieznaneDataGridView, true);

        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'database1DataSet.PunktyNieznane' . Możesz go przenieść lub usunąć.
            this.punktyNieznaneTableAdapter.Fill(this.database1DataSet.PunktyNieznane);
            toolStripButton1_Click(sender, e);

        }

        public static void DoubleBuffer(DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (var con2 = new SqlConnection(Properties.Settings.Default.Database1ConnectionString))
                // using (var cmd = new SqlCommand())
            {
                //  cmd.CommandText = "DELETE FROM PunktyNieznane";
                // cmd.Connection = con2;
                // con2.Open();
                // int numberDeleted = cmd.ExecuteNonQuery();  // all rows deleted
            }
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlConnection con;
            con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.Database1ConnectionString;
            con.Open();
            da.SelectCommand = new SqlCommand(@"SELECT * FROM Wspolrzedne Where Staly = 1", con);
            da.Fill(ds, "Stale");
            dt = ds.Tables["Stale"];
            this.punktyNieznaneTableAdapter.Fill(this.database1DataSet.PunktyNieznane);
            int id;
            if (punktyNieznaneBindingSource.Count > 0)
            { id = database1DataSet.PunktyNieznane.Max(wartosc => wartosc.Id) + 1;}
            else
            {
                id = 0;
            }
        //punktyNieznaneDataGridView.DataSource = dt;

        foreach (

        DataRow row in dt.Rows)
            {
                bool nazwapkt = database1DataSet.PunktyNieznane.Any(punkt => punkt.Nazwa.Equals(row[1]));
                if (nazwapkt == false)
                {
                    punktyNieznaneTableAdapter.Insert(id, row[1].ToString(), true, true, Convert.ToDouble(row[2]),
                        Convert.ToDouble(row[3]), Convert.ToDouble(row[4]));
                }
                id++;
            }
            this.punktyNieznaneTableAdapter.Fill(this.database1DataSet.PunktyNieznane);
        }



        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void punktyNieznaneBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.punktyNieznaneBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.database1DataSet);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                
            }
            

        }

        void odczyt()
        {
            this.tachimetrTableAdapter1.Fill(this.database1DataSet.Tachimetr);
            this.punktyNieznaneTableAdapter.Fill(this.database1DataSet.PunktyNieznane);
            this.wspolrzedneTableAdapter1.Fill(this.database1DataSet.Wspolrzedne);
            var rtBotworz = new FormOtworzRTB();
            rtBotworz.MdiParent = this.MdiParent ;
            rtBotworz.Show();
             var oblazymut = new Wspprzyb();
            double azymut = 0;
            double odczyt_nawiazania = 0;
            bool nawiazanie = false;
            string stanowsikopoprzednie="";
            bool czyjuz=false;
            bool braknawiazania = true;
            while (czyjuz!=true)
            {
                czyjuz = true;
                foreach (DataRow row in database1DataSet.Tachimetr.Rows)
                {
                    var stanowisko = row.ItemArray[1].ToString();
                    if (stanowisko != stanowsikopoprzednie)
                    {
                        nawiazanie = false;
                    }
                    var cel = row.ItemArray[2].ToString();
                    string wynikc, wyniks;
                    bool celistnieje =
                        database1DataSet.PunktyNieznane.Any(punkt => punkt.Nazwa.Equals(cel) && punkt.Znany == true);
                    if (celistnieje)
                    {
                        wynikc = "Znany ";
                    }
                    else
                    {
                        wynikc = "Nieznany";
                        czyjuz = false;
                    }
                    bool stanowiskoistnieje =
                        database1DataSet.PunktyNieznane.Any(
                            punkt => punkt.Nazwa.Equals(stanowisko) && punkt.Znany == true);
                    if (stanowiskoistnieje)
                    {
                        wyniks = "Znany ";
                    }
                    else
                    {
                        wyniks = "Nieznany";
                        czyjuz = false;
                    }
                    string dowyswietlenia = string.Format("stanowisko: {0}  {3}  cel: {1} {2}\n", stanowisko, cel,
                        wynikc, wyniks);
                    if (celistnieje && stanowiskoistnieje)
                    {
                        bool stanowisko3 = database1DataSet.PunktyNieznane.Any(punkt => punkt.Nazwa.Equals(stanowisko));
                        DataRow celRow =
                            database1DataSet.PunktyNieznane.Where(rowcel => rowcel.Nazwa.Equals(cel)).FirstOrDefault();
                        DataRow stRow =
                            database1DataSet.PunktyNieznane.AsEnumerable()
                                .Where(rowst => rowst.Nazwa == stanowisko)
                                .FirstOrDefault();
                        double sx = Convert.ToDouble(stRow[4]);
                        double sy = Convert.ToDouble(stRow[5]);
                        double cx = Convert.ToDouble(celRow[4]);
                        double cy = Convert.ToDouble(celRow[5]);
                        azymut = oblazymut.Azymut(sx, sy, cx, cy, 2);
                        dowyswietlenia = dowyswietlenia + "azymut: " + azymut + "\n";
                        nawiazanie = true;
                        odczyt_nawiazania = Convert.ToDouble(row.ItemArray[3]);
                        braknawiazania = false;
                    }
                    if (celistnieje == false && stanowiskoistnieje && nawiazanie)
                    {
                        DataRow stRow =
                            database1DataSet.PunktyNieznane.AsEnumerable()
                                .Where(rowst => rowst.Nazwa == stanowisko)
                                .FirstOrDefault();
                        double sx = Convert.ToDouble(stRow[4]);
                        double sy = Convert.ToDouble(stRow[5]);
                        double sz = Convert.ToDouble(stRow[6]);
                        var odl = Convert.ToDouble(row[5]);
                        var hi = Convert.ToDouble(row[6]);
                        var hc = Convert.ToDouble(row[7]);
                        //var odl = oblazymut.redukcjaOdleglosci(Convert.ToDouble(row[4]), Convert.ToDouble(row[5]));
                        
                        var wsp = oblazymut.Oblbiegunowe(sx, sy,sz, odl, Convert.ToDouble(row.ItemArray[3]), azymut,
                            odczyt_nawiazania, Convert.ToDouble(row[4]),hi,hc);


                        //var wsp2 = oblazymut.Oblbiegunowe()
                        this.punktyNieznaneTableAdapter.Fill(this.database1DataSet.PunktyNieznane);
                        int id =  database1DataSet.PunktyNieznane.Max(wartosc => wartosc.Id) + 1;
                        punktyNieznaneTableAdapter.Insert(id, cel, true, false, wsp.X, wsp.Y, wsp.H);
                        int id2 = WspolrzedneBindingSource.Count + 1;
                      // wspolrzedneTableAdapter1.Insert(id, cel, wsp.X, wsp.Y, wsp.H, false);
                        this.punktyNieznaneTableAdapter.Fill(this.database1DataSet.PunktyNieznane);
                        this.wspolrzedneTableAdapter1.Fill(this.database1DataSet.Wspolrzedne);

                    }
                    stanowsikopoprzednie = stanowisko;

                    rtBotworz.richTextBox1.AppendText(dowyswietlenia);
                }
                if (braknawiazania)
                {
                    rtBotworz.richTextBox1.AppendText("Brak nawiązania!!");
                    break;
                }
            }
        }

        void wyrównanie()
        {
            double bkier = Properties.Settings.Default.bladkierunkucc;
            double ro = 2000000/Math.PI;
            var dt = new DataTable();
            
             var dt2 = new DataTable();
            DataColumn newColumnNazwadt2 = new DataColumn("Nazwa", typeof(double));
            DataColumn newColumnXdt2 = new DataColumn("X", typeof(double));
            DataColumn newColumnYdt2 = new DataColumn("Y", typeof(double));
            DataColumn newColumnHdt2 = new DataColumn("H", typeof(double));
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
            foreach (DataRow row in database1DataSet.PunktyNieznane.Rows)
            {
                if (Convert.ToBoolean(row.ItemArray[2]) == true && Convert.ToBoolean(row.ItemArray[3]) == false)
                {//tworzy tabele macierz A, pustą
                    string nazwa = row.ItemArray[1].ToString();
                    string nazwaX = "__X__" + nazwa;
                    string nazwaY = "__Y__" + nazwa;
                    string nazwaK = "__K__" + nazwa;
                    DataColumn newColumnX = new DataColumn(nazwaX,typeof(double));
                    DataColumn newColumnY = new DataColumn(nazwaY, typeof(double));
                    DataColumn newColumnK = new DataColumn(nazwaK, typeof(double));
                    newColumnX.DefaultValue = 0;
                    newColumnK.DefaultValue = 0;
                    newColumnY.DefaultValue = 0;
                    dt.Columns.Add(newColumnX);
                    dt.Columns.Add(newColumnY);
                    dt.Columns.Add(newColumnK);
                    listapkt.Add(row["Nazwa"].ToString());
                }
            }
            dataGridView1.DataSource = dt;

            foreach (DataRow rowtachimetr in database1DataSet.Tachimetr.Rows)
            {
                //Wypełnianie macierzy równaniami poprawek
                string cel = rowtachimetr.ItemArray[2].ToString();
                string stanowisko = rowtachimetr.ItemArray[1].ToString();
                double dlugosc = Convert.ToDouble(rowtachimetr.ItemArray[5]);
                DataRow celRow =database1DataSet.PunktyNieznane.Where(rowcel => rowcel.Nazwa.Equals(cel)).FirstOrDefault();
                DataRow stRow =database1DataSet.PunktyNieznane.AsEnumerable().Where(rowst => rowst.Nazwa == stanowisko).FirstOrDefault();
                double sx = Convert.ToDouble(stRow[4]); //wspolrzedne, s- stanowsiko, c- cel
                double sy = Convert.ToDouble(stRow[5]);
                double cx = Convert.ToDouble(celRow[4]);
                double cy = Convert.ToDouble(celRow[5]);
                double dx = cx - sx;//przyrosty
                double dy = cy - sy;
                double d = Math.Sqrt(dx*dx + dy*dy);//długość ze wsp
                double rownKierStX = -dy/Math.Pow(d, 2);//równania do macierzy A, St-stanowisko, C-cel,Dl-Długość
                double rownKierStY = dx / Math.Pow(d, 2);
                double rownKierCx = dy / Math.Pow(d, 2);
                double rownKierCy = -dx / Math.Pow(d, 2);
                double rownDlStx = -dx/d;
                double rownDlSty = -dy/d;
                double rownDlCx = dx/d;
                double rownDlCy = -dy / d;
                double azymut = obliczenia.Azymut(sx, sy, cx, cy, 2);


                var row = dt.NewRow();
                var row2 = dt.NewRow();
                bool celistnieje =database1DataSet.PunktyNieznane.Any(punkt => punkt.Nazwa.Equals(cel) && punkt.Staly == false);
                if (celistnieje)
                {
                    row["__X__" + cel] = rownKierCx*ro;
                    row["__Y__" + cel] = rownKierCy*ro;
                    row2["__X__" + cel] = rownDlCx;
                    row2["__Y__" + cel] = rownDlCy;
                    }

                bool stanowiskoistnieje =
                    database1DataSet.PunktyNieznane.Any(
                        punkt => punkt.Nazwa.Equals(stanowisko) && punkt.Staly == false);
                if (stanowiskoistnieje)
                {

                    row["__X__" + stanowisko] = rownKierStX*ro;
                    row["__Y__" + stanowisko] = rownKierStY*ro;
                    row["__K__" + stanowisko] = -1;
                    row2["__X__" + stanowisko] = rownDlStx;
                    row2["__Y__" + stanowisko] = rownDlSty;
                }
                //if (stanowiskoistnieje || celistnieje)
               // {
                    dt.Rows.Add(row);
                    dt.Rows.Add(row2);
              //  }
                //lista macierz l
                lList.Add(azymut-Convert.ToDouble(rowtachimetr.ItemArray[3]));
                lList.Add(d - dlugosc);

                //lista macierz p
                pList.Add(1/Math.Pow(bkier,2));
                pList.Add(1/Math.Pow(dlugosc,2));
            }
            int liczbakolumn = dt.Columns.Count;
            int liczbawierszy = dt.Rows.Count;
            Matrix<double> A = Matrix<double>.Build.Dense(liczbawierszy, liczbakolumn);
            for (int i=0; i<liczbawierszy; i++)
            {
                for (int j = 0; j < liczbakolumn; j++)
                {
                    if (dt.Rows[i][j]==DBNull.Value)
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
            for (int i=0; i<lList.Count; i++)
            {
                L[i, 0] = lList[i];
            }
            var parray = pList.ToArray();
           // var P = Matrix<double>.Build;
          
            Matrix<double> P = new DiagonalMatrix(pList.Count,pList.Count, parray);

            FormOtworzRTB macierza = new FormOtworzRTB();
            macierza.Show();
            macierza.richTextBox1.AppendText(A.ToMatrixString());

            var AT = A.Transpose();
            var ATP = AT.Multiply(P);
            var ATPA = ATP.Multiply(A);
            var ATPAinverse = ATPA.Inverse();
            var ATPL = ATP.Multiply(L);
            var X = ATPAinverse.Multiply(ATPL);
            var X2 = A.Solve(L);
            macierza.richTextBox1.AppendText("\r\nA\r\n" + X.ToMatrixString()+ "\r\n");
            var xTab = X.ToArray();
            macierza.richTextBox1.AppendText("\r\nX\r\n"+X.ToString() + "\r\n");
            macierza.richTextBox1.AppendText("\r\nX2\r\n" + X2.ToString() + "\r\n");
            var ax = A.Multiply(X);
            var axl = ax - L;
            macierza.richTextBox1.AppendText("\r\nAx+L\r\n"+axl.ToString() + "\r\n");

            macierza.richTextBox1.AppendText("\r\nP\r\n" + P.ToString() + "\r\n");

            int i2 = 0;
            foreach (DataRow row in database1DataSet.PunktyNieznane.Rows)
            {
                if (Convert.ToBoolean(row.ItemArray[2]) == true && Convert.ToBoolean(row.ItemArray[3]) == false)
                {
                    var nowywiersz = dt2.NewRow();
                    nowywiersz["Nazwa"] = row.ItemArray[1];
                    nowywiersz["X"] = Convert.ToDouble(row.ItemArray[4])+pList[i2];
                    i2++;
                    nowywiersz["Y"] = Convert.ToDouble(row.ItemArray[5]) + pList[i2];
                    i2+=2;
                    nowywiersz["H"] = Convert.ToDouble(row.ItemArray[6]);
                    dt2.Rows.Add(nowywiersz);
                }
            }

            dataGridView2.DataSource = dt2;
            dataGridView2.Columns["Nazwa"].DefaultCellStyle.Format = "#";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            odczyt();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            wyrównanie();
        }

        //Transformacja między układami
        private void tachimetryczny_geodezyjny(out Matrix<double>XYZ, Matrix<double> xyz)
        {
            double B = 0, L = 0, ksi = 0, eta = 0,sigma=0;


        Matrix<double> R1 = DenseMatrix.OfArray(new double[,] {
        {-Math.Sin(B)*Math.Cos(L),-Math.Sin(B)*Math.Sin(L),Math.Cos(B)},
        {-Math.Sin(B),Math.Cos(L),0},
        {Math.Cos(B)*Math.Cos(L),Math.Cos(B)*Math.Sin(L),Math.Sin(B)}});

            Matrix<double> R2 = DenseMatrix.OfArray(new double[,] {
        {1,-eta*Math.Tan(B),-ksi},
        {eta*Math.Tan(B),1,-eta},
        {ksi,eta,1}});

            Matrix<double> R3 = DenseMatrix.OfArray(new double[,] {
        {Math.Cos(sigma),Math.Sin(sigma),0},
        {-Math.Sin(sigma),Math.Cos(sigma),0},
        {0,0,1}});

             XYZ = R3.Transpose()*R2.Transpose()*R1.Transpose()*xyz;
        }
        private void geodezyjny_tachimetryczny( Matrix<double> XYZ, out Matrix<double> xyz)
        {
            double B = 0, L = 0, ksi = 0, eta = 0, sigma = 0;


            Matrix<double> R1 = DenseMatrix.OfArray(new double[,] {
        {-Math.Sin(B)*Math.Cos(L),-Math.Sin(B)*Math.Sin(L),Math.Cos(B)},
        {-Math.Sin(B),Math.Cos(L),0},
        {Math.Cos(B)*Math.Cos(L),Math.Cos(B)*Math.Sin(L),Math.Sin(B)}});

            Matrix<double> R2 = DenseMatrix.OfArray(new double[,] {
        {1,-eta*Math.Tan(B),-ksi},
        {eta*Math.Tan(B),1,-eta},
        {ksi,eta,1}});

            Matrix<double> R3 = DenseMatrix.OfArray(new double[,] {
        {Math.Cos(sigma),Math.Sin(sigma),0},
        {-Math.Sin(sigma),Math.Cos(sigma),0},
        {0,0,1}});

            xyz =  R3 * R2 * R1*XYZ;
        }

        private void tSBSzkic_Click(object sender, EventArgs e)
        {
            this.punktyNieznaneTableAdapter.Fill(this.database1DataSet.PunktyNieznane);
                this.tachimetrTableAdapter1.Fill(this.database1DataSet.Tachimetr);
                List<XYZ> listawsp = new List<XYZ>();
                List<LiniePointPoint> listaLinii = new List<LiniePointPoint>();
                try
                {
                    foreach (DataRow row2 in database1DataSet.PunktyNieznane.Rows)
                    {
                        double x = Convert.ToDouble(row2["X"]);
                        double y= Convert.ToDouble(row2["Y"]);
                        string nazwa = row2["Nazwa"].ToString();
                        listawsp.Add(new XYZ(nazwa,x,y));
                    }


                    foreach (DataRow row in database1DataSet.Tachimetr.Rows)
                    {
                        var stanowisko = row.ItemArray[1].ToString();
                        var cel = row.ItemArray[2].ToString();
                        listaLinii.Add(new LiniePointPoint(stanowisko, cel));
                    }
                }
                catch (Exception e2)
                {
                    MessageBox.Show("Brak punktów do szkicu");
                    //throw;
                }
                FormSzkic fSzkic = new FormSzkic(listawsp,listaLinii);
            fSzkic.MdiParent = this.MdiParent;
                fSzkic.Show();
            
        }
    }
}

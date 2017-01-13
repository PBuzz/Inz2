using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using M=System.Math;

namespace Inz
{
    public partial class FormTest2 : Form
    {
        public FormTest2()
        {
            InitializeComponent();
        }

        private void transformacjaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.transformacjaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void FormTest2_Load(object sender, EventArgs e)
        {
            DoubleBuffer(
                transformacjaDataGridView, true);
            DoubleBuffer(wektory2DataGridView,true);
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'database1DataSet.Wektory2' . Możesz go przenieść lub usunąć.
            this.wektory2TableAdapter.Fill(this.database1DataSet.Wektory2);
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'database1DataSet.Transformacja' . Możesz go przenieść lub usunąć.
            this.transformacjaTableAdapter.Fill(this.database1DataSet.Transformacja);

        }

        private void Wspolrzedne_wczytanie()
        {
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
                this.transformacjaTableAdapter.Fill(this.database1DataSet.Transformacja);
                con.Close();
                //punktyNieznaneDataGridView.DataSource = dt;
                var modultransformacji = new Transformacja();

                foreach (DataRow row in dt.Rows)
                {
                    bool nazwapkt = database1DataSet.Transformacja.Any(punkt => punkt.Nazwa.Equals(row[1]));
                    if (nazwapkt == false)
                    {

                        var X = Convert.ToDouble(row[2]);
                        var Y = Convert.ToDouble(row[3]);
                        var Z = Convert.ToDouble(row[4]);
                        var a = Properties.Settings.Default.elipsoida_a;
                        var b = Properties.Settings.Default.elipsoida_b;
                        var f = Properties.Settings.Default.elipsoida_f;
                        double fi, lambda, h,xGk,yGk,ksi,eta;
                        modultransformacji.Hirvonen(X,Y,Z,a,b,out fi,out lambda,out h);
                        modultransformacji.GaussKruger1(fi,lambda,lambda,out xGk,out yGk);
                        modultransformacji.odczytBL(fi,lambda,out ksi,out eta);
                        transformacjaTableAdapter.Insert(row[1].ToString(),X,Y,Z,fi,lambda,h,xGk,yGk,ksi,eta,null,null,null);
                    }
                    
                }
               

                this.transformacjaTableAdapter.Fill(this.database1DataSet.Transformacja);
                bool czyjuż = false;
                this.wektoryTableAdapter.Fill(this.database1DataSet.Wektory);
                while (czyjuż!=true)
                {
                    czyjuż = true;
                    foreach (DataRow row in database1DataSet.Wektory.Rows)
                    {

                        var nazwaRover = row["koniec"].ToString();
                        var nazwaBaza = row["poczatek"].ToString();
                        bool istnieje = database1DataSet.Transformacja.Any(punkt => punkt.Nazwa.Equals(nazwaRover));
                        DataRow wspBazy = database1DataSet.Transformacja.Where(rowcel => rowcel.Nazwa.Equals(nazwaBaza)).FirstOrDefault();
                        if (wspBazy != null&&istnieje!=true)
                        {
                            var DX = (double)row["DX"];
                            var DY = (double)row["DY"];
                            var DZ = (double)row["DZ"];
                            var X = (double) wspBazy["X"] + DX;
                            var Y = (double)wspBazy["Y"] + DY;
                            var Z = (double)wspBazy["Z"] + DZ;
                            var a = Properties.Settings.Default.elipsoida_a;
                            var b = Properties.Settings.Default.elipsoida_b;
                            var f = Properties.Settings.Default.elipsoida_f;
                            double fi, lambda, h, xGk, yGk, ksi, eta;
                            modultransformacji.Hirvonen(X, Y, Z, a, b, out fi, out lambda, out h);
                            modultransformacji.GaussKruger1(fi, lambda, lambda, out xGk, out yGk);
                            modultransformacji.odczytBL(fi, lambda, out ksi, out eta);
                            transformacjaTableAdapter.Insert(nazwaRover, X, Y, Z, fi, lambda, h, xGk, yGk, ksi, eta, null,
                                null,
                                null);
                            czyjuż = false;
                        }
                        transformacjaTableAdapter.Fill(this.database1DataSet.Transformacja);

                    }
                    }
                    
                
                this.transformacjaTableAdapter.Fill(this.database1DataSet.Transformacja);

            }
        }

        void odczyt()
        {
            this.tachimetrTableAdapter.Fill(this.database1DataSet.Tachimetr);
            this.transformacjaTableAdapter.Fill(this.database1DataSet.Transformacja);
            var rtBotworz = new FormOtworzRTB();
            rtBotworz.MdiParent = this.MdiParent;
            rtBotworz.Show();
            var oblazymut = new Wspprzyb();
            double azymut = 0;
            double odczyt_nawiazania = 0;
            bool nawiazanie = false;
            string stanowsikopoprzednie = "";
            bool czyjuz = false;
            bool braknawiazania = true;
            var obliczenia = new Transformacja();
            var b = Properties.Settings.Default.elipsoida_b;
            var a = Properties.Settings.Default.elipsoida_a;
            var f = Properties.Settings.Default.elipsoida_f;
            var modultransformacji = new Transformacja();
            int licznik = 0;
            toolStripProgressBar1.Maximum = database1DataSet.Tachimetr.Rows.Count;
            while (czyjuz != true)
            {
                toolStripProgressBar1.Value = 0;
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
                        database1DataSet.Transformacja.Any(punkt => punkt.Nazwa.Equals(cel));
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
                        database1DataSet.Transformacja.Any(
                            punkt => punkt.Nazwa.Equals(stanowisko));
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
                        bool stanowisko3 = database1DataSet.Transformacja.Any(punkt => punkt.Nazwa.Equals(stanowisko));
                        DataRow celRow =
                            database1DataSet.Transformacja.Where(rowcel => rowcel.Nazwa.Equals(cel)).FirstOrDefault();
                        DataRow stRow =
                            database1DataSet.Transformacja.AsEnumerable()
                                .Where(rowst => rowst.Nazwa == stanowisko)
                                .FirstOrDefault();
                        //tu coś zmienic
                        double sB = Convert.ToDouble(stRow["B"]);
                        double sL = Convert.ToDouble(stRow["L"]);
                        double cB = Convert.ToDouble(celRow["B"]);
                        double cL = Convert.ToDouble(celRow["L"]);
                        obliczenia.Vincenty(sB, sL, cB, cL, a, b, f,out azymut);
                        dowyswietlenia = dowyswietlenia + "azymut: " + azymut + "\n";
                        nawiazanie = true;
                        odczyt_nawiazania = Convert.ToDouble(row.ItemArray[3]);
                        braknawiazania = false;
                    }
                    if (celistnieje == false && stanowiskoistnieje && nawiazanie)
                    {
                        DataRow stRow =
                            database1DataSet.Transformacja.AsEnumerable()
                                .Where(rowst => rowst.Nazwa == stanowisko)
                                .FirstOrDefault();
                        double sx = Convert.ToDouble(stRow["X"]);
                        double sy = Convert.ToDouble(stRow["Y"]);
                        double sz = Convert.ToDouble(stRow["Z"]);
                        var odl = Convert.ToDouble(row[5]);
                        var hi = Convert.ToDouble(row[6]);
                        var hc = Convert.ToDouble(row[7]);
                        var alfa = Convert.ToDouble(row[3]);
                        var beta = Convert.ToDouble(row[4]);

                        var przyrosty = oblazymut.Oblbiegunowe(0,0, 0, odl, alfa, 0,0
                          , beta, hi, hc);
                        var eta = (double) stRow["eta"];
                        var ksi = (double)stRow["ksi"];
                        /*var temp=ksi;
                        ksi = eta;
                        eta = temp;*/
                        var ksirad = ksi * Math.PI / (180 * 60 * 60);
                       var  etarad = eta * Math.PI / (180 * 60 * 60);
                       


                        double B = Convert.ToDouble(stRow["B"]);
                        double L = Convert.ToDouble(stRow["L"]);
                        var Brad = B*Math.PI/180;
                        var Lrad = L* Math.PI / 180;
                        Matrix<double> xyz = DenseMatrix.OfArray(new double[,] {
                        {przyrosty.X},
                         {przyrosty.Y},
                        {przyrosty.H}});
                        dowyswietlenia += " Odnaleziono punkt " + cel+"\n";
                        var sigma = azymut - odczyt_nawiazania;
                        sigma = sigma*Math.PI/200;
                        var sigma2 = sigma;
                        //sigma = 0;



            Matrix<double> R3 = DenseMatrix.OfArray(new double[,] {
                        {Math.Cos(sigma),Math.Sin(sigma),0},
                        {-Math.Sin(sigma),Math.Cos(sigma),0},
                        {0,0,1}});

                        Matrix<double> R2 = DenseMatrix.OfArray(new double[,] {
                        {1,-etarad*Math.Tan(Brad),-ksirad},
                          {etarad*Math.Tan(Brad),1,-etarad},
                         {ksirad,etarad,1}});

                        Matrix<double> R13 = DenseMatrix.OfArray(new double[,]
                        {
                            {-Math.Sin(Brad)*Math.Cos(Lrad), -Math.Sin(Brad)*Math.Sin(Lrad), Math.Cos(Brad)},
                            {-Math.Sin(Lrad), Math.Cos(Lrad), 0},
                            {Math.Cos(Brad)*Math.Cos(Lrad), Math.Cos(Brad)*Math.Sin(Lrad), Math.Sin(Brad)}
                        });
                       
                        var wynik = R13.Transpose() * R2.Transpose() * R3.Transpose() * xyz;
                 //       wektory2TableAdapter.Insert(stanowisko, cel, wynik[0, 0], wynik[1, 0], wynik[2, 0], "Klasyczne-wsp.przyb.", przyrosty.X, przyrosty.Y, przyrosty.H);
                        
                        var X = wynik[0,0]+ sx;
                        var Y = wynik[1,0] + sy;
                        var Z = wynik[2,0] + sz;
                        double fi, lambda, h, xGk, yGk, ksi2, eta2;
                        modultransformacji.Hirvonen(X, Y, Z, a, b, out fi, out lambda, out h);
                        modultransformacji.GaussKruger1(fi, lambda, lambda, out xGk, out yGk);
                        modultransformacji.odczytBL(fi, lambda, out ksi2, out eta2);
                        transformacjaTableAdapter.Insert(cel, X, Y, Z, fi, lambda, h, xGk, yGk, ksi2, eta2, przyrosty.X, przyrosty.Y,
                            przyrosty.H);
                        
                    }
                    stanowsikopoprzednie = stanowisko;
                    toolStripProgressBar1.Increment(1);
                    rtBotworz.richTextBox1.AppendText(dowyswietlenia);
                }
                if (braknawiazania)
                {
                    rtBotworz.richTextBox1.AppendText("Brak nawiązania!!");
                    break;
                }
                this.transformacjaTableAdapter.Fill(this.database1DataSet.Transformacja);
                toolStripProgressBar1.Value = 0;
                this.wektory2TableAdapter.Fill(this.database1DataSet.Wektory2);
                oblicz_GK();
            }
        }



        

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
            odczyt();
        }

        private void oblicz_GK()
        {
            var modultransformacji = new Transformacja();
            double Lsr = database1DataSet.Transformacja.Average(r => r.L);
            foreach (var row in database1DataSet.Transformacja)
            {
                var B = (double)row["B"];
                var L = (double)row["L"];
                double xGk, yGk;
                modultransformacji.GaussKruger1(B,L,Lsr,out xGk,out yGk);
                row.Xgk = xGk;
                row.Ygk = yGk;
            }
            this.Validate();
            this.transformacjaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void szkic_GK()
        {
            {
                this.transformacjaTableAdapter.Fill(this.database1DataSet.Transformacja);
                this.tachimetrTableAdapter.Fill(this.database1DataSet.Tachimetr);
                List<XYZ> listawsp = new List<XYZ>();
                List<LiniePointPoint> listaLinii = new List<LiniePointPoint>();
                try
                {
                    foreach (DataRow row2 in database1DataSet.Transformacja.Rows)
                    {
                        double x = Convert.ToDouble(row2["Xgk"]);
                        double y = Convert.ToDouble(row2["Ygk"]);
                        string nazwa = row2["Nazwa"].ToString();
                        listawsp.Add(new XYZ(nazwa, x, y));
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
                FormSzkic fSzkic = new FormSzkic(listawsp, listaLinii);
                fSzkic.MdiParent = this.MdiParent;
                fSzkic.Show();

            }
        }
        private double radiany(double wartosc)
        {
            return wartosc * Math.PI / 180;
        }

        private void pobierzWspółrzędneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Wspolrzedne_wczytanie();
            
            this.transformacjaTableAdapter.Fill(this.database1DataSet.Transformacja);

        }

        private void obliczPrzybliżoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            odczyt();
       
            
        }

        private void szkicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            szkic_GK();
            
        
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            oblicz_GK();
        }

        private void TworzWektory()
        {
           
            this.tachimetrTableAdapter.Fill(this.database1DataSet.Tachimetr);
            this.transformacjaTableAdapter.Fill(this.database1DataSet.Transformacja);
            var oblazymut = new Wspprzyb();
            var obliczenia2 = new Transformacja();
            foreach (DataRow row in database1DataSet.Tachimetr.Rows)
            {
               string stanowisko = (row["Stanowisko"].ToString());
                string cel = (row["Cel"].ToString());
                var odl = Convert.ToDouble(row[5]);
                var hi = Convert.ToDouble(row[6]);
                var hc = Convert.ToDouble(row[7]);
                var alfa = Convert.ToDouble(row[3]);
                var beta = Convert.ToDouble(row[4]);

                DataRow celRow =database1DataSet.Transformacja.Where(rowcel => rowcel.Nazwa.Equals(cel)).FirstOrDefault();
                DataRow stRow =database1DataSet.Transformacja.AsEnumerable().Where(rowst => rowst.Nazwa.Equals(stanowisko)).FirstOrDefault();

                double B = Convert.ToDouble(stRow["B"]);
                double L = Convert.ToDouble(stRow["L"]);
                double Bc = Convert.ToDouble(celRow["B"]);
                double Lc = Convert.ToDouble(celRow["L"]);
                var b = Properties.Settings.Default.elipsoida_b;
                var a = Properties.Settings.Default.elipsoida_a;
                var f = Properties.Settings.Default.elipsoida_f;
                double azymut; obliczenia2.Vincenty(B, L, Bc, Lc, a, b, f, out azymut);
                var Brad = B * Math.PI / 180;
                var Lrad = L * Math.PI / 180;
                double sigma = 0;

                var przyrosty = oblazymut.Oblbiegunowe(0, 0, 0, odl, azymut, 0, 0
                         , beta, hi, hc);
                var eta = (double)stRow["eta"];
                var ksi = (double)stRow["ksi"];
                var ksirad = ksi * Math.PI / (180 * 60 * 60);
                var etarad = eta * Math.PI / (180 * 60 * 60);
                var betaRad = beta*M.PI/200;
                var azymutRad = azymut*M.PI/200;
                var ms = Properties.Settings.Default.bladdlugosci1/1000000 +
                         Properties.Settings.Default.bladdlugosci2/1000000*odl;
                double  malfa = Properties.Settings.Default.bladkierunkucc/10000*M.PI/200, mbeta = malfa, mi = Properties.Settings.Default.bladwysantm/1000000, mj = mi;
                var mx2 = M.Pow(M.Cos(azymutRad)*M.Sin(azymutRad), 2)*M.Pow(ms, 2) +
                          M.Pow((-M.Sin(azymutRad)*M.Sin(betaRad)*odl), 2)*M.Pow(malfa, 2) +
                          M.Pow(odl*M.Cos(azymutRad)*M.Cos(betaRad),2)*M.Pow(mbeta, 2);
                var my2 = M.Pow(M.Sin(azymutRad) * M.Sin(azymutRad), 2) * M.Pow(ms, 2) +
                          M.Pow((M.Cos(azymutRad) * M.Sin(betaRad) * odl), 2) * M.Pow(malfa, 2) +
                          M.Pow(odl * M.Sin(azymutRad) * M.Cos(betaRad), 2) * M.Pow(mbeta, 2);
                var mz2 = M.Pow(M.Cos(betaRad), 2)*M.Pow(ms, 2) + M.Pow(odl*-M.Sin(betaRad), 2)*M.Pow(mbeta, 2) + M.Pow(mi, 2) +
                          M.Pow(mj, 2);
                Matrix<double>bledy = DenseMatrix.OfArray(new double[,]
                {
                     { mx2,0,0},
                     { 0,my2,0},
                    { 0,0,mz2}});


                Matrix<double> xyz = DenseMatrix.OfArray(new double[,] {
                        {przyrosty.X},
                         {przyrosty.Y},
                        {przyrosty.H}});
                Matrix<double> R3 = DenseMatrix.OfArray(new double[,] {
                        {Math.Cos(sigma),Math.Sin(sigma),0},
                        {-Math.Sin(sigma),Math.Cos(sigma),0},
                        {0,0,1}});

                Matrix<double> R2 = DenseMatrix.OfArray(new double[,] {
                        {1,-etarad*Math.Tan(Brad),-ksirad},
                          {etarad*Math.Tan(Brad),1,-etarad},
                         {ksirad,etarad,1}});

                Matrix<double> R13 = DenseMatrix.OfArray(new double[,]
                {
                            {-Math.Sin(Brad)*Math.Cos(Lrad), -Math.Sin(Brad)*Math.Sin(Lrad), Math.Cos(Brad)},
                            {-Math.Sin(Lrad), Math.Cos(Lrad), 0},
                            {Math.Cos(Brad)*Math.Cos(Lrad), Math.Cos(Brad)*Math.Sin(Lrad), Math.Sin(Brad)}
                });
                
                
                var wynik = R13.Transpose() * R2.Transpose() * R3.Transpose() * xyz;
                var dlugosc = Math.Sqrt((Math.Pow(wynik[0, 0], 2) + Math.Pow(wynik[1, 0], 2)+ Math.Pow(wynik[2, 0], 2)));
                var obrot1 = R3*R2*R13;
                var obrot2 = R13.Transpose() * R2.Transpose() * R3.Transpose();
                var wynikbledy = obrot1*bledy*obrot2;
                var mx = M.Sqrt(wynikbledy[0, 0]);
                var my = M.Sqrt( wynikbledy[1, 1]);
                var mz = M.Sqrt(wynikbledy[2, 2]);
                wektory2TableAdapter.Insert(stanowisko, cel, wynik[0, 0], wynik[1, 0], wynik[2, 0], "Klasyczne-obl.wekt.", przyrosty.X, przyrosty.Y, przyrosty.H,mx,my,mz,dlugosc);
                
            }
            foreach (DataRow row in database1DataSet.Wektory.Rows)
            {
                var dlugosc = Math.Sqrt((Math.Pow(Convert.ToDouble(row["DX"]), 2) + Math.Pow(Convert.ToDouble(row["DY"]), 2) + Math.Pow(Convert.ToDouble(row["DZ"]), 2)));
                wektory2TableAdapter.Insert(row["poczatek"].ToString(), row["koniec"].ToString(), Convert.ToDouble(row["DX"]), Convert.ToDouble(row["DY"]), Convert.ToDouble(row["DZ"]),"RTKLib",null,null,null, Convert.ToDouble(row["sdx"]), Convert.ToDouble(row["sdy"]), Convert.ToDouble(row["sdz"]), dlugosc);
            }

            this.wektory2TableAdapter.Fill(this.database1DataSet.Wektory2);

        }
        public static void DoubleBuffer(DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }

        private void zróbWszystkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Trwa wczytywanie współrzędnych";
            toolStripStatusLabel1.ResetMargin();
            Wspolrzedne_wczytanie();
            toolStripStatusLabel1.Text = "Trwa obliczanie współrzędnych przybliżonych";
            toolStripStatusLabel1.ResetMargin();
            odczyt();
            toolStripStatusLabel1.Text = "Trwa tworzenie wektorów";
            toolStripStatusLabel1.ResetMargin();
            TworzWektory();
            toolStripStatusLabel1.Text = "Zrobione";

        }

        private void twórzWektoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TworzWektory();
        }

        private void wektory2BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.wektory2BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MathNet.Numerics.Statistics;


namespace Inz
{
    public partial class FormWczytajWektor : Form
    {
        
        public FormWczytajWektor()
        {
            InitializeComponent();

        }
        public DataTable dt;

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int dlugoscplikow=0;
                foreach (string file in openFileDialog1.FileNames)
                {
                    dlugoscplikow += File.ReadLines(file).Count();
                }
                object sumadlugosci = dlugoscplikow;
                
                progressbar(sumadlugosci);
                foreach (String file in openFileDialog1.FileNames)
                {

                    ladowanieDoTabeli(file);
                    
                }
                wektoryTableAdapter.Fill(database1DataSet.Wektory);
                toolStripProgressBar1.Maximum = 0;
            }
        }

        private void ladowanieDoTabeli(string file)
        {
            bool flag1 = false;

            using (var sr = new StreamReader(file))
            {
                bool flag2 = false;
                string poczatek = "";
                string koniec = "";
                var sciezka = Regex.Split(file, @"\\");
                string nazwapliku = sciezka.Last();
                var skladowe = nazwapliku.Split('-');
                if (skladowe.Length == 2)
                {
                    poczatek = skladowe[0];
                    var drugi = skladowe[1].Split('.');
                    koniec = drugi[0];
                    flag2 = true; //potrzeban do wyboru insert w adapterze
                }
                string wiersz;
                double X = 0, Y = 0, Z = 0, ratio = 0;
                double sumasdx = 0, sumasdy = 0, sumasdz = 0, sumasdxy = 0, sumasdyz = 0, sumasdzx = 0, sumaratio = 0;
                int i = 0;
                int n = 0;
                double xbaza = 0, ybaza = 0, zbaza = 0, DX = 0, DY = 0, DZ = 0;
                List<double> ratiolist = new List<double>();

                while ((wiersz = sr.ReadLine()) != null)
                {
                    if (flag1)
                    {

                        if (Convert.ToInt32(new string(wiersz.ToCharArray(71, 1))) == 1)
                        {
                            wiersz = wiersz.Replace(".", ",");
                            X += Convert.ToDouble(new string(wiersz.ToCharArray(26, 15)));
                            Y += Convert.ToDouble(new string(wiersz.ToCharArray(41, 15)));
                            Z += Convert.ToDouble(new string(wiersz.ToCharArray(56, 15)));
                            sumasdx += Convert.ToDouble(new string(wiersz.ToCharArray(79, 7)));
                            sumasdy += Convert.ToDouble(new string(wiersz.ToCharArray(88, 7)));
                            sumasdz += Convert.ToDouble(new string(wiersz.ToCharArray(97, 7)));
                            sumasdxy += Convert.ToDouble(new string(wiersz.ToCharArray(106, 7)));
                            sumasdyz += Convert.ToDouble(new string(wiersz.ToCharArray(115, 7)));
                            sumasdzx += Convert.ToDouble(new string(wiersz.ToCharArray(124, 7)));
                            ratio += Convert.ToDouble(new string(wiersz.ToCharArray(139, 5)));
                            sumaratio += ratio;
                            ratiolist.Add(ratio);
                            i++;
                        }
                        else
                        {
                            n++;
                        }

                    }

                    if (wiersz.Contains("%  GPST"))
                    {
                        flag1 = true;
                    }
                    if (wiersz.Contains("% ref pos"))
                    {
                        wiersz = wiersz.Replace('.', ',');
                        xbaza = Convert.ToDouble(wiersz.Substring(14, 14));
                        ybaza = Convert.ToDouble(wiersz.Substring(28, 14));
                        zbaza = Convert.ToDouble(wiersz.Substring(42, 13));
                    }


                }
                X = X / i;
                Y = Y / i;
                Z = Z / i;
                DX = X - xbaza;
                DY = Y - ybaza;
                DZ = Z - zbaza;
                var sdx = Math.Sqrt(Math.Pow(sumasdx, 2) / i);
                var sdy = Math.Sqrt(Math.Pow(sumasdy, 2) / i);
                var sdz = Math.Sqrt(Math.Pow(sumasdz, 2) / i);
                var sdxy = Math.Sqrt(Math.Pow(sumasdxy, 2) / i);
                var sdyz = Math.Sqrt(Math.Pow(sumasdyz, 2) / i);
                var sdzx = Math.Sqrt(Math.Pow(sumasdzx, 2) / i);
                var ratiosr = sumaratio / i;
                double fixedprocent = (double)i / (double)(i + n);
                var ratiomin = ratiolist.Minimum();
                var ratiomax = ratiolist.Maximum();

                if (flag2)
                {
                    wektoryTableAdapter.Insert(poczatek, koniec, X, Y, Z, sdx, sdy, sdz, sdxy, sdyz, sdzx, ratiosr,
                       file, i, n, DX, DY, DZ, ratiomin, ratiomax, fixedprocent, null);
                }
                else
                {
                    wektoryTableAdapter.Insert(null, null, X, Y, Z, sdx, sdy, sdz, sdxy, sdyz, sdzx, ratio, file, i,
                        n, DX, DY, DZ, ratiomin, ratiomax, fixedprocent, null);
                }

            }
        }

        private void FormWczytajWektor_Load(object sender, EventArgs e)
        {
           DoubleBuffer(wektoryDataGridView,true);

            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'database1DataSet.Wektory' . Możesz go przenieść lub usunąć.
            this.wektoryTableAdapter.Fill(this.database1DataSet.Wektory);

        }
        public static void DoubleBuffer(DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }

        private void wektoryBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.wektoryBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void wektoryDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView) sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var indez = e.RowIndex;
                string sciezka = wektoryDataGridView.Rows[indez].Cells["sciezka"].Value.ToString();
               
                
                var rtBotworz = new FormOtworzRTB();
                rtBotworz.Show();
                rtBotworz.MdiParent = this.MdiParent;
                rtBotworz.Text = "Podgląd";
                rtBotworz.richTextBox1.Lines = CzytajPlikTekst(sciezka);
            }
        }

        public static string[] CzytajPlikTekst(string nazwaPliku)
        {
            var tekst = new List<string>();
            try
            {
                using (var sr = new StreamReader(nazwaPliku))
                {
                    string wiersz;
                    while ((wiersz = sr.ReadLine()) != null)
                        tekst.Add(wiersz);
                }
                return tekst.ToArray();
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd " + e);
                return null;
            }
        }

        private void progressbar(object max)
        {
            var max2 = (int) max+2;
            toolStripProgressBar1.Maximum = max2;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            obliczZRtkliba();
        }

        private void obliczZRtkliba()
        {
            rinexTableAdapter1.Fill(database1DataSet.Rinex);
            var stale = database1DataSet.Rinex.Where(punkt => punkt.staly.Equals(true));
            var wyznaczane = database1DataSet.Rinex.Where(punkt => punkt.staly.Equals(false));
            var ustawienia = Properties.Settings.Default;
           List<string > sciezki= new List<string>();
            foreach (var rowStaly in stale)
            {
                foreach (var rowWyznaczany in wyznaczane)
                {
                    string output = ustawienia.outputPath +@"\"+ rowStaly.Nazwa_punktu + "-" + rowWyznaczany.Nazwa_punktu+".pos";
                    LaunchCommandLineApp(rowWyznaczany.Sciezka,rowStaly.Sciezka,rowStaly.Sciezka_naw,output);
                    sciezki.Add(output);
                }
            }
            foreach (var pkt in sciezki)
            {
                ladowanieDoTabeli(pkt);
            }
            wektoryTableAdapter.Fill(database1DataSet.Wektory);
        }
      //  [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        //public static extern int SetParrent(IntPtr hwc,IntPtr hwp);
        void LaunchCommandLineApp(string rover ,string base1,string navbase,string output)
        {
            
        string @program = @Properties.Settings.Default.rtklibPath;
             @rover = rover.Replace(@"\\", @"\");
            string @baza = base1.Replace(@"\\", @"\");
            string @nav = @navbase.Replace(@"\\", @"\");
            string @config = Properties.Settings.Default.config;
            @config = @config.Replace(@"\\", @"\");
            string @arguments = @"-k " + "\"" + @config + "\"" + @" -o "+ "\"" +output+"\""  + " \"" + rover + "\" " + "\"" + baza + "\" " + "\"" + nav + "\"" ;
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = program;
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.Arguments = @arguments;
            
            try
            {
               
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                   // SetParrent(exeProcess.MainWindowHandle, this.Handle);
                    exeProcess.WaitForExit();
                    //exeProcess.WaitForExit();
                }
            }
            catch
            {
                // Log error.
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                Form ustawienia = new FormKonfigRTKLib();
                ustawienia.MdiParent = this.MdiParent;
                ustawienia.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form stworz = new FormTworzWektor();
            stworz.MdiParent = this.MdiParent;
           stworz.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.wektoryTableAdapter.Fill(this.database1DataSet.Wektory);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.wspolrzedneTableAdapter.Fill(database1DataSet.Wspolrzedne);
            this.wektoryTableAdapter.Fill(database1DataSet.Wektory);
            foreach (DataRow row in database1DataSet.Wektory.Rows)
            {
                string nazwaBaza = row["poczatek"].ToString();
                string nazwaRover = row["koniec"].ToString();
               
                var DX = Convert.ToDouble(row["DX"]);
                var DY = Convert.ToDouble(row["DY"]) ;
                var DZ = Convert.ToDouble(row["DZ"]) ;
                double mx = Convert.ToDouble(row["sdx"]);
                double my = Convert.ToDouble(row["sdy"]);
                double mz = Convert.ToDouble(row["sdz"]);
                mx = Math.Pow(mx, 2);
                my = Math.Pow(my, 2);
                mz = Math.Pow(mz, 2);
                var dlugosc = Math.Sqrt(Math.Pow(DX, 2) + Math.Pow(DY, 2) + Math.Pow(DZ, 2));
                wektory2TableAdapter1.Insert(nazwaBaza, nazwaRover, DX, DY, DZ, "GPS", null, null, null,mx,my,mz,dlugosc);
            }

        }
    }
}

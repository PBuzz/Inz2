using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.Statistics;

namespace Inz
{
    public partial class FormTworzWektor : Form
    {
        public FormTworzWektor()
        {
            InitializeComponent();

        }
        DataTable dt = new DataTable();

        private void FormTworzWektor_Load(object sender, EventArgs e)
        {
            
            dt.Columns.Add("nazwa");
            dt.Columns.Add("sciezka");
            dt.Columns.Add("sciezkanaw");
            dt.Columns.Add("poczatek");
            dt.Columns.Add("koniec");
            this.rinexTableAdapter.Fill(this.database1DataSet.Rinex);
            foreach (DataRow row in database1DataSet.Rinex.Rows)
            {
                dt.Rows.Add(row["Nazwa punktu"].ToString(), row["Sciezka"].ToString(), row["Sciezka naw"].ToString(),row["Początek obserwacji"].ToString(), row["Koniec obserwacji"].ToString());
            }
           wsadzListeCbb();
            timer1.Start();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            wsadzListeCbb();
            }

        private void stwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ustawienia = Properties.Settings.Default;
            List<string> sciezki = new List<string>();
            rinexTableAdapter.Fill(database1DataSet.Rinex);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Baza"].Value!=null && row.Cells["Rover"].Value!=null)
                {
                    string nazwaBaza = row.Cells["Baza"].Value.ToString();
                    string nazwaRover = row.Cells["Rover"].Value.ToString();

                    DataRow bazaRow =
                        database1DataSet.Rinex.Where(rowcel => rowcel.Nazwa_punktu.Equals(nazwaBaza)).FirstOrDefault();
                    DataRow roverRow =
                        database1DataSet.Rinex.Where(rowcel => rowcel.Nazwa_punktu.Equals(nazwaRover)).FirstOrDefault();
                    string sciezkaBaza = bazaRow["Sciezka"].ToString();
                    string sciezkaBazanaw = bazaRow["Sciezka naw"].ToString();
                    string sciezkaRover = roverRow["Sciezka"].ToString();
                    string sciezkaRovernaw = roverRow["Sciezka naw"].ToString();


                    string output = ustawienia.outputPath + @"\" + nazwaBaza + "-" + nazwaRover + ".pos";
                    LaunchCommandLineApp(sciezkaRover, sciezkaBaza, sciezkaBazanaw, output);
                    sciezki.Add(output);

                }
            }
            foreach (var pkt in sciezki)
            {
                ladowanieDoTabeli(pkt);
            }
            wektoryTableAdapter.Fill(database1DataSet.Wektory);
        }

        private void wsadzListeCbb()
        {
            int ostatni = dataGridView1.Rows.Count;
            DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell) (dataGridView1.Rows[ostatni - 1].Cells["Baza"]);
            cell.DataSource = dt;
            cell.DisplayMember = "nazwa";
            DataGridViewComboBoxCell cell2 = (DataGridViewComboBoxCell)(dataGridView1.Rows[ostatni - 1].Cells["Rover"]);
            cell2.DataSource = dt;
            cell2.DisplayMember = "nazwa";
        }

        //  [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        //public static extern int SetParrent(IntPtr hwc,IntPtr hwp);
        void LaunchCommandLineApp(string rover, string base1, string navbase, string output)
        {

            string @program = @Properties.Settings.Default.rtklibPath;
            @rover = rover.Replace(@"\\", @"\");
            string @baza = base1.Replace(@"\\", @"\");
            string @nav = @navbase.Replace(@"\\", @"\");
            string @config = Properties.Settings.Default.config;
            @config = @config.Replace(@"\\", @"\");
            string @arguments = @"-k " + "\"" + @config + "\"" + @" -o " + "\"" + output + "\"" + " \"" + rover + "\" " + "\"" + baza + "\" " + "\"" + nav + "\"";
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
                double X = 0, Y = 0, Z = 0,ratio=0;
                double sumasdx = 0, sumasdy = 0, sumasdz = 0, sumasdxy = 0, sumasdyz = 0, sumasdzx = 0, sumaratio = 0;
                int i = 0;
                int n = 0;
                double xbaza=0, ybaza=0, zbaza=0,DX=0,DY=0,DZ=0;
                List<double>ratiolist = new List<double>();

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
                            sumaratio +=ratio;
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
                        xbaza=Convert.ToDouble(wiersz.Substring(14,14));
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
                var fixedprocent = i/(i + n);
                var ratiomin = ratiolist.Minimum();
                var ratiomax = ratiolist.Maximum();
                
                if (flag2)
                {
                    wektoryTableAdapter.Insert(poczatek, koniec, X, Y, Z, sdx, sdy, sdz, sdxy, sdyz, sdzx, ratiosr,
                       file, i, n,DX,DY,DZ,ratiomin,ratiomax,fixedprocent,null);
                }
                else
                {
                    wektoryTableAdapter.Insert(null, null, X, Y, Z, sdx, sdy, sdz, sdxy, sdyz, sdzx, ratio, file, i,
                        n, DX, DY, DZ, ratiomin, ratiomax, fixedprocent, null);
                }
                
            }
        }

        private void ustawieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ustawienia = new FormKonfigRTKLib();
            ustawienia.MdiParent = this.MdiParent;
            ustawienia.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Baza"].Value != null && row.Cells["Rover"].Value != null)
                {
                    string bazaNazwa = row.Cells["Baza"].Value.ToString();
                    string roverNazwa = row.Cells["Rover"].Value.ToString();
                    var baza = database1DataSet.Rinex.Where((rowcel => rowcel.Nazwa_punktu.Equals(bazaNazwa))).FirstOrDefault();
                    var rover = database1DataSet.Rinex.Where((rowcel => rowcel.Nazwa_punktu.Equals(roverNazwa))).FirstOrDefault();
                    var index = row.Index;
                    DateTime poczatek1 = DateTime.Parse(rover["Początek obserwacji"].ToString());
                    DateTime poczatek2 = DateTime.Parse(baza["Początek obserwacji"].ToString());
                    DateTime koniec1 = DateTime.Parse(rover["Koniec obserwacji"].ToString());
                    DateTime koniec2 = DateTime.Parse(baza["Koniec obserwacji"].ToString());

                    DateTime wynik1=poczatek2,wynik2=koniec2;
                    if (poczatek1 > poczatek2)
                        wynik1 = poczatek1;
                    if (koniec1 < koniec2)
                        wynik2 = koniec1;
                    TimeSpan zero = new TimeSpan(0,0,0);
                    var dlugosc = wynik2 - wynik1;
                    if (dlugosc > zero)
                    {
                        row.Cells["Czas_trwania"].Value = dlugosc.ToString();
                        row.Cells["Czas_trwania"].Style.BackColor = Color.Aquamarine;
                    }
                    else
                    {
                        row.Cells["Czas_trwania"].Value = "Brak";
                        row.Cells["Czas_trwania"].Style.BackColor = Color.LightCoral;
                    }
                }
            }
            
        }
    }
}

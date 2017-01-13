using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inz
{
    public partial class FormKonfigRTKLib : Form
    {
        public FormKonfigRTKLib()
        {
            InitializeComponent();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                cBinterwal.Enabled = true;
            else
            {
                cBinterwal.Enabled = false;
            }
        }

        private void FormKonfigRTKLib_Load(object sender, EventArgs e)
        {
            var konfig = Properties.Settings.Default.config;
            wypelnianiecombo();
            load(konfig);
        }



        private void wypelnianiecombo()
        {
            DataTable ionoDt = new DataTable();
            ionoDt.Columns.Add("numer");
            ionoDt.Columns.Add("tekst");
            ionoDt.Rows.Add("off", "Brak");
            ionoDt.Rows.Add("brdc", "Broadcast");
            ionoDt.Rows.Add("dual-freq", "Iono-Free LC");
            ionoDt.Rows.Add("ionex-tec", "IONEX TEC");

            cBJono.DataSource = ionoDt;
            cBJono.ValueMember = "numer";
            cBJono.DisplayMember = "tekst";
            ////////////////////////

            DataTable tropoDt = new DataTable();
            tropoDt.Columns.Add("numer");
            tropoDt.Columns.Add("tekst");
            tropoDt.Rows.Add("off", "Brak");
            tropoDt.Rows.Add("saas", "Saastamoinen");
            tropoDt.Rows.Add("est-ztd", "Estimate ZTD");

            cBTropo.DataSource = tropoDt;
            cBTropo.ValueMember = "numer";
            cBTropo.DisplayMember = "tekst";
            ////////////////////////////////////////
            DataTable satephDt = new DataTable();
            satephDt.Columns.Add("numer");
            satephDt.Columns.Add("tekst");
            satephDt.Rows.Add("brdc", "Boadcast");
            satephDt.Rows.Add("precise", "Precise");

            cBEfememerydy.DataSource = satephDt;
            cBEfememerydy.ValueMember = "numer";
            cBEfememerydy.DisplayMember = "tekst";
            ////////////////////////////////
            DataTable pos2armodeDt = new DataTable();

            pos2armodeDt.Columns.Add("numer");
            pos2armodeDt.Columns.Add("tekst");
            pos2armodeDt.Rows.Add("off", "Brak");
            pos2armodeDt.Rows.Add("continuous", "Ciągły");
            pos2armodeDt.Rows.Add("instantaneous", "Natychmiastowy");
            pos2armodeDt.Rows.Add("fix-and-hold", "Ustal i trzymaj");

            cBNieGPS.DataSource = pos2armodeDt;
            cBNieGPS.ValueMember = "numer";
            cBNieGPS.DisplayMember = "tekst";
            ////////////////////////////////
            /// 
            DataTable pos2gloarmodeDt = new DataTable();

            pos2gloarmodeDt.Columns.Add("numer");
            pos2gloarmodeDt.Columns.Add("tekst");
            pos2gloarmodeDt.Rows.Add("off", "Wyłączony");
            pos2gloarmodeDt.Rows.Add("on", "Włączony");
            pos2gloarmodeDt.Rows.Add("autocal", "Auto");

            cBnieGLO.DataSource = pos2gloarmodeDt;
            cBnieGLO.ValueMember = "numer";
            cBnieGLO.DisplayMember = "tekst";

            DataTable ant2postypeDt = new DataTable();
            ant2postypeDt.Columns.Add("numer");
            ant2postypeDt.Columns.Add("tekst");
            ant2postypeDt.Rows.Add("llh", "Lat/Lon/Height (deg/m)");
            ant2postypeDt.Rows.Add("xyz", "X/Y/Z-ECEF (m)");
            ant2postypeDt.Rows.Add("single", "Average  of Single Position");
            ant2postypeDt.Rows.Add("posfile", "Get from Position File");
            ant2postypeDt.Rows.Add("rinexhead", "RINEX Header Position");
            ant2postypeDt.Rows.Add("rtcm", "RTCM Station Position");

            cBant2postype.DataSource = ant2postypeDt;
            cBant2postype.ValueMember = "numer";
            cBant2postype.DisplayMember = "tekst";

        }



        private void load(string plik)
        {

            string wiersz;
            using (var sr = new StreamReader(plik))
            {
                while ((wiersz = sr.ReadLine()) != null)
                {
                    string nazwa = "";
                    if (wiersz.Length > 20)
                    {
                        nazwa = wiersz.Substring(0, 19);
                    }
                    nazwa = nazwa.Replace(" ", "");
                    switch (nazwa)
                    {
                        case "pos1-elmask":
                            tBMaska.Text = wezUstawienia(wiersz);
                            break;
                        case "pos1-ionoopt":
                            cBJono.SelectedValue = wezUstawienia(wiersz);
                            break;
                        case "pos1-tropopt":
                            cBTropo.SelectedValue = wezUstawienia(wiersz);
                            break;
                        case "pos1-sateph":
                            cBEfememerydy.SelectedValue = wezUstawienia(wiersz);
                            break;
                        case "pos2-armode":
                            cBNieGPS.SelectedValue = wezUstawienia(wiersz);
                            break;
                        case "pos2-gloarmode":
                            cBnieGLO.SelectedValue = wezUstawienia(wiersz);
                            break;
                        case "pos2-arthres":
                            tBMinratio.Text = wezUstawienia(wiersz);
                            break;
                        case "stats-eratio1":
                            tBeratio1.Text = wezUstawienia(wiersz);
                            break;
                        case "stats-eratio2":
                            tBeratio2.Text = wezUstawienia(wiersz);
                            break;
                        case "stats-errphase":
                            tBerrphase.Text = wezUstawienia(wiersz);
                            break;
                        case "stats-errphaseel":
                            tBerrphasel.Text = wezUstawienia(wiersz);
                            break;
                        case "pos1-navsys":
                            int suma = Convert.ToInt32(wezUstawienia(wiersz));
                            var mask = (Navs) suma;
                            var result =
                                Enum.GetValues(typeof(Navs)).Cast<Navs>().Where(value => mask.HasFlag(value)).ToList();
                            zaznaczanieCheckboxow(result);
                            break;

                        case "file-satantfile":
                            tBAntFile.Text = wezUstawienia(wiersz);
                            break;
                        case "file-staposfile":
                            tBstaFile.Text = wezUstawienia(wiersz);
                            break;
                        case "ant1-anttype":
                            cBAnt1.Text = wezUstawienia(wiersz);
                            break;
                        case "ant1-antdele":
                            tB1antdele.Text = wezUstawienia(wiersz);
                            break;
                        case "ant1-antdeln":
                            tB1antdeln.Text = wezUstawienia(wiersz);
                            break;
                        case "ant1-antdelu":
                            tB1antdelu.Text = wezUstawienia(wiersz);
                            break;
                        case "ant2-anttype":
                            cBAnt2.Text = wezUstawienia(wiersz);
                            break;
                        case "ant2-antdele":
                            tB2antdele.Text = wezUstawienia(wiersz);
                            break;
                        case "ant2-antdeln":
                            tB2antdeln.Text = wezUstawienia(wiersz);
                            break;
                        case "ant2-antdelu":
                            tB2antdelu.Text = wezUstawienia(wiersz);
                            break;
                        case "ant2-pos1":
                            tBpos1.Text = wezUstawienia(wiersz);
                            break;
                        case "ant2-pos2":
                            tBpos2.Text = wezUstawienia(wiersz);
                            break;
                        case "ant2-pos3":
                            tBpos3.Text = wezUstawienia(wiersz);
                            break;
                        case "ant2-postype":
                            cBant2postype.SelectedValue = wezUstawienia(wiersz);
                            break;
                            


                    }

                }
            }

        }

        [Flags]
        public enum Navs
        {
            GPS = 1,
            SBAS = 2,
            GLO = 4,
            GAL = 8,
            QZS = 16,
            COMP = 32

        }

        private void zaznaczanieCheckboxow(List<Navs> wyniki)
        {
            for (int i = 0; i < checkedListBox1.Items.Count;i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            foreach (var row in wyniki)
            {
                switch (row)
                {
                    case Navs.GPS:
                        checkedListBox1.SetItemChecked(0, true);
                        break;
                    case Navs.SBAS:
                        checkedListBox1.SetItemChecked(4, true);
                        break;
                    case Navs.GLO:
                        checkedListBox1.SetItemChecked(1, true);
                        break;
                    case Navs.GAL:
                        checkedListBox1.SetItemChecked(2, true);
                        break;
                    case Navs.QZS:
                        checkedListBox1.SetItemChecked(3, true);
                        break;
                    case Navs.COMP:
                        checkedListBox1.SetItemChecked(5, true);
                        break;

                }
            }
        }
        private int sumowanieCheckboxow()
        {
            int sum = 0;
            if (checkedListBox1.GetItemChecked(0))
                sum += 1;
            if (checkedListBox1.GetItemChecked(4))
                sum += 2;
            if (checkedListBox1.GetItemChecked(1))
                sum += 4;
            if (checkedListBox1.GetItemChecked(2))
                sum += 8;
            if (checkedListBox1.GetItemChecked(3))
                sum += 16;
            if (checkedListBox1.GetItemChecked(5))
                sum += 32;
            return sum;


        }

        private string wezUstawienia(string input)
        {

            int start = input.IndexOf("=");
            int end = input.Length;
            if (input.Contains("#"))
            {
                end = input.IndexOf("#", start);
            }
            var wynik = input.Substring(start, end - start);
            wynik = wynik.Replace(" ", "").Replace("=", "");
            return wynik;
        }

        private void checkBoxRover_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRover.Checked)
            {
                cBAnt1.Enabled = true;
                tB1antdele.Enabled = true;
                tB1antdeln.Enabled = true;
                tB1antdele.Enabled = true;
                label11.Enabled = true;
            }
        
    }

        private void save(string plik,string output)
        {
            List<string> ustawienia=new List<string>();


             string wiersz;
            //string wierszust;
            using (var sr = new StreamReader(plik))
            {
                while ((wiersz = sr.ReadLine()) != null)
                {
                    string nazwa = "";
                    if (wiersz.Length > 20)
                    {
                        nazwa = wiersz.Substring(0, 19);
                    }
                    nazwa = nazwa.Replace(" ", "");
                    switch (nazwa)
                    {
                        case "pos1-elmask":
                            wiersz = wsadzUstawienia(wiersz, tBMaska.Text);
                            break;
                        case "pos1-ionoopt":
                            wiersz = wsadzUstawienia(wiersz,cBJono.SelectedValue.ToString());
                            break;
                        case "pos1-tropopt":
                            wiersz = wsadzUstawienia(wiersz, cBTropo.SelectedValue.ToString());
                            break;
                        case "pos1-sateph":
                            wiersz = wsadzUstawienia(wiersz, cBEfememerydy.SelectedValue.ToString());
                            break;
                        case "pos2-armode":
                            wiersz = wsadzUstawienia(wiersz, cBNieGPS.SelectedValue.ToString());
                            break;
                        case "pos2-gloarmode":
                            wiersz = wsadzUstawienia(wiersz, cBnieGLO.SelectedValue.ToString());
                            break;
                        case "pos2-arthres":
                            wiersz = wsadzUstawienia(wiersz, tBMinratio.Text);
                            break;
                        case "stats-eratio1":
                            wiersz = wsadzUstawienia(wiersz, tBeratio1.Text);
                            break;
                        case "stats-eratio2":
                            wiersz = wsadzUstawienia(wiersz, tBeratio2.Text);
                            break;
                        case "stats-errphase":
                            wiersz = wsadzUstawienia(wiersz, tBerrphase.Text);
                            break;
                        case "stats-errphaseel":
                            wiersz = wsadzUstawienia(wiersz, tBerrphasel.Text);
                            break;
                        case "pos1-navsys":
                            wiersz = wsadzUstawienia(wiersz, sumowanieCheckboxow().ToString());
                            break;
                        case "file-satantfile":
                            wiersz = wsadzUstawienia(wiersz, tBAntFile.Text);
                            break;
                        case "file-staposfile":
                            wiersz = wsadzUstawienia(wiersz, tBstaFile.Text);
                            break;
                        case "ant1-anttype":
                            wiersz = wsadzUstawienia(wiersz, cBAnt1.Text);
                            break;
                        case "ant1-antdele":
                            wiersz = wsadzUstawienia(wiersz, tB1antdele.Text);
                          
                            break;
                        case "ant1-antdeln":
                            wiersz = wsadzUstawienia(wiersz, tB1antdeln.Text);
                           
                            break;
                        case "ant1-antdelu":
                            wiersz = wsadzUstawienia(wiersz, tB1antdelu.Text);
                            break;
                        case "ant2-anttype":
                            wiersz = wsadzUstawienia(wiersz, cBAnt2.Text);
                            break;
                        case "ant2-antdele":
                            wiersz = wsadzUstawienia(wiersz, tB2antdele.Text);
                            break;
                        case "ant2-antdeln":
                            wiersz = wsadzUstawienia(wiersz, tB2antdeln.Text);
                            break;
                        case "ant2-antdelu":
                            wiersz = wsadzUstawienia(wiersz, tB2antdelu.Text);
                            break;
                        case "ant2-pos1":
                            wiersz = wsadzUstawienia(wiersz, tBpos1.Text);
                            break;
                        case "ant2-pos2":
                            wiersz = wsadzUstawienia(wiersz, tBpos2.Text);
                            break;
                        case "ant2-pos3":
                            wiersz = wsadzUstawienia(wiersz, tBpos3.Text);
                            break;
                        case "ant2-postype":
                            wiersz = wsadzUstawienia(wiersz, cBant2postype.SelectedValue.ToString());
                            break;



                    }
                    ustawienia.Add(wiersz);

                }
                
            }
            if (plik==output)
            File.Delete(plik);

            using (var sw = new StreamWriter(output))
            {
                foreach (var row in ustawienia)
                {
                    sw.WriteLine(row);
                }

            }
        }

        private string wsadzUstawienia(string wiersz,string tekst)
        {
            wiersz = wiersz.Remove(20, wiersz.Length - 20);
            wiersz += tekst + " #";
            return wiersz;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var plik = Properties.Settings.Default.config;
            save(plik,plik);
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "RTKLib config (*.CONF)|*.CONF";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                load(openFileDialog1.FileName);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var plik = Properties.Settings.Default.config;
            saveFileDialog1.Filter = "RTKLib config (*.CONF)|*.CONF";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        
                save(plik,saveFileDialog1.FileName);

            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

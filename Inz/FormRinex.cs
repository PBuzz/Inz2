using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inz
{
    public partial class FormRinex : Form
    {
        public FormRinex()
        {
            InitializeComponent();
        }

        private void rinexBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.rinexBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void FormRinex_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'database1DataSet.Rinex' . Możesz go przenieść lub usunąć.
            this.rinexTableAdapter.Fill(this.database1DataSet.Rinex);

        }

        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;

            openFileDialog1.Filter = "Rinex obs (*.??o)|*.??o";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog1.FileNames)
                {
                    string nazwa="", numer="";
                    DateTime datapocz = DateTime.Now;
                    DateTime datakonc = datapocz;
                    DateTime wzorzec = datapocz;
                    double interwal=60;
                    string wiersz;
                    using (var sr = new StreamReader(file))
                    {
                        while (( wiersz = sr.ReadLine()) != null)
                        {
                            if (wiersz.Contains("MARKER NAME"))
                            {
                                nazwa =  (new string(wiersz.ToCharArray(0, 59)));
                                nazwa = nazwa.Replace(" ",string.Empty);
                            }
                            if (wiersz.Contains("MARKER NUMBER"))
                            {
                                numer = (new string(wiersz.ToCharArray(0, 20)));
                                numer = numer.Replace(" ", string.Empty);
                            }
                        if (wiersz.Contains("TIME OF FIRST OBS"))
                        {wiersz = wiersz.Replace('.', ',');
                            var rok = Convert.ToInt32(new string(wiersz.ToCharArray(0, 6)));
                            var mies = Convert.ToInt32(new string(wiersz.ToCharArray(6, 6)));
                            var dzien = Convert.ToInt32(new string(wiersz.ToCharArray(12, 6)));
                            var godz = Convert.ToInt32(new string(wiersz.ToCharArray(18, 6)));
                            var min = Convert.ToInt32(new string(wiersz.ToCharArray(24, 6)));
                            var sek = Convert.ToInt32((new string(wiersz.ToCharArray(30, 13))).Split(',')[0]);
                                var ms = Convert.ToInt32((new string(wiersz.ToCharArray(30, 13))).Split(',')[1]);
                                datapocz = new DateTime(rok,mies,dzien,godz,min,sek,ms);
                        }
                        if (wiersz.Contains("TIME OF LAST OBS"))
                        {
                            wiersz = wiersz.Replace('.', ',');
                            var rok = Convert.ToInt32(new string(wiersz.ToCharArray(0, 6)));
                            var mies = Convert.ToInt32(new string(wiersz.ToCharArray(6, 6)));
                            var dzien = Convert.ToInt32(new string(wiersz.ToCharArray(12, 6)));
                            var godz = Convert.ToInt32(new string(wiersz.ToCharArray(18, 6)));
                            var min = Convert.ToInt32(new string(wiersz.ToCharArray(24, 6)));
                                var sek = Convert.ToInt32((new string(wiersz.ToCharArray(30, 13))).Split(',')[0]);
                                var ms = Convert.ToInt32((new string(wiersz.ToCharArray(30, 13))).Split(',')[1]);
                                datakonc = new DateTime(rok, mies, dzien, godz, min, sek, ms);
                            }
                        if (wiersz.Contains("INTERVAL"))
                        {
                            wiersz = wiersz.Replace('.', ',');
                                    interwal = Convert.ToDouble(new string(wiersz.ToCharArray(5, 5))); }

                            if (wiersz.Contains("END OF HEADER"))
                            {
                                var filenav = file.Remove(file.Length - 1, 1) + "n";
                                if (File.Exists(filenav))
                                {
                                    if (datakonc == wzorzec)
                                    {
                                        rinexTableAdapter.Insert(nazwa, numer, datapocz, null, interwal, file, filenav, false);
                                    }
                                    if (datapocz == wzorzec)
                                    {
                                        rinexTableAdapter.Insert(nazwa, numer, null, datakonc, interwal, file, filenav, false);
                                    }
                                    if (datakonc == wzorzec && datapocz == wzorzec)
                                    {
                                        rinexTableAdapter.Insert(nazwa, numer, null, null, interwal, file, filenav, false);
                                    }
                                    else
                                    {
                                        rinexTableAdapter.Insert(nazwa, numer, datapocz, datakonc, interwal, file,
                                            filenav, false);
                                    }
                                }
                                else
                                {
                                    if (datakonc == wzorzec)
                                    {
                                        rinexTableAdapter.Insert(nazwa, numer, datapocz, null, interwal, file, null,false);
                                    }
                                    if (datapocz == wzorzec)
                                    {
                                        rinexTableAdapter.Insert(nazwa, numer, null, datakonc, interwal, file, null, false);
                                    }
                                    if (datakonc == wzorzec && datapocz == wzorzec)
                                    {
                                        rinexTableAdapter.Insert(nazwa, numer, null, null, interwal, file, null, false);
                                    }
                                    else
                                    {
                                        rinexTableAdapter.Insert(nazwa, numer, datapocz, datakonc, interwal, file, null, false);
                                    }
                                }
                                break;
                            }
                        }
                    } 
                }
            }
            this.rinexTableAdapter.Fill(this.database1DataSet.Rinex);
        }
    }
}

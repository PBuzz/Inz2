using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    bool flag1 = false;

                    using (var sr = new StreamReader(file))
                    {
                        bool flag2 = false;
                        string poczatek="";
                        string koniec="";
                        var sciezka = Regex.Split(openFileDialog1.FileName, @"\\");
                        string nazwapliku = sciezka.Last();
                        var skladowe = nazwapliku.Split('-');
                        if (skladowe.Length == 2) 
                        {
                            poczatek = skladowe[0];
                            var drugi = skladowe[1].Split('.');
                            koniec = drugi[0];
                            flag2 = true;//potrzeban do wyboru insert w adapterze
                        }
                        string wiersz;
                        double DX=0, DY=0, DZ=0;
                        double sumasdx = 0, sumasdy = 0, sumasdz = 0, sumasdxy = 0, sumasdyz = 0, sumasdzx=0, sumaratio=0;
                        int i = 0;
                        while ((wiersz = sr.ReadLine()) != null)
                        {
                            toolStripProgressBar1.Increment(1);
                            if (flag1)
                            {

                                if (Convert.ToInt32(new string(wiersz.ToCharArray(71, 1))) == 1)
                                {
                                    wiersz = wiersz.Replace(".", ",");
                                    DX += Convert.ToDouble(new string(wiersz.ToCharArray(26, 15)));
                                    DY += Convert.ToDouble(new string(wiersz.ToCharArray(41, 15)));
                                    DZ += Convert.ToDouble(new string(wiersz.ToCharArray(56, 15)));
                                    sumasdx+= Convert.ToDouble(new string(wiersz.ToCharArray(79, 7)));
                                    sumasdy+= Convert.ToDouble(new string(wiersz.ToCharArray(88, 7)));
                                    sumasdz+= Convert.ToDouble(new string(wiersz.ToCharArray(97, 7)));
                                    sumasdxy+= Convert.ToDouble(new string(wiersz.ToCharArray(106, 7)));
                                    sumasdyz+= Convert.ToDouble(new string(wiersz.ToCharArray(115, 7)));
                                    sumasdzx+= Convert.ToDouble(new string(wiersz.ToCharArray(124, 7)));
                                    sumaratio+= Convert.ToDouble(new string(wiersz.ToCharArray(139, 5)));
                                    i++;
                                }

                            }

                            if (wiersz.Contains("%  GPST"))
                            {
                                flag1 = true;
                            }

                        }
                        DX = DX/i;
                        DY = DY/i;
                        DZ = DZ/i;
                        var sdx = Math.Sqrt(Math.Pow(sumasdx, 2)/i);
                        var sdy = Math.Sqrt(Math.Pow(sumasdy, 2) / i);
                        var sdz = Math.Sqrt(Math.Pow(sumasdz, 2) / i);
                        var sdxy = Math.Sqrt(Math.Pow(sumasdxy, 2) / i);
                        var sdyz = Math.Sqrt(Math.Pow(sumasdyz, 2) / i);
                        var sdzx = Math.Sqrt(Math.Pow(sumasdzx, 2) / i);
                        var ratio = sumaratio/i;
                        var index = wektoryBindingSource.Count;
                        if (flag2)
                        {
                            wektoryTableAdapter.Insert(poczatek, koniec, DX, DY, DZ,sdx,sdy,sdz,sdxy,sdyz,sdzx,ratio,file);
                        }
                        else
                        {
                            wektoryTableAdapter.Insert(null, null, DX, DY, DZ, sdx, sdy, sdz, sdxy, sdyz, sdzx, ratio, file);
                        }
                        wczytaj.Text = "Wczytaj";

                        break;
                    }
                }
                wektoryTableAdapter.Fill(database1DataSet.Wektory);
                toolStripProgressBar1.Maximum = 0;
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

                openFileDialog1.Multiselect = false;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    bool flag1 = false;
                    using (var sr = new StreamReader(openFileDialog1.FileName))
                    {
                        var sciezka = Regex.Split(openFileDialog1.FileName,@"\\");
                        string nazwapliku = sciezka.Last();
                        var skladowe = nazwapliku.Split('-');
                        if(skladowe.Length == 2)
                        {
                            var drugi = skladowe[1].Split('.' );//obcina rozszerzenie
                            wektoryDataGridView.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn2"].Value = skladowe[0];
                            wektoryDataGridView.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn3"].Value = drugi[0];
                        }
                        string wiersz;
                        double DX=0, DY=0, DZ = 0;
                        int i = 0;
                        while ((wiersz = sr.ReadLine()) != null)
                        {
                            if (flag1)
                            {
                                if (Convert.ToInt32(new string(wiersz.ToCharArray(71, 1))) == 1)
                                {
                                    wiersz = wiersz.Replace(".", ",");
                                     DX += Convert.ToDouble(new string(wiersz.ToCharArray(26, 15)));
                                     DY += Convert.ToDouble(new string(wiersz.ToCharArray(41, 15)));
                                     DZ += Convert.ToDouble(new string(wiersz.ToCharArray(56, 15)));
                                    i++;
                                }
                               

                            }

                            if (wiersz.Contains("%  GPST"))
                            {
                                flag1 = true;
                            }

                        }
                        var index = e.RowIndex;
                        if (i>0)
                        {
                            //wektoryTableAdapter.Insert(null, null, DX, DY, DZ);
                            wektoryDataGridView.Rows[index].Cells["DX"].Value = DX/i;
                            wektoryDataGridView.Rows[index].Cells["DY"].Value = DY/i;
                            wektoryDataGridView.Rows[index].Cells["DZ"].Value = DZ/i;
                            this.Validate();
                            this.wektoryBindingSource.EndEdit();
                            this.tableAdapterManager.UpdateAll(this.database1DataSet);
                        }
                    }
                    wektoryTableAdapter.Fill(database1DataSet.Wektory);
                }
            }
        }

        private void progressbar(object max)
        {
            var max2 = (int) max+2;
            toolStripProgressBar1.Maximum = max2;
        }
    }
}

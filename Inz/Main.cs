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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void wspołrzędneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form wspolrzedne = new FormWspolrzedne();
            wspolrzedne.Show();
            wspolrzedne.MdiParent = this;
        }

        private void długościToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form dlugosci = new FormDlugosci();
            dlugosci.Show();
            dlugosci.MdiParent = this;
        }
        private void tachimetrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //otwiera formularz tylko raz, jeśli już otwarty przenosi go na górę
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FormTachimetr))
                {
                    this.tachimetrTableAdapter.Fill(this.database1DataSet.Tachimetr);
                    form.Activate();
                    return;
                }
            }

            Form tachimetr = new FormTachimetr();
            tachimetr.MdiParent = this;
            tachimetr.Show();
            
        }

        private void kątyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form katy = new FormKaty();
            katy.Show();
            katy.MdiParent = this;
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var nazwaPliku = openFileDialog1.FileName;
                var rtBotworz = new FormOtworzRTB();
                rtBotworz.Show();
                rtBotworz.MdiParent = this;
                rtBotworz.richTextBox1.Lines = CzytajPlikTekst(nazwaPliku);
                var odczyt = new Odczyt();
                this.tachimetrTableAdapter.Fill(this.database1DataSet.Tachimetr);
                int id;
                if (tachimetrBindingSource.Count>0)
                { id = database1DataSet.Tachimetr.Max(wartosc => wartosc.Id) ; }
                else
                { id = 0;}
                odczyt.Odczytdobazy(nazwaPliku,id);
                tachimetrToolStripMenuItem_Click(sender, e);
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
                MessageBox.Show("Błąd "+e);
                return null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //otwiera formularz tylko raz, jeśli już otwarty przenosi go na górę
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FormTest))
                {
                    form.Activate();
                    return;
                }
            }

            Form test = new FormTest();
            test.MdiParent = this;
            test.Show();

        }


        private void ustawieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ustawienia = new FormUstawienia();
            ustawienia.MdiParent = this;
            ustawienia.Show();
        }

        private void azymutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form wczytajwektor = new FormWczytajWektor();
            wczytajwektor.MdiParent = this;
            wczytajwektor.Show();
        }

        private void test2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form testy2 = new FormTest2();
            testy2.MdiParent = this;
            testy2.Show();
        }
    }
}

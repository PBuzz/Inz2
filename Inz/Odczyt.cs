using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inz
{

    class Odczyt
    {
        class ListaKLasyczne
        {
            public string nazwaStanowiska { get; set; }
            public double hStanowiska { get; set; }
            public string nazwaCelu { get; set; }
           public double hCelu { get; set; }
           public double kierPoziomy { get; set; }
            public double kierPionowy { get; set; }
           public double odległosc { get; set; }
             public ListaKLasyczne (string nS, double hS,string nC,
            double hC,double kierPoz,double kierPion,double odl)
            {//Tymczasowa lista do przechowywania danych z odczytu
               this. nazwaStanowiska = nS;
                this.hStanowiska = hS;
                this.nazwaCelu = nC;
                this.hCelu = hC;
                this.kierPoziomy = kierPoz;
                this.kierPionowy = kierPion;
                this.odległosc = odl;
            }
        }
        public void Odczytdobazy(string plik, int idcount)
        {//Rozbija plik geodimeter
            string nazwaStanowiska = null;
            double hStanowiska = -99999;
            string nazwaCelu = null;
            double hCelu = -9999;
            double kierPoziomy = -999;
            double kierPionowy = -999;
            double odległosc = -999;
            List<ListaKLasyczne> listaObsKlas = new List<ListaKLasyczne>();

            using (var sr = new StreamReader(plik))
            {
                bool flag1=true;//flaga do stanowiska
                string linia;
                while ((linia = sr.ReadLine()) != null)
                { 
                var podzialLinii = linia.Split('=');



                    switch (podzialLinii[0])
                    {
                        case "2"://przypadek stanowiska
                        {
                            if (nazwaStanowiska != podzialLinii[1].Replace(".", ",") && nazwaStanowiska != null)
                            {
                                listaObsKlas.Add(new ListaKLasyczne(nazwaStanowiska, hStanowiska, nazwaCelu, hCelu,
                                    kierPoziomy, kierPionowy, odległosc));
                                flag1 = true;
                            }

                            nazwaStanowiska = podzialLinii[1].Replace(".", ",");
                            hStanowiska = 0;  //jeśli brak hstanowiska, to domyślne jest 0
                            break;
                        }
                        case "3"://wysokość stanowiska
                        {
                            hStanowiska = Convert.ToDouble(podzialLinii[1].Replace(".", ","));
                            break;
                        }
                        case "5"://nazwa celu
                        {
                            if (flag1 == false)
                            {
                                    listaObsKlas.Add(new ListaKLasyczne(nazwaStanowiska, hStanowiska, nazwaCelu, hCelu,
         kierPoziomy, kierPionowy, odległosc));
                                }
                            nazwaCelu = podzialLinii[1].Replace(".", ",");
                            flag1 = false;
                                hCelu = 0;//jeśli brak któregoś z elementu, wartość przyjmie -999
                                kierPoziomy = -999;
                                kierPionowy = -999;
                                odległosc = -999;
                                break;

                        }
                        case "6"://h celu
                        {
                            hCelu = Convert.ToDouble(podzialLinii[1].Replace(".", ","));
                            break;
                        }
                        case "7":// kierunek poziomy
                        {
                            kierPoziomy = Convert.ToDouble(podzialLinii[1].Replace(".", ","));
                            break;
                        }
                        case "8"://kierunek pionowy
                        {
                            kierPionowy = Convert.ToDouble(podzialLinii[1].Replace(".", ","));
                            break;
                        }
                        case "9"://odległość
                        {
                            odległosc = Convert.ToDouble(podzialLinii[1].Replace(".", ","));
                            break;
                        }

                    }

                }
                listaObsKlas.Add(new ListaKLasyczne(nazwaStanowiska, hStanowiska, nazwaCelu, hCelu,
kierPoziomy, kierPionowy, odległosc));//dodanie do listy
            }


            foreach (var row in listaObsKlas)
            {//dodanie do bazy danych z listy
                
                int id = listaObsKlas.IndexOf(row)+idcount+1;

                DodaniedoBazy(id, row.nazwaStanowiska,row.hStanowiska,row.nazwaCelu,row.hCelu,row.kierPoziomy,row.kierPionowy,row.odległosc);


            }
            
        }

        /*public string odczytlinii(StreamReader sr)
        {//odczyt znaczka
            var linia = sr.ReadLine();
            var podziallinii = linia.Split('=');
            return podziallinii[1];
        }*/

        public void DodaniedoBazy(int ID, string nazwaStanowiska,double hStanowiska,string nazwaCelu,
        double hCelu,double kierPoziomy,double kierPionowy,double odległosc)
        {//dodanie do bazy danych
            Database1DataSetTableAdapters.TachimetrTableAdapter tachimetrTableAdapter =
                new Database1DataSetTableAdapters.TachimetrTableAdapter();

            tachimetrTableAdapter.Insert(ID, nazwaStanowiska, nazwaCelu, kierPoziomy, kierPionowy, odległosc,hStanowiska,hCelu);
        }

    }


}

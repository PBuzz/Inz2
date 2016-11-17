using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inz
{
    class Wspprzyb
    {

        public double Azymut(double x1, double y1, double x2, double y2,  int wy)
        {//Oblicza azymuty , wy 0 - rad, 1 deg, 2 gra
            var dx = x2 - x1;
            var dy = y2 - y1;
            double wynik;
            wynik = Math.Atan2(dy, dx);
            if (wynik < 0)
                wynik = wynik + 2*Math.PI;

            switch (wy)
            {
                case 0:
                    return wynik;
                case 1:
                    return wynik*180/Math.PI;
                case 2:
                    return wynik*200/Math.PI;
            }
            return wynik;
        }

        void odczyt(DataSet dts)
        {
            //dts.Tables;
        }

        public Xyh Oblbiegunowe(double X, double Y, double H, double odl, double katPoziom, double azymut, double odczytStanowiska, double odczytPionowy, double i, double j)
        {
            double katzenitalny;
            if (odczytPionowy > 200)
                katzenitalny = odczytPionowy-200 ;
            else
            {
                katzenitalny = odczytPionowy;
            }
            katzenitalny = katzenitalny * Math.PI / 200;
            var azymutNowegoPktu = azymut - odczytStanowiska + katPoziom;
            var azymutNPrad = azymutNowegoPktu*Math.PI/200;
            var dx = odl*Math.Cos(azymutNPrad)*Math.Sin(katzenitalny);
            var dy = odl * Math.Sin(azymutNPrad) * Math.Sin(katzenitalny);
            var dh = odl*Math.Cos(katzenitalny) + i - j;
            Xyh wynik = new Xyh(X+dx,Y+dy,H+dh);
            return wynik;
        }

        public double redukcjaOdleglosci(double katpionowy, double odleglosc)
        {
            double katpionowy2;
            if (katpionowy > 200)
                katpionowy2 = katpionowy - 300;
            else
            {
                katpionowy2 = 100 - katpionowy;
           }
            katpionowy2 = katpionowy2*Math.PI/200;
            var d = odleglosc*Math.Cos(katpionowy2) - Math.Pow(odleglosc, 2)*Math.Sin(2*katpionowy2)/(2*6383000);
            return d;
        }

    }



    class Xyh
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double H { get; set; }

        public Xyh(double x, double y, double h)
        {
            X = x;
            Y = y;
            H = h;
        }
        public Xyh(double x, double y)
        {
            X = x;
            Y = y;
            
        }
    }
}

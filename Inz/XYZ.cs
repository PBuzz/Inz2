using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inz
{
    public class XYZ
    {
        public string Nazwa { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public XYZ(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public XYZ(double x, double y)
        {
            
            X = x;
            Y = y;

        }
        public XYZ(string nazwa, double x, double y)
        {
            Nazwa = nazwa;
            X = x;
            Y = y;

        }
        public XYZ(string nazwa, double x, double y, double z)
        {
            Nazwa = nazwa;
            X = x;
            Y = y;
            Z = z;
        }
    }

    public class LiniePointPoint
    {
        public string Poczatek { get; set; }
        public string Koniec { get; set; }

        public LiniePointPoint(string poczatek, string koniec)
        {
            Poczatek = poczatek;
            Koniec = koniec;
        }


    }

}

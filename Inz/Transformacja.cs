using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;

namespace Inz
{
   
    class Transformacja
    {
        public void Vincenty ( double fi1,double lambda1,double fi2, double lambda2,double a,double b, double f,out double azymut)
        {
            fi1 = fi1 * Math.PI / 180;
            fi2 = fi2 * Math.PI / 180;
            lambda1 = lambda1 * Math.PI / 180;
            lambda2 = lambda2 * Math.PI / 180;
            /* a=6378137;
             b=6356752.314;*/
            f = (a - b) / a;

            var e2prim = (Math.Pow(a, 2) - Math.Pow(b, 2)) / Math.Pow(b, 2);

            var U1 = Math.Atan(((1 - f) * Math.Tan(fi1)));
            var U2 = Math.Atan(((1 - f) * Math.Tan(fi2)));

            double lambda = lambda2 - lambda1;
            var L = lambda;
            double lambdapoprz = 0;
            double epsilon = 9999;
            var i = 1;
            double sinsigm = 0, cossigm = 0, sigm = 0, sinalfa, cosalfa2 = 0, cossigma2m = 0;
            while (epsilon > 0.000001)
            {
                sinsigm = Math.Sqrt(Math.Pow(Math.Cos(U2) * Math.Sin(lambda), 2) + (Math.Pow(Math.Cos(U1) * Math.Sin(U2) - Math.Sin(U1) * Math.Cos(U2) * Math.Cos(lambda), 2)));
                cossigm = Math.Sin(U1) * Math.Sin(U2) + Math.Cos(U1) * Math.Cos(U2) * Math.Cos(lambda);
                sigm = Math.Atan(sinsigm / cossigm);
                sinalfa = ((Math.Cos(U1) * Math.Cos(U2) * Math.Sin(lambda)) / sinsigm);
                cosalfa2 = 1 - Math.Pow(sinalfa, 2);
                cossigma2m = (Math.Cos(sigm) - ((2 * Math.Sin(U1) * Math.Sin(U2)) / (cosalfa2)));
                var C = (f / 16) * (cosalfa2) * (4 + f * (4 - (3 * cosalfa2)));
                lambda = L +
                         (1 - C) * f * sinalfa * (sigm + C * sinsigm * (cossigma2m + C * Math.Cos(sigm) * (-1 + (2 * Math.Pow((cossigma2m), 2)))));
                epsilon = Math.Abs(lambdapoprz - lambda);
                lambdapoprz = lambda;
                i++;
            }
            var u2 = (cosalfa2) * e2prim;
            var A = 1 + ((u2 / 16384) * (4096 + ((u2) * ((-768) + (u2) * (320 - 175 * (u2))))));
            var B = (u2 / 1024) * (256 + ((u2) * ((-128) + (u2) * (74 - 47 * (u2)))));
            var deltasigm = B * sinsigm * (cossigma2m + (1 / 4) * B * (Math.Cos(sigm) * (-1 + 2 * Math.Pow((cossigma2m), 2)) - (1 / 6) * B * cossigma2m * (-3 + 4 * Math.Pow((cossigma2m), 2))));
            var s = b * A * (sigm - deltasigm);
            var alfa1 =
                Math.Atan2((Math.Cos(U2) * Math.Sin(lambda)),
                          (Math.Cos(U1) * Math.Sin(U2) - Math.Sin(U1) * Math.Cos(U2) * Math.Cos(lambda)));

            if (alfa1 < 0)
                alfa1 = alfa1 + 2 * Math.PI;
            azymut = alfa1 * 200 / Math.PI;
            var alfa2 =
                Math.Atan2((Math.Cos(U1) * Math.Sin(lambda)) ,
                          (-Math.Sin(U1) * Math.Cos(U2) + Math.Cos(U1) * Math.Sin(U2) * Math.Cos(lambda)));
            if (alfa2 < 0)
                alfa2 = alfa2 + 2 * Math.PI;
            double wynik=(alfa1+alfa2)/2;

            azymut = wynik * 200 / Math.PI;

        }

        public void Hirvonen (double X, double Y, double Z,double a, double b, out  double fist, out double lambdast, out double h)
        {
            double omega = 100000;
            var epsilon = 0.000001 * Math.PI / 180;
            double lambda; 
            var e2 = (Math.Pow(a, 2) - Math.Pow(b, 2))/Math.Pow(a, 2);
            var p = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            var fi = Math.Atan((Z / p) * (1 / (1 - e2)));
            var N = a / Math.Sqrt(1 - e2 * Math.Pow(Math.Sin(fi), 2));
            var H = p / Math.Cos(fi) - N;
            double fi2;
            while (omega > epsilon)
            {
                fi2 = Math.Atan((Z / p) * (1 / (1 - e2 * (N / (N + H)))));
                N = a / Math.Sqrt(1 - e2 * Math.Pow(Math.Sin(fi2), 2));
                H = p / Math.Cos(fi2) - N;
                omega = Math.Abs(Math.Abs(fi) - Math.Abs(fi2));
                
                fi = fi2;
            }
            H = (p / Math.Cos(fi)) - N;
            fist = fi * 180 / Math.PI;
             lambda = Math.Atan2(Y , X) ;
            if (lambda < 0)
                lambda = lambda + 2 * Math.PI;
            lambdast=lambda * 180 / Math.PI;
            h = H;
           
            // kontrola
            var Xk = (N + H) * Math.Cos(fi) * Math.Cos(lambda);
            var Yk = (N + H) * Math.Cos(fi) * Math.Sin(lambda);
            var Zk = (N * (1 - e2) + H) * Math.Sin(fi);


            }

        public void odczytBL(double B, double L, out double ksi, out double eta)
        {

            {
                try
                {
                    /*
                     *siatka punktów 
                      =====7===8===x=
                      ======gora=====
                      11===4===5===6=
                      lewo===p===prawo
                      12===1===2===3=
                      ======dol======
                      =====13==14====
                      składowe odchylen dla punktów 1,2,5,4
                      interpolacja biliniowa dla pkt p na podstawie 1,2,4,5
                      */

                    double dzeta1 = 0, dzeta2 = 0, dzeta3 = 0;
                    double dzeta4 = 0, dzeta5 = 0, dzeta6 = 0;
                    double dzeta7 = 0, dzeta8 = 0, dzeta11 = 0;
                    double dzeta12 = 0, dzeta13 = 0, dzeta14 = 0;


                    var b1 = Math.Floor(B*100)/100;
                    var l1 = Math.Floor(L*100)/100;
                    b1 = Math.Round(b1, 2, MidpointRounding.AwayFromZero);
                    l1 = Math.Round(l1, 2, MidpointRounding.AwayFromZero);
                    var b2 = b1;
                    var l2 = Math.Round(l1 + 0.01, 2, MidpointRounding.AwayFromZero);
                    var b3 = b1;
                    var l3 = Math.Round(l1 + 0.02, 2, MidpointRounding.AwayFromZero);
                    var b4 = Math.Round(b1 + 0.01, 2, MidpointRounding.AwayFromZero);
                    var l4 = l1;
                    var b5 = b4;
                    var l5 = l2;
                    var b6 = b4;
                    var l6 = l3;
                    var b7 = Math.Round(b1 + 0.02, 2, MidpointRounding.AwayFromZero);
                    var l7 = l1;
                    var b8 = b7;
                    var l8 = l2;
                    var b11 = b4;
                    var l11 = Math.Round(l1 - 0.01, 2, MidpointRounding.AwayFromZero);
                    var b12 = b1;
                    var l12 = l11;
                    var b13 = Math.Round(b1 - 0.01, 2, MidpointRounding.AwayFromZero);
                    var l13 = l1;
                    var b14 = b13;
                    var l14 = l2;
                    var bdol = B - 0.01;
                    var bgora = B + 0.01;
                    var lLewo = L - 0.01;
                    var lPrawo = L + 0.01;


                    double bwynik = 0, lwynik = 0;
                    using (var sr = new StreamReader(Properties.Settings.Default.sciezkageoidy))
                    {
                        string wiersz;
                        while ((wiersz = sr.ReadLine()) != null)
                        {
                            wiersz = wiersz.Replace('.', ',');
                            string[] podzial = wiersz.Split('\t');

                            try
                            {
                                bwynik = Convert.ToDouble(podzial[0]);
                                lwynik = Convert.ToDouble(podzial[1]);
                            }

                            catch (Exception e)
                            {
                            }

                            if ((bwynik.Equals(b1) && lwynik.Equals(l1)))
                            {
                                dzeta1 = Convert.ToDouble(podzial[2]);
                            }

                            if ((bwynik == b2 && lwynik == l2))
                            {
                                dzeta2 = Convert.ToDouble(podzial[2]);
                            }
                            if ((bwynik == b3 && lwynik == l3))
                            {
                                dzeta3 = Convert.ToDouble(podzial[2]);
                            }
                            if ((bwynik == b4 && lwynik == l4))
                            {
                                dzeta4 = Convert.ToDouble(podzial[2]);
                            }
                            if ((bwynik == b5 && lwynik == l5))
                            {
                                dzeta5 = Convert.ToDouble(podzial[2]);
                            }
                            if ((bwynik == b6 && lwynik == l6))
                            {
                                dzeta6 = Convert.ToDouble(podzial[2]);
                            }
                            if ((bwynik == b7 && lwynik == l7))
                            {
                                dzeta7 = Convert.ToDouble(podzial[2]);
                            }
                            if ((bwynik == b8 && lwynik == l8))
                            {
                                dzeta8 = Convert.ToDouble(podzial[2]);
                            }
                            if ((bwynik == b11 && lwynik == l11))
                            {
                                dzeta11 = Convert.ToDouble(podzial[2]);
                            }
                            if ((bwynik == b12 && lwynik == l12))
                            {
                                dzeta12 = Convert.ToDouble(podzial[2]);
                            }
                            if ((bwynik == b13 && lwynik == l13))
                            {
                                dzeta13 = Convert.ToDouble(podzial[2]);
                            }
                            if ((bwynik == b14 && lwynik == l14))
                            {
                                dzeta14 = Convert.ToDouble(podzial[2]);
                            }

                        }

                    }
                    var ro = 180*60*60/Math.PI;
                    double x1,
                        x2,
                        x3,
                        y1,
                        y2,
                        y3,
                        x4,
                        y4,
                        x5,
                        y5,
                        x6,
                        y6,
                        x7,
                        y7,
                        x8,
                        y8,
                        xBL,
                        yBL,
                        xBL1,
                        yBL1,
                        xBL2,
                        yBL2,
                        xB1L,
                        yB1L,
                        xB4L,
                        yB4L;



                    GaussKruger1(b1, l1, L, out x1, out y1);
                    GaussKruger1(b2, l2, L, out x2, out y2);
                    GaussKruger1(b3, l3, L, out x3, out y3);
                    GaussKruger1(b4, l4, L, out x4, out y4);
                    GaussKruger1(b5, l5, L, out x5, out y5);
                    GaussKruger1(b6, l6, L, out x6, out y6);
                    GaussKruger1(b7, l7, L, out x7, out y7);
                    GaussKruger1(b8, l8, L, out x8, out y8);
                    GaussKruger1(B, L, L, out xBL, out yBL);
                    GaussKruger1(B, l1, L, out xBL1, out yBL1);
                    GaussKruger1(B, l2, L, out xBL2, out yBL2);
                    GaussKruger1(b1, L, L, out xB1L, out yB1L);
                    GaussKruger1(b4, L, L, out xB4L, out yB4L);

                    var d12 = odleglosc(x1, y1, x2, y2);
                    var d23 = odleglosc(x2, y2, x3, y3);
                    var d14 = odleglosc(x1, y1, x4, y4);
                    var d25 = odleglosc(x2, y2, x5, y5);
                    //var d36 = odleglosc(x3, y3, x6, y6);
                    var d45 = odleglosc(x4, y4, x5, y5);
                    var d56 = odleglosc(x5, y5, x6, y6);
                    var d47 = odleglosc(x4, y4, x7, y7);
                    var d58 = odleglosc(x5, y5, x8, y8);



                    /*
                                        var u = (B - b1)/0.01;
                                        var v= (L-l1)/0.01;
                                        var _v = 1 - v;
                                        var _u = 1 - u;
                                        var dzetaBl = dzeta1*_u*_v + dzeta4*u*_v + dzeta5*u*v + dzeta2*_u*v;
                                      */
                    double xP, yP, xGora, yGora, xDol, yDol, yLewo, yPrawo, xLewo, xPrawo;
                    GaussKruger1(B, L, L, out xP, out yP);
                    GaussKruger1(bgora, L, L, out xGora, out yGora);
                    GaussKruger1(bdol, L, L, out xDol, out yDol);
                    GaussKruger1(B, lLewo, L, out xLewo, out yLewo);
                    GaussKruger1(B, lPrawo, L, out xPrawo, out yPrawo);


                    var dLewo = odleglosc(xP, yP, xLewo, yLewo);
                    var dPrawo = odleglosc(xP, yP, xPrawo, yPrawo);
                    var dDol = odleglosc(xP, yP, xDol, yDol);
                    var dGora = odleglosc(xP, yP, xGora, yGora);

                    var dzetaPkt = interpolacjaDzeta(B, L, b1, l1, dzeta1, dzeta4, dzeta5, dzeta2);
                    var dzetalewo = interpolacjaDzeta(B, lLewo, b12, l12, dzeta12, dzeta11, dzeta4, dzeta1);
                    var dzetaprawo = interpolacjaDzeta(B, lPrawo, b2, l2, dzeta2, dzeta5, dzeta6, dzeta3);
                    var dzetagora = interpolacjaDzeta(bgora, L, b4, l4, dzeta4, dzeta7, dzeta8, dzeta5);
                    var dzetadol = interpolacjaDzeta(bdol, L, b13, l13, dzeta13, dzeta1, dzeta2, dzeta14);

                    var ksiwdol = (dzetaPkt - dzetadol)/dDol*ro;
                    var ksiwgore = (dzetagora - dzetaPkt)/dGora*ro;
                    ksi = -(ksiwgore + ksiwdol)/2;
                    var etawprawo = (dzetaprawo - dzetaPkt)/dPrawo*ro;
                    var etawlewo = (dzetaPkt - dzetalewo)/dLewo*ro;
                    eta = -(etawprawo + etawlewo)/2;



                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    throw;
                }

            }
        }




        private double interpolacjaDzeta(double B, double L, double b1, double l1, double dzeta1, double dzeta4, double dzeta5, double dzeta2)
        {
            var u = (B - b1) / 0.01;
            var v = (L - l1) / 0.01;
            var _v = 1 - v;
            var _u = 1 - u;
            var dzetaBl = dzeta1 * _u * _v + dzeta4 * u * _v + dzeta5 * u * v + dzeta2 * _u * v;
            return dzetaBl;
        }
        private double odleglosc(double x1, double y1, double x2, double y2)
        {
            var dx = x2 - x1;
            var dy = y2 - y1;
            var wynik = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
            return wynik;
        }

        public void GaussKruger1(double fi, double lambda, double poludnik, out double x, out double y)
        {
            fi = fi * Math.PI / 180;
            lambda = lambda * Math.PI / 180;
            var a = 6378137;
            var f = 1 / 298.257222101;
            var e2 = 2 * f - Math.Pow(f, 2);
            var e2prim = (e2) / (1 - e2);
            var N = a / Math.Sqrt(1 - e2 * Math.Pow(Math.Sin(fi), 2));

            var lambda0 = poludnik * Math.PI / 180;
            var e4 = Math.Pow(e2, 2);
            var e6 = Math.Pow(e2, 3);
            var t = Math.Tan(fi);
            var eta = e2prim * Math.Pow(Math.Cos(fi), 2);
            var l = lambda - lambda0;
            var A0 = 1 - e2 / 4 - (3 * e4) / 64 - (5 * e6) / 256;
            var A2 = (3 / 8) * (e2 + ((e4) / 4) + (15 * e6) / 128);
            var A4 = (15 / 256) * (e4 + (3 * e6) / 4);
            var A6 = 35 * e6 / 3072;

            var sigma = a * (A0 * fi - A2 * Math.Sin(2 * fi) + A4 * Math.Sin(4 * fi) - A6 * Math.Sin(6 * fi));
            x = sigma +
               (Math.Pow(l, 2) / 2) * N * Math.Sin(fi) * Math.Cos(fi) *
               (1 + (Math.Pow(l, 2) / 12) * (Math.Pow(Math.Cos(fi), 2)) * (5 - Math.Pow(t, 2) + 9 * eta + 4 * Math.Pow(eta, 2)) +
                (Math.Pow(l, 4) / 360) * (Math.Pow(Math.Cos(fi), 4)) * (61 - 58 * Math.Pow(t, 2) + Math.Pow(t, 4) + 270 * eta - 330 * eta * Math.Pow(t, 2)));

            y = l * N * (Math.Cos(fi)) *
               (1 + (Math.Pow(l, 2) / 6) * (Math.Pow(Math.Cos(fi), 2)) * (1 - Math.Pow(t, 2) + eta) +
                (Math.Pow(l, 4) / 120) * (Math.Pow(Math.Cos(fi), 4)) * (5 - 18 * Math.Pow(t, 2) + Math.Pow(t, 4) + 14 * eta - 58 * eta * Math.Pow(t, 2)));


        }

    }
}

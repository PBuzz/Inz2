using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;

namespace Inz
{
   
    class Transformacja
    {
        public void Vincenty ( double fi1,double lambda1,double fi2, double lambda2,double a,double b, double f)
        {
            
           /* a=6378137;
            b=6356752.314;
            f=(a-b)/a;*/

            var e2prim=(Math.Pow(a ,2)- Math.Pow(b ,2))/ Math.Pow(b ,2);

            var U1 = Math.Atan(((1 - f)*Math.Tan(fi1)));
            var U2 = Math.Atan(((1 - f) * Math.Tan(fi2)));
            
           var lambda=lambda2-lambda1;
            var L=lambda;
            double lambdapoprz=0;
            double epsilon=9999;
            var i=1;
            double sinsigm=0, cossigm=0, sigm=0, sinalfa, cosalfa2=0, cossigma2m=0;
            while (epsilon > 0.000001)
            {
                sinsigm = Math.Sqrt(Math.Pow(Math.Cos(U2)*Math.Sin(lambda) , 2) + (Math.Pow(Math.Cos(U1)* Math.Sin(U2) - Math.Sin(U1)* Math.Cos(U2)* Math.Cos(lambda) , 2)));
                cossigm = Math.Sin(U1)* Math.Sin(U2) + Math.Cos(U1)* Math.Cos(U2)* Math.Cos(lambda);
                sigm = Math.Atan(sinsigm/cossigm);
                sinalfa = ((Math.Cos(U1)* Math.Cos(U2)*Math.Sin(lambda))/sinsigm);
               cosalfa2 = 1 - Math.Pow(sinalfa , 2);
                cossigma2m = (Math.Cos(sigm) - ((2*Math.Sin(U1)*Math.Sin(U2))/(cosalfa2)));
                var C = (f/16)*(cosalfa2)*(4 + f*(4 - (3*cosalfa2)));
                lambda = L +
                         (1 - C)*f*sinalfa*(sigm + C*sinsigm*(cossigma2m + C*Math.Cos(sigm)*(-1 + (2*Math.Pow((cossigma2m) , 2)))));
                epsilon = Math.Abs (lambdapoprz - lambda);
                lambdapoprz = lambda;
                i ++;
            }
            var u2=(cosalfa2)*e2prim;
            var A=1+((u2/16384)*(4096+((u2)*((-768)+(u2)*(320-175*(u2))))));
            var B=(u2/1024)*(256+((u2)*((-128)+(u2)*(74-47*(u2)))));
            var deltasigm=B*sinsigm*(cossigma2m+(1/4)*B*(Math.Cos(sigm)*(-1+2* Math.Pow((cossigma2m),2))-(1/6)*B*cossigma2m*(-3+4*Math.Pow((cossigma2m),2))));
            var s=b*A*(sigm-deltasigm);
            var alfa1 =
                Math.Atan((Math.Cos(U2)*Math.Sin(lambda))/
                          (Math.Cos(U1)*Math.Sin(U2) - Math.Sin(U1)*Math.Cos(U2)*Math.Cos(lambda))) + Math.PI;
            var alfa2 =
                Math.Atan((Math.Cos(U1)*Math.Sin(lambda))/
                          (-Math.Sin(U1)*Math.Cos(U2) + Math.Cos(U1)*Math.Sin(U2)*Math.Cos(lambda)));

            alfa2=alfa2*180/Math.PI;
           
        }
        public void Hirvonen (double X, double Y, double Z,double a, double b, out  double fist, out double lambda, out double h)
        {
            double omega = 100000;
            var epsilon = 0.000001 * Math.PI / 180;

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
            lambda=lambda * 180 / Math.PI;
            h = H;
           
            // kontrola
            var Xk = (N + H) * Math.Cos(fi) * Math.Cos(lambda);
            var Yk = (N + H) * Math.Cos(fi) * Math.Sin(lambda);
            var Zk = (N * (1 - e2) + H) * Math.Sin(fi);


            }

    }
}

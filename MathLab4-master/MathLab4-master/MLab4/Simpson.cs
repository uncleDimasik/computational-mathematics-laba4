using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLab4
{
    class Simpson
    {
       public bool isCorrectByRunge(double Ihi, double Ih2i, double epsilon)
        {
            return (Math.Abs(Ihi - Ih2i) / 15d) < epsilon;
        }

        public double Simpson_(Func<double, double> f, double a, double b, int n)
        {
            var h = (b - a) / n;
            var sum1 = 0d;
            var sum2 = 0d;
            for (var k = 1; k <= n; k++)
            {
                var xk = a + k * h;
                if (k <= n - 1)
                {
                    sum1 += f(xk);
                }

                var xk_1 = a + (k - 1) * h;
                sum2 += f((xk + xk_1) / 2);
            }

            var result = h / 3d * (1d / 2d * f(a) + sum1 + 2 * sum2 + 1d / 2d * f(b));
            return result;
        }
    }
}

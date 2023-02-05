using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MLab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var a = 0;
            var b = Math.PI;
            var sepsNumber = 4;
            var eps = 0.001;
            List<double> ys = new List<double>();
            InitializeComponent();
            Simpson s = new Simpson();
            double f(double dx) => dx * Math.Sin(dx) * Math.Cos(dx);

            while (true)
            {
                double res = s.Simpson_(f, a, b, sepsNumber);
                double res1 = s.Simpson_(f, a, b, sepsNumber / 2);

                if (s.isCorrectByRunge(res, res1, eps))
                {
                    label2.Text = res.ToString();
                    label4.Text = sepsNumber.ToString();
                    label6.Text = ((b - a) / sepsNumber).ToString();

                    break;
                }
                sepsNumber += 1;

            }
            List<double> xs = new List<double>();
            for (var k = 0; k <= sepsNumber; k++)
            {
                var h = (b - a) / sepsNumber;
                var xk = a + k * h;
                xs.Add(xk);
            }
    
            for (int i = 0; i < xs.Count; i++)
            {
                ys.Add(xs[i] * Math.Sin(xs[i]) * Math.Cos(xs[i]));
                formsPlot1.Plot.AddVerticalLine(xs[i], Color.Red, 1, ScottPlot.LineStyle.Solid);
            }
            formsPlot1.Plot.PlotScatter(xs.ToArray(), ys: ys.ToArray(), color: Color.Blue, markerSize: 5, label: "interpolation");

            formsPlot1.Refresh();
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

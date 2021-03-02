using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurRate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        const double k = 0.02;

        private void btCalculate_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            double rate = (double)edRate.Value;
            int days = (int)edDays.Value;
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(0, rate);

            for (int day = 1; day <= days; day++)
            {
                rate = rate * (1 + k * (random.NextDouble() - 0.5));
                chart1.Series[0].Points.AddXY(day, rate);
            }
        }
    }
}

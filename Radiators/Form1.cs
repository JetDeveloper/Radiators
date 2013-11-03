using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Radiators
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public decimal getK2koef(decimal tm)
        {
            if (tm <= 10) 
            {
                return 1.4m;
            }
            else if (tm >= 150)
            {
                return 1.24m;
            }
            return 1.4m - (tm / 10) * 0.02m;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            decimal bodyTemp = ledTempSwitch.Value - ledPower.Value * ledTempRestSB.Value;
            decimal dTemp = ledPower.Value * ledTempRestBR.Value;
            decimal ts = 0.96m * (ledTempSwitch.Value - ledPower.Value*(ledTempRestSB.Value+ledTempRestBR.Value));
            decimal dTempRadEnv = ts - tempEnv.Value;
            decimal tm = (ts - tempEnv.Value) / 2;
            decimal ak = getK2koef(tm) * (decimal)Math.Pow((double)(tm / radLength.Value), 1 / 4.0);
            decimal al = 4;
            decimal a = ak + al;
            decimal Sp = ledPower.Value / (a * dTempRadEnv);
            // lambda from table!!! default - aluminium
            decimal lambda = 210;
            decimal S = Sp / numberEdge.Value;
            decimal Q = (decimal)Math.Pow((double)(3 * a * a * lambda * S), 1 / 3.0) / dTempRadEnv;
            decimal h_opt = (1 / a) * (Q / dTempRadEnv);
            decimal width = (1 / (a * lambda)) * (Q / dTempRadEnv) * (Q / dTempRadEnv) * (Q / dTempRadEnv);
            decimal b = (radLength.Value - width * radLength.Value) / (numberEdge.Value - 1);

            richTextBox1.Clear();
            richTextBox1.Text += "Оптимальная выстота ребра радиатора = " + h_opt + " м\n";
            richTextBox1.Text += "Оптимальная ширина ребра радиатора = " + width + " м\n";
            richTextBox1.Text += "Расстояние между ребрами = " + b + " м\n";
        }



    }
}

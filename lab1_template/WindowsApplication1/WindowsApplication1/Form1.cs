using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        Dictionary<CheckBox, Cell> field = new Dictionary<CheckBox, Cell>();

        public int money = 100;
        public int day = 1;

        public Form1()
        {
            InitializeComponent();
            foreach (CheckBox cb in panel1.Controls)
                field.Add(cb, new Cell());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (sender as CheckBox);
            if (cb.Checked) Plant(cb);
            else Harvest(cb);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (CheckBox cb in panel1.Controls)
                NextStep(cb);
            day++;
            dayBox.Text = day.ToString();

            Timer timerThing = (sender as Timer);

            

            timerThing.Interval = (int)(1000 / timeMultiplyer.Value);
        }

        private void Plant(CheckBox cb)
        {
            money -= 2;
            field[cb].Plant();
            UpdateBox(cb);
            moneyBox.Text = money.ToString();
        }

        private void Harvest(CheckBox cb)
        {
            if (field[cb].state == CellState.Immature)
                money += 3;                
            else if (field[cb].state == CellState.Mature)
                money += 5;
            else if (field[cb].state == CellState.Overgrow)
                money--;

            field[cb].Harvest();
                      

            moneyBox.Text = money.ToString();
            UpdateBox(cb);
            
        }

        private void NextStep(CheckBox cb)
        {
            field[cb].NextStep();
            UpdateBox(cb);
        }

        private void UpdateBox(CheckBox cb)
        {
            Color c = Color.White;
            switch (field[cb].state)
            {
                case CellState.Planted: c = Color.Gray;
                    break;
                case CellState.Green: c = Color.OliveDrab;
                    break;
                case CellState.Immature: c = Color.SandyBrown;
                    break;
                case CellState.Mature: c = Color.Firebrick;
                    break;
                case CellState.Overgrow: c = Color.Chocolate;
                    break;
            }
            cb.BackColor = c;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timeMultiplyer.Value = 1;
        }
    }
}
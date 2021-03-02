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
        public int count = 0;

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

        static Image CarrotImage = Image.FromFile(@"C:\Users\Kirill\Desktop\FarmCasino\carrot.png");
        static Image WheatImage = Image.FromFile(@"C:\Users\Kirill\Desktop\FarmCasino\wheatStack.png");
        Bitmap Carrot64 = new Bitmap(CarrotImage, new Size(50, 50));
        Bitmap Carrot256 = new Bitmap(CarrotImage, new Size(200, 200));
        Bitmap Wheat256 = new Bitmap(CarrotImage, new Size(200, 200));


        private void Harvest(CheckBox cb)
        {
            /*
            if (field[cb].state == CellState.Immature)
                money += 3;                
            else if (field[cb].state == CellState.Mature)
                money += 5;
            else if (field[cb].state == CellState.Overgrow)
                money--;
            */

            if (field[cb].state == CellState.Mature)
            {
                LastGet.InitialImage = null;
                LastGet.BackgroundImage = Wheat256;                
            }
            else if (field[cb].state == CellState.Carrot && count == 0)
            {
                LastGet.InitialImage = null;
                Score1.BackgroundImage = Carrot64;
                LastGet.BackgroundImage = Carrot256;
                count++;
                
            }
            else if (field[cb].state == CellState.Carrot && count == 1)
            {
                LastGet.InitialImage = null;
                Score2.BackgroundImage = Carrot64;
                LastGet.BackgroundImage = Carrot256;
                count++;
            }
            else if (field[cb].state == CellState.Carrot && count == 2)
            {
                LastGet.InitialImage = null;
                Score3.BackgroundImage = Carrot64;
                LastGet.BackgroundImage = Carrot256;
                count++;
            }

            if (count == 3)
            {
                money *= 10;
            }
            else 
                timer1.Stop();

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
            /*Color c = Color.White;
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
            }*/
            cb.BackgroundImage = Image.FromFile(@"C:\Users\Kirill\Desktop\FarmCasino\dirt.png");
            cb.Size = cb.BackgroundImage.Size;

            switch (field[cb].state)
            {
                case CellState.Planted:
                    cb.BackgroundImage = Image.FromFile(@"C:\Users\Kirill\Desktop\FarmCasino\planted.png");
                    cb.Size = cb.BackgroundImage.Size;
                    break;
                case CellState.Green:
                    cb.BackgroundImage = Image.FromFile(@"C:\Users\Kirill\Desktop\FarmCasino\green.png");
                    cb.Size = cb.BackgroundImage.Size;
                    break;
                case CellState.Immature:
                    cb.BackgroundImage = Image.FromFile(@"C:\Users\Kirill\Desktop\FarmCasino\rostok.png");
                    cb.Size = cb.BackgroundImage.Size;
                    break;
                case CellState.Mature:
                    cb.BackgroundImage = Image.FromFile(@"C:\Users\Kirill\Desktop\FarmCasino\wheat.png");
                    cb.Size = cb.BackgroundImage.Size;
                    break;
                case CellState.Carrot:
                    cb.BackgroundImage = Image.FromFile(@"C:\Users\Kirill\Desktop\FarmCasino\carrrot.png");
                    cb.Size = cb.BackgroundImage.Size;
                    break;
                case CellState.Overgrow:
                    cb.BackgroundImage = Image.FromFile(@"C:\Users\Kirill\Desktop\FarmCasino\tnt.png");
                    cb.Size = cb.BackgroundImage.Size;
                    break;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timeMultiplyer.Value = 1;
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
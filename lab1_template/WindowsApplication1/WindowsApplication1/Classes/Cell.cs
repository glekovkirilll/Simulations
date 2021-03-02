using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsApplication1
{
    class Cell
    {
        static Random random = new Random();
        public CellState state = CellState.Empty;
        public int progress = 0;
        public int chance = random.Next(17);
        public int carrot = 0;



        private const int prPlanted = 20;
        private const int prGreen = 100;
        private const int prImmature = 120;
        //private int prMature = random.Next(185, 231);
        private const int prMature = 145;

        public void Plant()
        {
            state = CellState.Planted;
            progress = 1;
        }

        public void Harvest()
        {                
            state = CellState.Empty;
            progress = 0;
        }

        public void NextStep()
        {
            if ((state != CellState.Empty) && (state != CellState.Overgrow))
            {
                progress++;
                if (progress < prPlanted) state = CellState.Planted;
                else if (progress < prGreen) state = CellState.Green;
                else if (progress < prImmature) state = CellState.Immature;                
                else if (progress < prMature && chance < 10 && carrot <= 2)
                {
                    state = CellState.Carrot;
                    carrot++;
                }
                else if (progress < prMature && chance >= 10) state = CellState.Mature;
                else state = CellState.Overgrow;
            }
        }
    }
}

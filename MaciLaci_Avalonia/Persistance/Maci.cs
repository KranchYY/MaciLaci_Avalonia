using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaciLaci_Avalonia.Persistance
{
    public class Maci
    {
        private int position_X;
        private int position_Y;
        private int kosarak;
        public Maci()
        {
            this.Position_X = 1;
            this.Position_Y = 1;
            kosarak = 0;
        }

        public int Position_X { get => position_X; set => position_X = value; }
        public int Position_Y { get => position_Y; set => position_Y = value; }
        public int Kosarak { get => kosarak; }
        public void Kosar_begyujt()
        {
            kosarak++;
        }
    }
}

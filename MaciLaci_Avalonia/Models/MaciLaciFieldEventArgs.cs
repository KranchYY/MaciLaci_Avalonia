using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaciLaci_Avalonia.Persistance;

namespace MaciLaci_Avalonia.Models
{
    public class MaciLaciFieldEventArgs : EventArgs
    {
        private int x;
        private int y;
        private ForestField forestField;

        public MaciLaciFieldEventArgs(int x, int y, ForestField forestField)
        {
            this.x = x;
            this.y = y;
            this.forestField = forestField;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public ForestField ForestField { get => forestField; set => forestField = value; }
    }

}

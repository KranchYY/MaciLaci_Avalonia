using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaciLaci_Avalonia.Models
{
    public class MaciLaciMovementEventArgs : EventArgs
    {
        private Dir dir;

        public MaciLaciMovementEventArgs(Dir dir)
        {
            this.Dir = dir;
        }

        public Dir Dir { get => dir; set => dir = value; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaciLaci_Avalonia.Models
{
    public class MaciLaciEventArgs : EventArgs
    {
        private int gameTime;
        private bool isWon;

        public MaciLaciEventArgs(int gameTime, bool isWon)
        {
            this.GameTime = gameTime;
            this.IsWon = isWon;
        }

        public int GameTime { get => gameTime; set => gameTime = value; }
        public bool IsWon { get => isWon; set => isWon = value; }
    }

}

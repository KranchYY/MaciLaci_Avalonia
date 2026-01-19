using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaciLaci_Avalonia.ViewModels
{
    public class GameField : ViewModelBase
    {
        private string text = string.Empty;
        public int X { get; set; }

        /// <summary>
        /// Függőleges koordináta lekérdezése, vagy beállítása.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Koordináta lekérdezése.
        /// </summary>
        public Tuple<int, int> XY
        {
            get { return new(X, Y); }
        }

        public string Text { get { return text; } set { if (text != value) { text = value; OnPropertyChanged(); } } }
    }

}

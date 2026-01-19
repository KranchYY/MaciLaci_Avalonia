using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaciLaci_Avalonia.Persistance
{
    public class Hunter
    {
        private bool direction;
        private int position_X;
        private int position_Y;
        private int way;
        public Hunter(int x, int y)
        {
            Random rnd = new Random();
            direction = Convert.ToBoolean(rnd.Next(0, 2));
            Position_X = x;
            Position_Y = y;
            Way = 1;
        }
        public void Move()
        {
            if (direction) position_X += Way;
            else position_Y += Way;
        }
        public bool Direction { get => direction; }
        public int Position_X { get => position_X; set => position_X = value; }
        public int Position_Y { get => position_Y; set => position_Y = value; }
        public int Way { get => way; set => way = value; }
    }

}

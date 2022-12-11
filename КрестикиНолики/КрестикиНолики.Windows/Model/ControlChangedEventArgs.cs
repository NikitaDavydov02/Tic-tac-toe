using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КрестикиНолики.Model
{
    class ControlChangedEventArgs:EventArgs
    {
        public int X;
        public int Y;
        public int Color;
        public ControlChangedEventArgs(int x, int y,int color)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }
}

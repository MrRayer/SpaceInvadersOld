using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class Location
    {
        public int x;
        public int y;

        public Location(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public void Move(int X, int Y)
        {
            x += X;
            y += Y;
        }
    }
}

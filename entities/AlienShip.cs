using System.Windows.Shapes;

namespace SpaceInvaders
{
    internal class AlienShip : Location
    {
        public Rectangle shape = new Rectangle { Tag = "Enemy", Height = 20, Width = 40};
        public AlienShip(int X, int Y) : base(X, Y) { }
    }
}

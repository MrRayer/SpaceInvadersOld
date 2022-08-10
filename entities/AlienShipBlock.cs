using System.Collections.Generic;

namespace SpaceInvaders
{
    internal static class AlienShipBlock
    {
        public static List<AlienShip> ASL = new List<AlienShip>();

        public static void AddShip(int X, int Y)
        {
            ASL.Add(new AlienShip(X,Y));
        }

        public static void Destroy(AlienShip ATD)
        {
        }

        public static void ColCheck(int BulletX, int BulletY)
        {
            foreach (AlienShip ship in ASL)
            {
                if (ship.x == BulletX && ship.y == BulletY)
                {
                    Destroy(ship);
                }
            }
        }
    }
}

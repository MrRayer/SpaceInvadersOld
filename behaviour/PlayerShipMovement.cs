using System.Windows.Controls;
using System.Windows.Shapes;

namespace SpaceInvaders
{
    internal class PlayerShipMovement
    {
        public static int moveAmmount = 15;
        public static int leftLimit = 20;
        public static int rightLimit = 800;
        public static void Move(Canvas myCanvas, bool moveLeft)
        {
            object player = myCanvas.FindName("Player");
            Rectangle Player = player as Rectangle;
            if (moveLeft)
            {
                if (Canvas.GetLeft(Player) > leftLimit)
                    {
                        Canvas.SetLeft(Player, Canvas.GetLeft(Player) - moveAmmount);
                    }
            }
            else
            {
                if (Canvas.GetLeft(Player) < rightLimit)
                {
                    Canvas.SetLeft(Player, Canvas.GetLeft(Player) + moveAmmount);
                }
            }
        }
    }
}

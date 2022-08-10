using System;
using System.Linq;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace SpaceInvaders
{
    internal class EnemyMovement
    {
        private static bool movementFlag = true;
        private static bool downFlag = false;
        public static int leftLimit = 30;
        public static int rightLimit = 820;
        public static int moveAmmount = 30;
        public static int downAmmount = 20;
        public static bool moving = true;
        public static int totalShips = 48;
        private static int shipsRN = 48;
        public async static void Update(Canvas myCanvas)
        {
            moving = false;
            await Task.Delay(shipsRN * 10);
            moving = true;
            int shipRNU = 0;
            if (downFlag)
            {
                foreach (Rectangle ship in myCanvas.Children.OfType<Rectangle>())
                {
                    if (Convert.ToString(ship.Tag) == "Enemy")
                    {
                        shipRNU++;
                        Canvas.SetTop(ship, Canvas.GetTop(ship) + downAmmount);
                        downFlag = false;
                        if (340 < Canvas.GetTop(ship))MainLoop.runGame = false;
                    }
                }
            }
            else
            {
                if (movementFlag)
                {
                    foreach (Rectangle ship in myCanvas.Children.OfType<Rectangle>())
                    {
                        if (Convert.ToString(ship.Tag) == "Enemy")
                        {
                            shipRNU++;
                            Canvas.SetLeft(ship, Canvas.GetLeft(ship) - moveAmmount);
                            if (Canvas.GetLeft(ship) < leftLimit)
                            {
                                movementFlag = false;
                                downFlag = true;
                                if (340 < Canvas.GetTop(ship)) MainLoop.runGame = false;
                            }
                        }
                    }
                }
                else
                {
                    foreach (Rectangle ship in myCanvas.Children.OfType<Rectangle>())
                    {
                        if (Convert.ToString(ship.Tag) == "Enemy")
                        {
                            shipRNU++;
                            Canvas.SetLeft(ship, Canvas.GetLeft(ship) + moveAmmount);
                            if (Canvas.GetLeft(ship) > rightLimit)
                            {
                                movementFlag = true;
                                downFlag = true;
                                if (340 < Canvas.GetTop(ship)) MainLoop.runGame = false;
                            }
                        }
                    }
                }
            }
            shipsRN = shipRNU;
            if (shipsRN == 0) MainLoop.wonGame = true;
        }
    }
}

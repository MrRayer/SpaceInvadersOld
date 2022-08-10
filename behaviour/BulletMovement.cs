using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SpaceInvaders
{
    internal class BulletMovement
    {
        public static int moveAmmount = 30;
        public static int topLimit = 0;
        public static void Update(Canvas myCanvas)
        {
            List<Rectangle> toDelete = new List<Rectangle>();
            foreach (Rectangle bullet in myCanvas.Children.OfType<Rectangle>())
            {

                if (Convert.ToString(bullet.Tag) == "PlayerBullet")
                {
                    if (Canvas.GetTop(bullet) - moveAmmount > topLimit)
                    {
                        Canvas.SetTop(bullet, Canvas.GetTop(bullet) - moveAmmount);
                    }
                    else
                    {
                        toDelete.Add(bullet);
                    }
                }
            }
            foreach (Rectangle x in toDelete)
            {
                myCanvas.Children.Remove(x);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Shapes;


namespace SpaceInvaders
{
    internal class BulletCollision
    {
        public static void CollCheck(Canvas myCanvas)
        {
            List<Rectangle> ESList = new List<Rectangle>();
            List<Rectangle> toDelete = new List<Rectangle>();
            foreach (Rectangle ship in myCanvas.Children.OfType<Rectangle>())
            {
                if (Convert.ToString(ship.Tag) == "Enemy") ESList.Add(ship);
            }
            foreach (Rectangle bullet in myCanvas.Children.OfType<Rectangle>())
            {
                if (Convert.ToString(bullet.Tag) == "PlayerBullet")
                {
                    double bLeft = Canvas.GetLeft(bullet);
                    double bRight = bLeft + PlayerBullet.bulletWidtht;
                    double bTop = Canvas.GetTop(bullet);
                    double bBottom = bTop + PlayerBullet.bulletHeight;
                    foreach (Rectangle enemy in ESList)
                    {
                        double eLeft = Canvas.GetLeft(enemy);
                        double eRight = eLeft + 40;
                        double eTop = Canvas.GetTop(enemy);
                        double eBottom = eTop + 20;
                        if (eTop <= bTop && bTop <= eBottom)
                        {
                            if (eLeft <= bLeft && bLeft <= eRight || eLeft <= bRight && bRight <= eRight)
                            {
                                toDelete.Add(bullet);
                                toDelete.Add(enemy);
                                AudioController.Explosion();
                            }
                        }
                    }
                }
            }
            foreach (Rectangle x in toDelete) myCanvas.Children.Remove(x);
        }
    }
}

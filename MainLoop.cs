using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

namespace SpaceInvaders
{
    internal static class MainLoop
    {
        public static int frameDelay = 17;
        public static bool runGame = true;
        public static bool wonGame = false;
        public static async void Update(Canvas myCanvas)
        {
            if (runGame)
            {
                if (wonGame)
                {
                    Rectangle overlay = new Rectangle { Height = 450, Width = 900, Fill = Brushes.Blue };
                    Canvas.SetTop(overlay, 0);
                    Canvas.SetLeft(overlay, 0);
                    myCanvas.Children.Add(overlay);
                    TextBlock endText = new TextBlock { TextWrapping = (TextWrapping)2, Text = "You Won", IsEnabled = false, Height = 110, Width = 310, FontSize = 72, HorizontalAlignment = (HorizontalAlignment)0, VerticalAlignment = (VerticalAlignment)1, TextAlignment = (TextAlignment)2 };
                    endText.FontFamily = new FontFamily("Comic Sans MS");
                    Canvas.SetTop(endText, 170);
                    Canvas.SetLeft(endText, 295);
                    myCanvas.Children.Add(endText);
                }
                else
                {
                    if (MainWindow.flagW) if (!PlayerBullet.cooldownFlag) PlayerBullet.Fire(myCanvas);
                    if (MainWindow.flagA) PlayerShipMovement.Move(myCanvas, true);
                    if (MainWindow.flagD) PlayerShipMovement.Move(myCanvas, false);
                    BulletMovement.Update(myCanvas);
                    if (EnemyMovement.moving) EnemyMovement.Update(myCanvas);
                    BulletCollision.CollCheck(myCanvas);
                    await Task.Delay(frameDelay);
                    Update(myCanvas);
                }
            }
            else
            {
                Rectangle overlay = new Rectangle { Height = 450, Width = 900, Fill = Brushes.Red };
                Canvas.SetTop(overlay, 0);
                Canvas.SetLeft(overlay, 0);
                myCanvas.Children.Add(overlay);
                TextBlock endText = new TextBlock { TextWrapping = (TextWrapping)2, Text = "You Lose", IsEnabled = false, Height = 110, Width = 310, FontSize = 72, HorizontalAlignment = (HorizontalAlignment)0, VerticalAlignment = (VerticalAlignment)1, TextAlignment = (TextAlignment)2};
                endText.FontFamily = new FontFamily("Comic Sans MS");
                Canvas.SetTop(endText, 170);
                Canvas.SetLeft(endText, 295);
                myCanvas.Children.Add(endText);
            }
        }
    }
}
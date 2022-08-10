using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace SpaceInvaders
{
    internal class PlayerBullet
    {
        public static int cooldown = 400;
        public static bool cooldownFlag = false;
        public static int bulletHeight = 10;
        public static int bulletWidtht = 10;
        public async static void Fire(Canvas myCanvas)
        {
            object player = myCanvas.FindName("Player");
            Rectangle Player = player as Rectangle;
            Rectangle shape = new Rectangle { Tag = "PlayerBullet", Height = bulletHeight, Width = bulletWidtht, Fill = Brushes.White, Stroke = Brushes.Blue };
            Canvas.SetLeft(shape, Canvas.GetLeft(Player) + 40);
            Canvas.SetTop(shape, Canvas.GetTop(Player) - 10);
            myCanvas.Children.Add(shape);
            AudioController.Shot();
            cooldownFlag = true;
            await Task.Delay(cooldown);
            cooldownFlag = false;
        }
    }
}

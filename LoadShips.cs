using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SpaceInvaders
{
    internal static class LoadShips
    {
        public static void LoadPlayerShip(Canvas myCanvas)
        {
            object player = myCanvas.FindName("Player");
            Rectangle Player = player as Rectangle;
            ImageBrush playerSkin = new ImageBrush();
            playerSkin.ImageSource = new BitmapImage(new Uri(@"C:\csPractice\SpaceInvaders\textures\dolar.jpg"));
            Player.Fill = playerSkin;
        }
        public static void LoadAlienSkins(Canvas myCanvas)
        {
            List<ImageBrush> skinList = new List<ImageBrush>();
            ImageBrush onePesos = new ImageBrush();
            ImageBrush twoPesos = new ImageBrush();
            ImageBrush fivePesos = new ImageBrush();
            onePesos.ImageSource = new BitmapImage(new Uri(@"C:\csPractice\SpaceInvaders\textures\100Pesos.jpg"));
            twoPesos.ImageSource = new BitmapImage(new Uri(@"C:\csPractice\SpaceInvaders\textures\200Pesos.jpg"));
            fivePesos.ImageSource = new BitmapImage(new Uri(@"C:\csPractice\SpaceInvaders\textures\500Pesos.jpg"));
            skinList.Add(onePesos);
            skinList.Add(twoPesos);
            skinList.Add(fivePesos);
            int x = 0;
            foreach (Rectangle ship in myCanvas.Children.OfType<Rectangle>())
            {
                if (Convert.ToString(ship.Tag) == "Enemy")
                {
                    ship.Fill = skinList[x];
                    if (x == 2) x = 0;
                    else x++;
                }
            }
        }

        public static void CreateList()
        {
            int shipsPerRow = 10;
            int rows = 5;
            int xStart = 860;
            int yStart = 10;
            int shipsPlaced = 0;
            int rowsPlaced = 0;
            bool oddFlag = false;
            while(rows > rowsPlaced)
            {
                if (oddFlag) shipsPerRow = 9;
                while (shipsPerRow > shipsPlaced)
                {
                    int x = xStart - 60 * shipsPlaced;
                    if (oddFlag) x -= 30;
                    int y = yStart + 30 * rowsPlaced;
                    AlienShipBlock.AddShip(y, x);
                    shipsPlaced++;
                }
                if (oddFlag) oddFlag = false;
                else oddFlag = true;
                shipsPerRow = 10;
                shipsPlaced = 0;
                rowsPlaced++;
            }
            //AlienShipBlock.AddShip(10, 860);
            //AlienShipBlock.AddShip(40, 830);
        }
        public static void Load(Canvas myCanvas)
        {
            foreach (AlienShip ship in AlienShipBlock.ASL)
            {
                Canvas.SetTop(ship.shape, ship.x);
                Canvas.SetLeft(ship.shape, ship.y);
                myCanvas.Children.Add(ship.shape);
            }
        }
    }
}

using System.Windows;
using System.Windows.Input;

namespace SpaceInvaders
{
    public partial class MainWindow : Window
    {
        public static bool flagW = false;
        public static bool flagA = false;
        public static bool flagD = false;
        public MainWindow()
        {
            InitializeComponent();
            Start();
        }
        public void Start()
        {
            LoadShips.CreateList();
            Keyboard.Focus(myCanvas);
            LoadShips.LoadPlayerShip(myCanvas);
            LoadShips.Load(myCanvas);
            LoadShips.LoadAlienSkins(myCanvas);
            MainLoop.Update(myCanvas);
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (MainLoop.runGame && !MainLoop.wonGame)
            {
                if (e.Key == Key.A) flagA = true;
                if (e.Key == Key.D) flagD = true;
                if (e.Key == Key.W) flagW = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (MainLoop.runGame && !MainLoop.wonGame)
            {
                if (e.Key == Key.A) flagA = false;
                if (e.Key == Key.D) flagD = false;
                if (e.Key == Key.W) flagW = false;
            }
        }
    }
}

using System.Windows;
using CanetisRadar2.Audio;

namespace CanetisRadar2.View
{
    public partial class RightScreen : Window
    {
        public RightScreen(ColoredSpeakers speakers)
        {
            Topmost = true;
            DataContext = speakers;
            SetupScreen();
            InitializeComponent();
        }
        
        private void SetupScreen()
        {
            Left = MainWindow.mainScreenWidth;
            Top = 0;
            Width = MainWindow.appWidth;
            Height = MainWindow.appHeight;
        }
    }
}
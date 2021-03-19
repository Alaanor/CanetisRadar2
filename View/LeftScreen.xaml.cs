namespace CanetisRadar2.View
{
    public partial class LeftScreen
    {
        public LeftScreen(ColoredSpeakers speakers)
        {
            Topmost = true;
            DataContext = speakers;
            SetupScreen();
            InitializeComponent();
        }
        
        private void SetupScreen()
        {
            Left = -MainWindow.appWidth;
            Top = 0;
            Width = MainWindow.appWidth;
            Height = MainWindow.appHeight;
        }
    }
}
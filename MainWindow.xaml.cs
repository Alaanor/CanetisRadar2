using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using CanetisRadar2.Audio;
using CanetisRadar2.View;

namespace CanetisRadar2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal const int mainScreenWidth = 1920;
        internal const int appWidth = 300;
        internal const int appHeight = 1080;

        private readonly Speakers _speakers;
        private readonly ColoredSpeakers _coloredSpeakers;

        public MainWindow()
        {
            InitializeComponent();

            _speakers = new Speakers();
            _coloredSpeakers = new ColoredSpeakers(_speakers);

            ShowScreen();
            StartMonitoring();
        }

        private void ShowScreen()
        {
            var leftScreen = new LeftScreen(_coloredSpeakers);
            leftScreen.Show();
            
            var rightScreen = new RightScreen(_coloredSpeakers);
            rightScreen.Show();
            
            WindowState = WindowState.Minimized;
        }

        private async void StartMonitoring()
        {
            // ReSharper disable once FunctionNeverReturns
            await Task.Run(() =>
            {
                for (;;)
                {
                    Thread.Sleep(200);
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                        (ThreadStart) delegate { _speakers.Update(); }
                    );
                }
            });
        }
    }
}
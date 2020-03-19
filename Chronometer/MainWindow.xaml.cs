using System;
using System.Windows;
using Services.Interfaces;
using Services.Implementation;

namespace Chronometer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly IChronometerService ChronoService;

        #region Public Methods

        public MainWindow()
        {
            InitializeComponent();

            ChronoService = ChronometerService.Create(RefreshUiEvent);
        }

        #endregion

        #region Private Methods

        // Method that will handle the event to refresh the value of the chronometer on screen.
        private void RefreshUiEvent(object sender, EventArgs e)
        {
            ChronoService.AddSecond();
            LabelChronometer.Content = ChronoService.Value;
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            ChronoService.Start();
        }

        private void ButtonPause_Click(object sender, RoutedEventArgs e)
        {
            ChronoService.Pause();
        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            ChronoService.Stop();
        }
        
        #endregion
    }
}

using System.Windows;

namespace TrainerENwords
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonStart_Clicked(object sender, RoutedEventArgs e)
        {
            var trainerPage = new TrainerPage();
            trainerPage.Show();
            Close();
        }
    }
}

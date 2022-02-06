using System;
using System.Windows;

namespace TrainerENwords
{
    /// <summary>
    /// Логика взаимодействия для EndPage.xaml
    /// </summary>
    public partial class EndPage : Window
    {
        public EndPage()
        {
            InitializeComponent();

            //считаем процент
            double proc = TrainerPage.result * 100 / 10;

            LabelResult.Content = "Правильных ответов - " + Convert.ToString(TrainerPage.result) + 
                ". Процент правильно переведенных слов - " + Convert.ToString(proc) + "%";
        }

        private void ButtonAgain_Click(object sender, RoutedEventArgs e)
        {
            var trainerPage = new TrainerPage();
            trainerPage.Show();
            Close();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            //завершаем
            Application.Current.Shutdown();
        }
    }
}
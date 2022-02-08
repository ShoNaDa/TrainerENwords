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

            //проверяем, если слова закончились, тогда только закончить
            if (TrainerPage.WordsWasUsed.Count == 200)
            {
                ButtonAgain.Visibility = Visibility.Hidden;
            }
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
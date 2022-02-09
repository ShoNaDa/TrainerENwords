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

            LabelResult.Content = "Правильных ответов - " + Convert.ToString(TrainerPage.result) + 
                ". Процент правильно переведенных слов - " + Convert.ToString(Procent(TrainerPage.result)) + "%";

            //проверяем, если слова закончились, тогда только закончить
            if (TrainerPage.WordsWasUsed.Count == 200)
            {
                ButtonAgain.Visibility = Visibility.Hidden;
            }
        }

        public double Procent(int res)
        {
            //считаем процент
            double proc = res * 100 / 10;

            return proc;
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
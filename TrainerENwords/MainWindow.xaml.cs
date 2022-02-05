using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace TrainerENwords
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //string
        string line;

        //mass
        string[] wordsEN = new string[10];
        string[] wordsRU = new string[10];

        //list
        List<string> RndWordsRU = new List<string>();

        //int
        int i = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonStart_Clicked(object sender, RoutedEventArgs e)
        {
            //if (File.Exists(@"C:\Users\gr692_bvv\source\repos\TrainerEN\TrainerEN\words.txt"))
            //{

            //}
            //else
            //{
            //    MessageBox.Show("nope");
            //}
            var trainerPage = new TrainerPage();
            trainerPage.Show();
            Close();
        }
    }
}

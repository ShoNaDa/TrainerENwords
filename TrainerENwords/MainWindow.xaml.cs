using System.IO;
using System.Windows;
using System.Windows.Input;

namespace TrainerENwords
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //string
        public static string pathWithoutNameTxt;

        public MainWindow()
        {
            InitializeComponent();

            //получили огромный путь (щас придется фигней заниматься, потому что там "bin\debug" лишнее)
            string fullPath = Path.GetFullPath("words.txt");

            int countOfSymbol = 0;

            //считаем - сколько слешей в пути
            foreach (char symbol in fullPath)
            {
                if (symbol == '\\')
                {
                    countOfSymbol++;
                }
            }

            //получаем почти нормальный путь к файлу, останется дописать только название
            for (int i = 0; i < countOfSymbol - 2; i++)
            {
                pathWithoutNameTxt += fullPath.Split('\\')[i] + "\\";
            }
        }

        private void ButtonStart_Clicked(object sender, RoutedEventArgs e)
        {
            var trainerPage = new TrainerPage();
            trainerPage.Show();
            Close();
        }
    }
}

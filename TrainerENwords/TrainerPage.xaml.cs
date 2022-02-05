using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace TrainerENwords
{
    /// <summary>
    /// Логика взаимодействия для TrainerPage.xaml
    /// </summary>
    public partial class TrainerPage : Window
    {
        //string
        string line;
        string textPath = @"C:\Users\gr692_bvv\source\repos\TrainerENwords\TrainerENwords\words.txt";

        //mass
        string[] wordsEN = new string[10];
        string[] wordsRU = new string[10];

        //list
        List<string> RndWordsRU = new List<string>();

        //int
        static int i = 0;
        public TrainerPage()
        {
            InitializeComponent();

            //меняем цвет текста TextBox и убираем текст
            if (NumberTextBox.IsFocused)
            {
                NumberTextBox.Foreground = Brushes.Black;
            }

            //если файл существует
            if (File.Exists(textPath))
            {
                //Если строки кончились, но массивы еще не заполнены, то вызываем функцию снова
                while (i != 10)
                {
                    CreateMassENRU();
                }

                //Выводим на экран 10 англ. слов
                ListViewEN.ItemsSource = wordsEN;

                //Рандомим порядок русс. слов
                while (RndWordsRU.Count != 10)
                {
                    var rnd = new Random();
                    string rndString = wordsRU[rnd.Next(0, 10)];

                    if (!RndWordsRU.Contains(rndString))
                    {
                        RndWordsRU.Add(rndString);
                    }
                }

                //Выводим на экран 10 русс. слов
                ListViewRU.ItemsSource = RndWordsRU;
            }
            else
            {
                MessageBox.Show("nope");
            }
        }

        private void CreateMassENRU()
        {
            using (StreamReader sr = new StreamReader(textPath, System.Text.Encoding.UTF8))
            {
                //Открываем первую строку файла
                line = sr.ReadLine();

                //Немного рандома
                Random rnd = new Random();

                //Рандом по первой строке
                if (rnd.Next(0, 2) != 0 && i == 0)
                {
                    wordsEN[0] = line.Split(' ')[0];
                    wordsRU[0] = line.Split(' ')[1];
                    i++;
                }

                //Рандом по остальным строкам файла
                while (line != null && i < 10)
                {
                    if (rnd.Next(0, 2) != 0)
                    {
                        wordsEN[i] = line.Split(' ')[0];
                        wordsRU[i] = line.Split(' ')[1];
                        i++;
                    }

                    //переходим на следующую строку
                    line = sr.ReadLine();
                }
            }
        }
    }
}

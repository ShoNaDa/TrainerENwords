using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        readonly string textPath = MainWindow.pathWithoutNameTxt + "words.txt";

        //mass
        readonly string[] wordsEN = new string[10];
        readonly string[] wordsRU = new string[10];

        //list
        readonly List<string> RndWordsRU = new List<string>();
        readonly List<short> Numbers = new List<short>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public static List<string> WordsWasUsed = new List<string>(); 

        //int
        int countOfString = 0;
        int countOfWords = 1;
        public static int result = 0;
        int countOfAnsweredWord = 1;

        //bool
        bool isReady = false;

        public TrainerPage()
        {
            InitializeComponent();

            //обнуляем результат на всякий случай
            result = 0;

            //если файл существует
            if (File.Exists(textPath))
            {
                //Если строки кончились, но массивы еще не заполнены, то вызываем функцию снова
                while (countOfString != 10)
                {
                    CreateMassENRU();
                }

                //Выводим на экран 10 англ. слов
                for (int i = 0; i < 10; i++)
                {
                    ListViewEN.Items.Add(new ListViewItem { Content = Convert.ToString(i + 1) + ". " + wordsEN[i]});
                }

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
                for (int i = 0; i < 10; i++)
                {
                    ListViewRU.Items.Add(new ListViewItem { Content = Convert.ToString(i + 1) + ". " + RndWordsRU[i] });
                }
            }

            //меняем цвет фона у первого элемента
            var selectedItem = (ListBoxItem)ListViewEN.Items[0];
            selectedItem.Background = new SolidColorBrush(Color.FromRgb(200, 97, 211));
        }

        public void CreateMassENRU()
        {
            using (StreamReader sr = new StreamReader(textPath, System.Text.Encoding.UTF8))
            {
                //Открываем первую строку файла
                line = sr.ReadLine();

                //Немного рандома
                Random rnd = new Random();

                //Рандом по строкам файла
                while (line != null && countOfString < 10)
                {
                    if (rnd.Next(0, 4) == 0)
                    {
                        bool isExist = false;

                        //проверяем - нет ли такого слова уже с массиве
                        foreach (string item in wordsEN)
                        {
                            if (line.Split(' ')[0] == item)
                            {
                                isExist = true;
                                break;
                            }
                        }

                        if (!isExist && !WordsWasUsed.Contains(line))
                        {
                            wordsEN[countOfString] = line.Split(' ')[0];
                            wordsRU[countOfString] = line.Split(' ')[1];

                            countOfString++;
                            WordsWasUsed.Add(line);
                        }
                    }

                    //переходим на следующую строку
                    line = sr.ReadLine();
                }
            }
        }

        public static bool IsNumber(string text, List<short> Numbers)
        {
            bool isNumber = false;

            foreach (int item in Numbers)
            {
                if (text == Convert.ToString(item))
                {
                    isNumber = true;
                }
            }

            return isNumber;
        }

        private void NumberTextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!isReady)
            {
                //меняем цвет текста TextBox и убираем текст
                NumberTextBox.Foreground = Brushes.Black;
                NumberTextBox.Text = string.Empty;

                //чтобы только один раз работало
                isReady = true;
            }
        }

        public static bool IsRight(string answer, string word)
        {
            if (word == answer)
            {
                return true;
            }
            else
            {
                return false;  
            }
        }

        public void ButtonAsk_Click(object sender, RoutedEventArgs e)
        {
            //проверяем вписал ли пользователь именно цифру от 1 до 10
            if (IsNumber(NumberTextBox.Text, Numbers))
            {
                //проверяем - правильно ли ответил пользователь
                if (IsRight(Convert.ToString(ListViewRU.Items[Convert.ToInt32(NumberTextBox.Text) - 1]).Split(':')[1].Split('.')[1].Trim(), wordsRU[countOfWords - 1]))
                {
                    if (countOfWords != 10)
                    {
                        MessageBox.Show("Правильно! Переходим к следующему слову");
                        countOfWords++;
                        result++;
                    }
                    else
                    {
                        MessageBox.Show("Правильно!");
                        result++;

                        var endPage = new EndPage();
                        endPage.Show();
                        Close();
                    }
                }
                else
                {
                    if (countOfWords != 10)
                    {
                        MessageBox.Show("Неправильно! Правильный ответ - " + wordsRU[countOfWords - 1]);
                        countOfWords++;
                    }
                    else
                    {
                        MessageBox.Show("Неправильно!");

                        var endPage = new EndPage();
                        endPage.Show();
                        Close();
                    }
                }

                //перекраска фона некст слова
                var selectedItem = (ListBoxItem)ListViewEN.Items[countOfAnsweredWord];
                selectedItem.Background = new SolidColorBrush(Color.FromRgb(200, 97, 211));

                //возвращаем фон предыдущего слова
                selectedItem = (ListBoxItem)ListViewEN.Items[countOfAnsweredWord - 1];
                selectedItem.Background = new SolidColorBrush(Color.FromRgb(255, 204, 204));

                if (countOfAnsweredWord != 9)
                {
                    countOfAnsweredWord++;
                }
            }
            else
            {
                MessageBox.Show("Выберите номер");
            }

            //Очистка TextBox
            NumberTextBox.Text = string.Empty;
        } 

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ButtonAsk_Click(sender, e);
            }
        }
    }
}
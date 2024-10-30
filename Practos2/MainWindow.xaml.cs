using Lib_4;
using Microsoft.Win32;
using System.Data.Common;
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibMas;

namespace Practos2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Сделала:Галкина Ирина ИСП-34 \nЗадание:Ввести n целых чисел. Вычислить для чисел > 0 функцию\r\nx\r\n. Результат\r\nобработки каждого числа вывести на экран.\r\n");
        }

        private void btPez_Click(object sender, RoutedEventArgs e)
        {
            bool boolDlinaMas = int.TryParse(tbDlinaMas.Text, out int dlinaMas);//Создаем переменную boolDlinaMas и метод TryParse пытается преоброзовать текст в число
                                                                                //и если это удается, то переменная boolDlinaMas принимает значение true. dlinaMas это выходной параметр 
            bool boolMaxMas = int.TryParse(tbMaxMas.Text, out int maxMas);//Создаем переменную boolMaxMas и метод TryParse пытается преоброзовать текст в число
                                                                          //и если это удается, то переменная boolMaxMas принимает значение true 
            if (boolDlinaMas == true && boolMaxMas == true)//Это условие, и если boolDlinaMas и boolMaxMas принимает значение true, то идет расчет.maxMas это выходной параметр
            {
                int dlina = Convert.ToInt32(dlinaMas);//Присваивается переменной dlina значение с dlinaMas 
                int max = Convert.ToInt32(maxMas);//Присваевается переменной max значение с MaxMas
                RandomMas.RndMas(out mas, dlina, max);//Вызываем библиотеку RandomMas и указываем метод для того что бы она заполнила массив рандомными числами
                RaschetMas.RasMas(out string raschetMas, mas);//Вызываем библиотеку RaschetMas и указываем метод для того чтобы расчитать корень каждой ячейки массива
                tbRez.Text = raschetMas;//Выводим в тексбокс(tbRez) переменнуб raschetMas
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        int[] mas;//Создается массив
        private void CoxMas_Click(object sender, RoutedEventArgs e)//Сохранение массива в файл
        {
            //Создаем и настраиваем элемент SaveFileDialog
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы *.*|*.*|Текстовый файл|*txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            //Открываем файл, при успехе работаем с файлом
            if (save.ShowDialog() == true)
            {
                //Создаем поток для работы с файлом и указываем ему имя файла
                StreamWriter file = new StreamWriter(save.FileName);
                //Записываем размер массива в файл
                file.WriteLine(mas.Length);
                //Записываем элементы массива в файл
                for (int i = 0; i < mas.Length; i++)
                {
                    file.WriteLine(mas[i]);
                }
                file.Close();
            }
        }

        private void OtkMas_Click(object sender, RoutedEventArgs e)//Открытие массива из файла
        {
            //Создаем и настраиваем элемент OpenFileDialog;
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы *.*|*.*|Текстовый файл|*txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";
            //Открываем диалоговое окно и при работаем с файлом 
            if (open.ShowDialog() == true)
            {
                //Создаем поток работы с файлом и указываем ему имя файлы
                StreamReader file = new StreamReader(open.FileName);
                //Читаем размер массива
                int len = Convert.ToInt32(file.ReadLine());
                mas = new int[len];
                //Считываем файлы с массива
                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = Convert.ToInt32(file.ReadLine());
                }
                file.Close();
                RaschetMas.RasMas(out string raschetMas, mas);//Вызываем библиотеку RaschetFile и в ней указываем метод RasMas для расчета корня
                tbRez.Text = raschetMas;//Вывод в тексбокс (tbRez) raschetMas 
            }
        }
        private void OchisMas_Click(object sender, RoutedEventArgs e)//Чистим массив
        {
            mas = null;
            tbRez.Text = "";
        }
    }
}
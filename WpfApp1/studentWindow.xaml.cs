using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class studentWindow : Window
    {
        //пусть от диска С, если указываю путь от проекта, то открывается какой-то дальний файл
        static string path = @"C:\Users\Alexandr\source\repos\WpfApp1\WpfApp1\TextFile1.txt";
        static int counter;

        public studentWindow()
        {
            InitializeComponent();

            //поиск числа, под которым будет следующий студент
            if(File.Exists(path))
                counter = Int32.Parse(File.ReadLines(path).Last().Split(' ')[0]) + 1;
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mv = new MainWindow();
            Hide();
            mv.Show();
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            //проверка на пустоту строки ввода
            if(!String.IsNullOrEmpty(inputBox.Text))
            {
                //если файла нет - создаем, если есть - дополняем
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        counter = 1;
                        sw.WriteLine(counter + " " + inputBox.Text);
                        counter++;
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(counter + " " + inputBox.Text);
                        counter++;
                    }
                }
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(File.Exists(path))
            {
                //записываем во временный файл все строки, кроме той, которая начинается с удаляемого номера
                string tempFile = System.IO.Path.GetTempFileName();

                var linesToKeep = File.ReadLines(path).Where(line => line.Split(' ')[0] != inputBox.Text);

                File.WriteAllLines(tempFile, linesToKeep);

                File.Delete(path);
                File.Move(tempFile, path);
            }
        }
    }
}

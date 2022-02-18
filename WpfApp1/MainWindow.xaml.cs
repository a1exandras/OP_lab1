using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
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

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void studentsButton_Click(object sender, RoutedEventArgs e)
        {
            studentWindow mv = new studentWindow();
            Hide();
            mv.Show();
        }

        private void meButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 mv = new Window1();
            Hide();
            mv.Show();
        }

        private void gameButton_Click(object sender, RoutedEventArgs e)
        {
            Window2 mv = new Window2();
            Hide();
            mv.Show();
        }

        private void calcButton_Click(object sender, RoutedEventArgs e)
        {
            Window3 mv = new Window3();
            Hide();
            mv.Show();
        }
    }
}

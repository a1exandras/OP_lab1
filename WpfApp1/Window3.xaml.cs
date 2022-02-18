using System;
using System.Data;
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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mv = new MainWindow();
            Hide();
            mv.Show();
        }

        private void inputButtonClicked(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            inputBox.Text += btn.Content.ToString();
        }

        private void equalsButton_Click(object sender, RoutedEventArgs e)
        {
            var res = new DataTable().Compute(inputBox.Text, null);

            inputBox.Text = res.ToString().Replace(',','.');

            if(inputBox.Text[inputBox.Text.Length - 1] == '0' && inputBox.Text[inputBox.Text.Length - 2] == '.')
            {
                for(int i = 0; i <= 1; i++)
                    inputBox.Text = inputBox.Text.Remove(inputBox.Text.Length - 1);
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            inputBox.Text = "";
        }

        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            inputBox.Text = inputBox.Text.Remove(inputBox.Text.Length - 1);
        }
    }
}

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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        public string currentPlayer = "X";
        public string[,] Board = new string[5,5];

        public Window2()
        {
            InitializeComponent();
        }

        private void userClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (!String.IsNullOrWhiteSpace(btn.Content?.ToString()))
                return;

            btn.Content = currentPlayer;
            var coordinates = btn.Tag.ToString().Split(',');
            Board[Int32.Parse(coordinates[0]), Int32.Parse(coordinates[1])] = currentPlayer;

            checkWin();

            switchPlayer();
        }
        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mv = new MainWindow();
            Hide();
            mv.Show();
        }

        private void restartButton_Click(object sender, RoutedEventArgs e)
        {
            winWindow.Visibility = Visibility.Collapsed;

            foreach(Button btn in playField.Children)
            {
                btn.Content = "";
            }

            for (int i = 0; i <= 4; i++)
                for (int j = 0; j <= 4; j++)
                    Board[i, j] = "";

            currentPlayer = "X";
        }

        private void switchPlayer()
        {
            if (currentPlayer == "X")
                currentPlayer = "O";
            else
                currentPlayer = "X";
        }

        private void checkWin()
        {
            for(int i = 0; i <=1; i++)
                for (int j = 0; j <= 4; j++)
                {
                    if(!String.IsNullOrWhiteSpace(Board[i, j]))
                        if (Board[i, j] == Board[i + 1, j] && Board[i, j] == Board[i + 2, j] && Board[i, j] == Board[i + 3, j])
                            playerWin(Board[i, j]);
                }

            for (int i = 0; i <= 4; i++)
                for (int j = 0; j <= 1; j++)
                {
                    if (!String.IsNullOrWhiteSpace(Board[i, j]))
                        if (Board[i, j] == Board[i, j + 1] && Board[i, j] == Board[i, j + 2] && Board[i, j] == Board[i, j + 3])
                            playerWin(Board[i, j]);
                }

            for (int i = 0; i <= 1; i++)
                for (int j = 0; j <= 1; j++)
                {
                    if (!String.IsNullOrWhiteSpace(Board[i, j]))
                        if (Board[i, j] == Board[i + 1, j + 1] && Board[i, j] == Board[i + 2, j + 2] && Board[i, j] == Board[i + 3, j + 3])
                            playerWin(Board[i, j]);
                }

            for (int i = 3; i <= 4; i++)
                for (int j = 0; j <= 1; j++)
                {
                    if (!String.IsNullOrWhiteSpace(Board[i, j]))
                        if (Board[i, j] == Board[i - 1, j + 1] && Board[i, j] == Board[i - 2, j + 2] && Board[i, j] == Board[i - 3, j + 3])
                            playerWin(Board[i, j]);
                }
        }

        private void playerWin(string player)
        {
            winWindow.Text = "Player " + player + " Wins!";
            winWindow.Visibility = Visibility.Visible;
        }
    }
}

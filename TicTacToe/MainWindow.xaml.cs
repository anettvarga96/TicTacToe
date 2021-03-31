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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool gameEnded;
        private Symbol[] symbols;
        private bool player1Turn;


        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        private void NewGame()
        {
            gameEnded = false;
            player1Turn = true;
            symbols = new Symbol[9];

            for (int i = 0; i < symbols.Length; i++)
            {
                symbols[i] = Symbol.Empty;
            }

            foreach (var item in Container.Children.Cast<Button>())
            {
                item.Content = string.Empty;
                item.Background = Brushes.AntiqueWhite;
                item.Foreground = Brushes.RosyBrown;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (gameEnded)
            {
                NewGame();
                return;
            }

            var button = (Button)sender;
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            if (symbols[index] != Symbol.Empty)
            {
                return;
            }

            symbols[index] = player1Turn ? Symbol.X : Symbol.O;

            button.Content = player1Turn ? Symbol.X : Symbol.O;

            player1Turn = player1Turn ? false : true;


            CheckForWinners();
        }

        private void CheckForWinners()
        {
            for (int i = 0; i < 7; i += 3)
            {
                if (symbols[i] != Symbol.Empty && symbols[i] == symbols[i + 1] && symbols[i + 1] == symbols[i + 2])
                {
                    gameEnded = true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (symbols[i] != Symbol.Empty && symbols[i] == symbols[i + 3] && symbols[i + 3] == symbols[i + 6])
                {
                    gameEnded = true;
                }
            }

            if (symbols[0] != Symbol.Empty && symbols[0] == symbols[4] && symbols[4] == symbols[8])
            {
                gameEnded = true;
            }

            if (symbols[2] != Symbol.Empty && symbols[2] == symbols[4] && symbols[4] == symbols[6])
            {
                gameEnded = true;
            }

            if (!symbols.Any(element => element == Symbol.Empty))
            {
                gameEnded = true;
            }
        }
    }
}

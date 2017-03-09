using System.Windows;
using System.Windows.Controls;


namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            L1.Content = $"Current player is {_currentPlayer}";
        }

        private string _currentPlayer = "X";

        private void GridClick(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;
            button.Content = _currentPlayer;
            switch (_currentPlayer)
            {
                case "X":
                    _currentPlayer = "O";
                    break;
                case "O":
                    _currentPlayer = "X";
                    break;
            }
            button.IsEnabled = false;
            L1.Content = $"Current player is {_currentPlayer}";
            ConditionsCheck();
        }

        private void ConditionsCheck()
        {
            /*Tl = top left      Tc = Top center      Tr = top right
              Ml = middle left   Mc = middle center   Mr = middle right
              Bl = bottom left   Bc = bottom center   Br = bottom right
            */
            if (Tl.Content as string != "" && Ml.Content as string != "" && Bl.Content as string != "" &&
                Tc.Content as string != "" && Mc.Content as string != "" && Bc.Content as string != "" &&
                Tr.Content as string != "" && Mr.Content as string != "" && Br.Content as string != "")
            {
                L1.Content = "Tied";
                WinnerFound();
            }
            if (Tl.Content as string == "X" && Tc.Content as string == "X" && Tr.Content as string == "X" ||
                Ml.Content as string == "X" && Mc.Content as string == "X" && Mr.Content as string == "X" ||
                Bl.Content as string == "X" && Bc.Content as string == "X" && Br.Content as string == "X" ||
                Tl.Content as string == "X" && Ml.Content as string == "X" && Bl.Content as string == "X" ||
                Tc.Content as string == "X" && Mc.Content as string == "X" && Bc.Content as string == "X" ||
                Tr.Content as string == "X" && Mr.Content as string == "X" && Br.Content as string == "X" ||
                Tl.Content as string == "X" && Mc.Content as string == "X" && Br.Content as string == "X" ||
                Bl.Content as string == "X" && Mc.Content as string == "X" && Tr.Content as string == "X")
            {
                L1.Content = "Player X wins";
                WinnerFound();
            }
            if (Tl.Content as string == "O" && Tc.Content as string == "O" && Tr.Content as string == "O" ||
                Ml.Content as string == "O" && Mc.Content as string == "O" && Mr.Content as string == "O" ||
                Bl.Content as string == "O" && Bc.Content as string == "O" && Br.Content as string == "O" ||
                Tl.Content as string == "O" && Ml.Content as string == "O" && Bl.Content as string == "O" ||
                Tc.Content as string == "O" && Mc.Content as string == "O" && Bc.Content as string == "O" ||
                Tr.Content as string == "O" && Mr.Content as string == "O" && Br.Content as string == "O" ||
                Tl.Content as string == "O" && Mc.Content as string == "O" && Br.Content as string == "O" ||
                Bl.Content as string == "O" && Mc.Content as string == "O" && Tr.Content as string == "O")
            {
                L1.Content = "Player O wins";
                WinnerFound();
            }
        }

        private void WinnerFound()
        {
            var buttons = new[] {Tl, Ml, Bl, Tc, Mc, Bc, Tr, Mr, Br};
            foreach (var button in buttons)
            {
                button.IsEnabled = false;
            }
        }

        private void ResetGame(object sender, RoutedEventArgs e)
        {
            var buttons = new[] {Tl, Ml, Bl, Tc, Mc, Bc, Tr, Mr, Br};
            foreach (var button in buttons)
            {
                button.IsEnabled = true;
                button.Content = "";
            }
            L1.Content = $"Current player is {_currentPlayer}";
        }
    }
}
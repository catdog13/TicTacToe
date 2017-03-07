using System;
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
            if (Tl.Content as String != "" && Ml.Content as String != "" && Bl.Content as String != "" &&
                Tc.Content as String != "" && Mc.Content as String != "" && Bc.Content as String != "" &&
                Tr.Content as String != "" && Mr.Content as String != "" && Br.Content as String != "")
            {
                L1.Content = "Tied";
                WinnerFound();
            }
            if (Tl.Content as String == "X" && Tc.Content as String == "X" && Tr.Content as String == "X" ||
                Ml.Content as String == "X" && Mc.Content as String == "X" && Mr.Content as String == "X" ||
                Bl.Content as String == "X" && Bc.Content as String == "X" && Br.Content as String == "X" ||
                Tl.Content as String == "X" && Ml.Content as String == "X" && Bl.Content as String == "X" ||
                Tc.Content as String == "X" && Mc.Content as String == "X" && Bc.Content as String == "X" ||
                Tr.Content as String == "X" && Mr.Content as String == "X" && Br.Content as String == "X" ||
                Tl.Content as String == "X" && Mc.Content as String == "X" && Br.Content as String == "X" ||
                Bl.Content as String == "X" && Mc.Content as String == "X" && Tr.Content as String == "X")
            {
                L1.Content = "Player X wins";
                WinnerFound();
            }
            if (Tl.Content as String == "O" && Tc.Content as String == "O" && Tr.Content as String == "O" ||
                Ml.Content as String == "O" && Mc.Content as String == "O" && Mr.Content as String == "O" ||
                Bl.Content as String == "O" && Bc.Content as String == "O" && Br.Content as String == "O" ||
                Tl.Content as String == "O" && Ml.Content as String == "O" && Bl.Content as String == "O" ||
                Tc.Content as String == "O" && Mc.Content as String == "O" && Bc.Content as String == "O" ||
                Tr.Content as String == "O" && Mr.Content as String == "O" && Br.Content as String == "O" ||
                Tl.Content as String == "O" && Mc.Content as String == "O" && Br.Content as String == "O" ||
                Bl.Content as String == "O" && Mc.Content as String == "O" && Tr.Content as String == "O")
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
                L1.Content = $"Current player is {_currentPlayer}";
            }
        }
    }
}
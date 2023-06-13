using System.Globalization;
using System.Windows.Controls;
using System.Windows;

namespace Rekenmachine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double temp = 0;
        string operation = "";
        string output = "";

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
            DivideBtn.Content = "\u00F7";
        }

        private void NumBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = ((Button)sender).Name;

            switch (name)
            {
                case "OneBtn":
                    AppendToOutput("1");
                    break;

                case "TwoBtn":
                    AppendToOutput("2");
                    break;

                case "ThreeBtn":
                    AppendToOutput("3");
                    break;

                case "FourBtn":
                    AppendToOutput("4");
                    break;

                case "FiveBtn":
                    AppendToOutput("5");
                    break;

                case "SixBtn":
                    AppendToOutput("6");
                    break;

                case "SevenBtn":
                    AppendToOutput("7");
                    break;

                case "EightBtn":
                    AppendToOutput("8");
                    break;

                case "NineBtn":
                    AppendToOutput("9");
                    break;

                case "ZeroBtn":
                    AppendToOutput("0");
                    break;

                case "CommaBtn":
                    AppendToOutput(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    break;
            }
        }

        private void AppendToOutput(string value)
        {
            output += value;
            OutputTextBlock.Text = output;
        }

        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            PrepareOperation("Minus");
        }

        private void TimesBtn_Click(object sender, RoutedEventArgs e)
        {
            PrepareOperation("Times");
        }

        private void DivideBtn_Click(object sender, RoutedEventArgs e)
        {
            PrepareOperation("Divide");
        }

        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            PrepareOperation("Plus");
        }

        private void PrepareOperation(string operationType)
        {
            if (output != "")
            {
                double currentInput;
                if (double.TryParse(output, NumberStyles.Float, CultureInfo.CurrentCulture, out currentInput))
                {
                    temp = currentInput;
                    output = "";
                    operation = operationType;
                }
            }
        }

        private void EqualsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (output != "")
            {
                double currentInput;
                if (double.TryParse(output, NumberStyles.Float, CultureInfo.CurrentCulture, out currentInput))
                {
                    double result = 0;

                    switch (operation)
                    {
                        case "Minus":
                            result = temp - currentInput;
                            break;

                        case "Times":
                            result = temp * currentInput;
                            break;

                        case "Divide":
                            result = temp / currentInput;
                            break;

                        case "Plus":
                            result = temp + currentInput;
                            break;
                    }

                    output = result.ToString();
                    OutputTextBlock.Text = output;
                    output = "";
                    temp = 0;
                }
            }
        }
    }
}

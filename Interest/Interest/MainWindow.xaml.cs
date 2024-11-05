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

namespace Interest
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

        private void colculateButton_Click(object sender, RoutedEventArgs e)
        {
            decimal capital = 0.0M;
            decimal desiredCapital = 0.0M;
            decimal interest = 0.0M;
            bool isFailed = !decimal.TryParse(beginkapitaalTextBox.Text, out capital) ||
                            !decimal.TryParse(eindkapitalTextBox.Text, out desiredCapital) ||
                            !decimal.TryParse(intrestTextBox.Text, out interest);
            if (isFailed)
            {
                clearButton_Click(this, null);
                return;
            }
            if (capital >= desiredCapital)
            {
                resultTextBox.Text = $"Waarde na 0 jaar: {capital}";
                return;
            }
            int numberYears = 0;
            StringBuilder sb = new StringBuilder();
            do
            {
                numberYears++;
                capital *= (1.0M + (interest / 100.0M));
                //capital += (interest / 100.0M) * capital;
                sb.AppendLine($"Waarde na {numberYears,2} jaren:{capital:c}");
            }
            while (capital < desiredCapital);
            resultTextBox.Text = sb.ToString();
            
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            beginkapitaalTextBox.Clear();
            eindkapitalTextBox.Clear();
            intrestTextBox.Clear();
            resultTextBox.Clear();
            beginkapitaalTextBox.Focus();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
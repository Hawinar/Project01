using System;
using System.Data;
using System.Windows;


namespace Project01
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
        string memory = string.Empty;
        public static string flag = string.Empty;
        byte commaLimit = 0;
        DataTable dt = new DataTable();
        string toExportData = string.Empty;
        public void GetInfo(string toExportData)
        {
            calcResult.Text += toExportData;
        }
        private void calc1_Click(object sender, RoutedEventArgs e)
        {
            calcResult.Text += "1";
            memory = calcResult.Text;
        }

        private void calc2_Click(object sender, RoutedEventArgs e)
        {
            calcResult.Text += "2";
            memory = calcResult.Text;
        }

        private void calc3_Click(object sender, RoutedEventArgs e)
        {
            calcResult.Text += "3";
            memory = calcResult.Text;
        }

        private void calc4_Click(object sender, RoutedEventArgs e)
        {
            calcResult.Text += "4";
            memory = calcResult.Text;
        }

        private void calc5_Click(object sender, RoutedEventArgs e)
        {
            calcResult.Text += "5";
            memory = calcResult.Text;
        }

        private void calc6_Click(object sender, RoutedEventArgs e)
        {
            calcResult.Text += "6";
            memory = calcResult.Text;
        }

        private void calc7_Click(object sender, RoutedEventArgs e)
        {
            calcResult.Text += "7";
            memory = calcResult.Text;
        }

        private void calc8_Click(object sender, RoutedEventArgs e)
        {
            calcResult.Text += "8";
            memory = calcResult.Text;
        }

        private void calc9_Click(object sender, RoutedEventArgs e)
        {
            calcResult.Text += "9";
            memory = calcResult.Text;
        }

        private void calcClear_Click(object sender, RoutedEventArgs e)
        {
            calcResult.Text = String.Empty;
            memory = string.Empty;
            commaLimit = 0;
            HistoryLabel.Content = String.Empty;
        }

        private void calc0_Click(object sender, RoutedEventArgs e)
        {
            calcResult.Text += "0";
            memory = calcResult.Text;
        }

        private void calc00_Click(object sender, RoutedEventArgs e)
        {
            if (calcResult.Text != String.Empty)
            {
                calcResult.Text += "00";
                memory = calcResult.Text;
            }
            
        }

        private void calcComma_Click(object sender, RoutedEventArgs e)
        {

            if (calcResult.Text != String.Empty)
            {
                string checkLastSymbol = calcResult.Text.Substring(calcResult.Text.Length - 1);
                if (checkLastSymbol != "," && commaLimit == 0)
                {
                    calcResult.Text += ",";
                    commaLimit = 1;
                }
            }
        }
        private void calcBackspace_Click(object sender, RoutedEventArgs e)
        {
            if (calcResult.Text != String.Empty)
            {
                string checkLastSymbol = calcResult.Text.Substring(calcResult.Text.Length - 1);
                if (checkLastSymbol == ",")
                {
                    commaLimit = 0;
                }
                calcResult.Text = calcResult.Text.Remove(calcResult.Text.Length - 1);
            }
           
        }
        private void calcSum_Click(object sender, RoutedEventArgs e)
        {
            if (calcResult.Text != string.Empty)
            {
                commaLimit = 0;
                HistoryLabel.Content += $"{memory} + ";
                calcResult.Text = string.Empty;
            }
        }
        private void calcSub_Click(object sender, RoutedEventArgs e)
        {
            if (calcResult.Text != string.Empty)
            {
                commaLimit = 0;
                HistoryLabel.Content += $"{memory} - ";
                calcResult.Text = string.Empty;
            }
        }
        private void calcMult_Click(object sender, RoutedEventArgs e)
        {
            if (calcResult.Text != string.Empty)
            {
                commaLimit = 0;
                HistoryLabel.Content += $"{memory} * ";
                calcResult.Text = string.Empty;
            }
        }

        private void calcDiv_Click(object sender, RoutedEventArgs e)
        {
            if (calcResult.Text != string.Empty)
            {
                commaLimit = 0;
                HistoryLabel.Content += $"{memory} / ";
                calcResult.Text = string.Empty;
            }        
        }
        private void calcEqual_Click(object sender, RoutedEventArgs e)
        {
            HistoryLabel.Content += calcResult.Text;
            string tmp = HistoryLabel.Content.ToString();
            tmp = tmp.Replace(",", ".");
            calcResult.Text = dt.Compute($"{tmp}", "").ToString();
            HistoryLabel.Content = string.Empty;
            memory = calcResult.Text;
        }

        private void calcNegative_Click(object sender, RoutedEventArgs e)
        {
            if (calcResult.Text != string.Empty)
            {
                calcResult.Text = (double.Parse(calcResult.Text) * (-1)).ToString();
            }
            
            
        }

        private void calcOpenBracket_Click(object sender, RoutedEventArgs e)
        {
            calcResult.Text += "(";
        }

        private void calcCloseBracket_Click(object sender, RoutedEventArgs e)
        {
            calcResult.Text += ")";
        }

        private void calcPow_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void calcRoot_Click(object sender, RoutedEventArgs e)
        {
            calcResult.Text = Math.Sqrt(double.Parse(calcResult.Text)).ToString();    
        }

        private void calcSin_Click(object sender, RoutedEventArgs e)
        {
            if(calcResult.Text != string.Empty)
            {
                double degrees = double.Parse(calcResult.Text);
                double radians = Math.PI / 180 * degrees;
                calcResult.Text = Math.Sin(radians).ToString();
                memory = calcResult.Text;
            }
            
        }

        private void calcCos_Click(object sender, RoutedEventArgs e)
        {
            if(calcResult.Text != string.Empty)
            {
                double degrees = double.Parse(calcResult.Text);
                double radians = Math.PI / 180 * degrees;
                memory = calcResult.Text;
            }
            
        }

        private void calcTan_Click(object sender, RoutedEventArgs e)
        {
            if(calcResult.Text != string.Empty)
            {
                double degrees = double.Parse(calcResult.Text);
                double radians = Math.PI / 180 * degrees;
                calcResult.Text = Math.Tan(radians).ToString();
                memory = calcResult.Text;
            }
        }

        private void calcCtg_Click(object sender, RoutedEventArgs e)
        {
            if(calcResult.Text != string.Empty)
            {
                double degrees = double.Parse(calcResult.Text);
                double radians = Math.PI / 180 * degrees;
                calcResult.Text = (1.0 / Math.Tan(radians)).ToString();
                memory = calcResult.Text;
            }
        }

        private void calcAsin_Click(object sender, RoutedEventArgs e)
        {
            double degrees = double.Parse(calcResult.Text);
            double radians = Math.PI / 180 * degrees;
            calcResult.Text = Math.Asin(radians).ToString();
            memory = calcResult.Text;
        }

        private void calcAcos_Click(object sender, RoutedEventArgs e)
        {
            if(calcResult.Text != string.Empty)
            {
                double degrees = double.Parse(calcResult.Text);
                double radians = Math.PI / 180 * degrees;
                calcResult.Text = Math.Acos(radians).ToString();
                memory = calcResult.Text;
            }
        }

        private void calcAtan_Click(object sender, RoutedEventArgs e)
        {
            if(calcResult.Text != string.Empty)
            {
                double degrees = double.Parse(calcResult.Text);
                double radians = Math.PI / 180 * degrees;
                calcResult.Text = Math.Atan(radians).ToString();
                memory = calcResult.Text;
            }
        }

        private void calcFact_Click(object sender, RoutedEventArgs e)
        {
            int localMemory = 1;
            for(int i = int.Parse(calcResult.Text); i > 0; i--)
            {
                localMemory *= i;
                
            }
            calcResult.Text = localMemory.ToString();
        }
       
    }
}

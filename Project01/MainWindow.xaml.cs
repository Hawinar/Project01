using System;
using System.Data;
using System.Windows;
using System.Windows.Media;

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
            calcTo10.Background = new SolidColorBrush(Color.FromRgb(159, 232, 237));
        }
        string memory = string.Empty;
        public static string flag = string.Empty;
        byte commaLimit = 0; //В
        DataTable dt = new DataTable();
        byte modePow = 0; //Обработчик нажатий для метода calcPow_Click
        byte modeRoot = 0; //Обработчик нажатий для метода calcRoot_Click
        byte modeNumberSystem = 10; //Хранилище предыдущей системы счисления для методов calcTo10_Click, calcTo2_Click, calcTo8_Click и calcTo16_Click
        double localMemoryX = 0; //Необходимо для того, чтобы хранить первого аргумента данные до операции Math.Pow() и/или Math.Sqrt
        double localMemoryY = 0; //Необходимо для того, чтобы хранить второго аргумента данные до операции Math.Pow()
        double GeneralNumber = 0; //Основное число для расчёта корня

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
            modePow = 0;
            calcPow.Background = new SolidColorBrush(Color.FromRgb(252, 255, 193));
            modeRoot = 0;
            GeneralNumber = 0;
            modeNumberSystem = 10;
            calcRoot.Background = new SolidColorBrush(Color.FromRgb(42, 220, 36));
            HistoryLabel.Content = String.Empty;
            localMemoryX = 0;
            localMemoryY = 0;
            calcTo10.Background = new SolidColorBrush(Color.FromRgb(159, 232, 237));
            calcTo2.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            calcTo8.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            calcTo16.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
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
            memory = calcResult.Text;
        }

        private void calcCloseBracket_Click(object sender, RoutedEventArgs e)
        {
            calcResult.Text += ")";
            memory = calcResult.Text;
        }


        private void calcPow_Click(object sender, RoutedEventArgs e)
        {
            if (calcResult.Text != string.Empty)
            {
                switch (modePow)
                {
                    case 0:

                        localMemoryX = double.Parse(calcResult.Text);
                        calcResult.Text = string.Empty;
                        modePow = 1;
                        calcPow.Background = new SolidColorBrush(Color.FromRgb(255, 117, 64));
                        break;
                    case 1:
                        localMemoryY = double.Parse(calcResult.Text);
                        calcResult.Text = Math.Pow(localMemoryX, localMemoryY).ToString();
                        modePow = 0;
                        localMemoryX = 0;
                        localMemoryY = 0;
                        calcPow.Background = new SolidColorBrush(Color.FromRgb(252, 255, 193));
                        break;

                }
            }

        }

        private void calcRoot_Click(object sender, RoutedEventArgs e)
        {
            if (calcResult.Text != string.Empty)
            {

                switch (modeRoot)
                {
                    case 0:
                        GeneralNumber = double.Parse(calcResult.Text);
                        calcResult.Text = string.Empty;
                        modeRoot = 1;
                        calcRoot.Background = new SolidColorBrush(Color.FromRgb(160, 36, 220));
                        break;
                    case 1:
                        localMemoryX = double.Parse(calcResult.Text);
                        calcResult.Text = string.Empty;
                        modeRoot = 2;
                        calcRoot.Background = new SolidColorBrush(Color.FromRgb(64, 223, 226));
                        break;
                    case 2:
                        localMemoryY = double.Parse(calcResult.Text);
                        calcResult.Text = (Math.Pow(GeneralNumber, (localMemoryY / localMemoryX))).ToString();
                        modeRoot = 0;
                        localMemoryX = 0;
                        localMemoryY = 0;
                        calcRoot.Background = new SolidColorBrush(Color.FromRgb(42, 220, 36));
                        break;

                }
            }
        }

        private void calcSin_Click(object sender, RoutedEventArgs e)
        {
            if (calcResult.Text != string.Empty)
            {
                double degrees = double.Parse(calcResult.Text);
                double radians = Math.PI / 180 * degrees;
                calcResult.Text = Math.Sin(radians).ToString();
                memory = calcResult.Text;
            }

        }

        private void calcCos_Click(object sender, RoutedEventArgs e)
        {
            if (calcResult.Text != string.Empty)
            {
                double degrees = double.Parse(calcResult.Text);
                double radians = Math.PI / 180 * degrees;
                memory = calcResult.Text;
            }
        }

        private void calcTan_Click(object sender, RoutedEventArgs e)
        {
            if (calcResult.Text != string.Empty)
            {
                double degrees = double.Parse(calcResult.Text);
                double radians = Math.PI / 180 * degrees;
                calcResult.Text = Math.Tan(radians).ToString();
                memory = calcResult.Text;
            }
        }

        private void calcCtg_Click(object sender, RoutedEventArgs e)
        {
            if (calcResult.Text != string.Empty)
            {
                double degrees = double.Parse(calcResult.Text);
                double radians = Math.PI / 180 * degrees;
                calcResult.Text = (1.0 / Math.Tan(radians)).ToString();
                memory = calcResult.Text;
            }
        }

        private void calcAsin_Click(object sender, RoutedEventArgs e)
        {
            if (calcResult.Text != string.Empty)
            {
                double degrees = double.Parse(calcResult.Text);
                double radians = Math.PI / 180 * degrees;
                calcResult.Text = Math.Asin(radians).ToString();
                memory = calcResult.Text;
            }

        }

        private void calcAcos_Click(object sender, RoutedEventArgs e)
        {
            if (calcResult.Text != string.Empty)
            {
                double degrees = double.Parse(calcResult.Text);
                double radians = Math.PI / 180 * degrees;
                calcResult.Text = Math.Acos(radians).ToString();
                memory = calcResult.Text;
            }
        }

        private void calcAtan_Click(object sender, RoutedEventArgs e)
        {
            if (calcResult.Text != string.Empty)
            {
                double degrees = double.Parse(calcResult.Text);
                double radians = Math.PI / 180 * degrees;
                calcResult.Text = Math.Atan(radians).ToString();
                memory = calcResult.Text;
            }
        }

        private void calcFact_Click(object sender, RoutedEventArgs e)
        {
            if (commaLimit == 0 && calcResult.Text != string.Empty)
            {
                int localMemory = 1;
                for (int i = int.Parse(calcResult.Text); i > 0; i--)
                {
                    localMemory *= i;

                }
                calcResult.Text = localMemory.ToString();
            }
        }

        private void calcTo10_Click(object sender, RoutedEventArgs e)
        {
            if (calcResult.Text != string.Empty)
            {
                string number = calcResult.Text;
                int fromBase = modeNumberSystem;
                int toBase = 10;
                calcResult.Text = Convert.ToString(Convert.ToInt32(number, fromBase), toBase);
                modeNumberSystem = 10;
                calcTo10.Background = new SolidColorBrush(Color.FromRgb(159, 232, 237));

                calcTo2.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                calcTo8.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                calcTo16.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            }

        }


        private void calcTo2_Click(object sender, RoutedEventArgs e)
        {
            if (calcResult.Text != string.Empty)
            {
                string number = calcResult.Text;
                int fromBase = modeNumberSystem;
                int toBase = 2;
                calcResult.Text = Convert.ToString(Convert.ToInt32(number, fromBase), toBase);
                modeNumberSystem = 2;
                calcTo2.Background = new SolidColorBrush(Color.FromRgb(159, 232, 237));

                calcTo8.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                calcTo10.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                calcTo16.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            }
        }

        private void calcTo8_Click(object sender, RoutedEventArgs e)
        {
            if (calcResult.Text != string.Empty)
            {
                string number = calcResult.Text;
                int fromBase = modeNumberSystem;
                int toBase = 8;
                calcResult.Text = Convert.ToString(Convert.ToInt32(number, fromBase), toBase);
                modeNumberSystem = 8;
                calcTo8.Background = new SolidColorBrush(Color.FromRgb(159, 232, 237));

                calcTo2.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                calcTo10.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                calcTo16.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            }

        }

        private void calcTo16_Click(object sender, RoutedEventArgs e)
        {
            if (calcResult.Text != string.Empty)
            {
                string number = calcResult.Text;
                int fromBase = modeNumberSystem;
                int toBase = 16;
                calcResult.Text = Convert.ToString(Convert.ToInt32(number, fromBase), toBase);
                modeNumberSystem = 16;
                calcTo16.Background = new SolidColorBrush(Color.FromRgb(159, 232, 237));

                calcTo2.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                calcTo10.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                calcTo8.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            }
        }
    }
}

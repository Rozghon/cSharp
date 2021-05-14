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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int amount = 16;
        static int[] numbers = new int[amount];
        static Button[] buttons = new Button[amount];
        static int lastButton = 0;
        Label congr = new Label();
        Canvas canvas = new Canvas();


        void resetBtns()
        {
            canvas.Children.Clear();
            lastButton = 0;
            numbers = new int[amount];

            for (int i = 0; i < numbers.Length; i++)
            {
                int temp;
                do
                {
                    temp = (int)(new Random()).Next(1, 17);

                    if (!numbers.Contains<int>(temp))
                    {
                        numbers[i] = temp;
                        break;
                    }
                } while (numbers.Contains<int>(temp));
            }

            buttons = new Button[amount];

            for (int i = 0, j = 0, k = 0; i < buttons.Length; i++, j++)
            {
                if (j == 4)
                {
                    j = 0;
                    k++;
                }

                buttons[i] = new Button();
                buttons[i].Content = numbers[i].ToString();
                buttons[i].Width = 45;
                buttons[i].Height = 45;
                buttons[i].Margin = new Thickness(k * 45 + 5, j * 45 + 5, 0, 0);

                buttons[i].Click += (s, e) =>
                {
                    congr.Visibility = Visibility.Hidden;

                    for (int i = 0; i < buttons.Length; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            double x = buttons[i].Margin.Left;
                            double y = buttons[i].Margin.Top;

                            buttons[i].Margin = new Thickness(buttons[j].Margin.Left, buttons[j].Margin.Top, 0, 0);
                            buttons[j].Margin = new Thickness(x, y, 0, 0);
                        }
                    }

                    Button temp = s as Button;
                    int num = Int16.Parse(temp.Content.ToString());

                    (temp).Visibility = Visibility.Hidden;

                    if (lastButton != num - 1)
                    {
                        resetBtns();
                    }
                    else if (num == 16)
                    {
                        resetBtns();
                        congr.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        lastButton = num;
                    }
                };
                canvas.Children.Add(buttons[i]);
            }

            t2.Content = canvas;

            canvas.Children.Add(congr);
        }

        public MainWindow()
        {
            InitializeComponent();


            for (int i = 0; i < numbers.Length; i++)
            {
                int temp;
                do
                {
                    temp = (int)(new Random()).Next(1, 17);

                    if (!numbers.Contains<int>(temp))
                    {
                        numbers[i] = temp;
                        break;
                    }
                } while (numbers.Contains<int>(temp));
            }

            congr.Content = "Молодець!";
            congr.Margin = new Thickness(210, 90, 0, 0);
            congr.Visibility = Visibility.Hidden;
            canvas.Children.Add(congr);

            for (int i = 0, j = 0, k = 0; i < buttons.Length; i++, j++)
            {
                if (j == 4)
                {
                    j = 0;
                    k++;
                }

                buttons[i] = new Button();
                buttons[i].Content = numbers[i].ToString();
                buttons[i].Width = 45;
                buttons[i].Height = 45;
                buttons[i].Margin = new Thickness(k * 45 + 5, j * 45 + 5, 0, 0);

                buttons[i].Click += (s, e) =>
                {
                    congr.Visibility = Visibility.Hidden;

                    for (int i = 0; i < buttons.Length; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            double x = buttons[i].Margin.Left;
                            double y = buttons[i].Margin.Top;

                            buttons[i].Margin = new Thickness(buttons[j].Margin.Left, buttons[j].Margin.Top, 0, 0);
                            buttons[j].Margin = new Thickness(x, y, 0, 0);
                        }
                    }

                    Button temp = s as Button;
                    int num = Int16.Parse(temp.Content.ToString());

                    (temp).Visibility = Visibility.Hidden;

                    if (lastButton != num - 1)
                    {
                        resetBtns();
                    }
                    else if (num == 16)
                    {
                        resetBtns();
                        congr.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        lastButton = num;
                    }
                };
                canvas.Children.Add(buttons[i]);
            }

            t2.Content = canvas;
        }


        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBox1.Items.Add(TextBox1.Text);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBox1.Items.RemoveAt(ComboBox1.Items.IndexOf(ComboBox1.SelectedItem));
        }

    }
}

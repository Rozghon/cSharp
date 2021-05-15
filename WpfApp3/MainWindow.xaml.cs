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
using System.Windows.Threading;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool showMessage = false;
        private int counter;
        DispatcherTimer timerTitle;
        DispatcherTimer timerMain;

        public MainWindow()
        {
            InitializeComponent();
            counter = 1;
            timerTitle = new DispatcherTimer();
            timerTitle.Tick += new EventHandler(timerTitle_tick);
            timerTitle.Interval = new TimeSpan(0, 0, 3);
            timerTitle.Start();
            timerMain = new DispatcherTimer();
            timerMain.Tick += new EventHandler(timerMain_tick);
            timerMain.Interval = new TimeSpan(0, 0, 1);
        }

        private void timerTitle_tick(object sender, EventArgs e)
        {
            timerTitle.Interval = new TimeSpan(0, 0, 1);
            if (showMessage)
            {
                base.Title = "Press 'OK' button";
                showMessage = false;
            }
            else
            {
                base.Title = "";
                showMessage = true;
            }
            counter++;
            if (counter > 8)
            {
                timerTitle.Stop();
                showMessage = false;
            }
        }

        private void timerMain_tick(object sender, EventArgs e)
        {
            if (showMessage)
            {
                base.Title = "'OK' will never be pressed!";
                showMessage = false;
            }
            else
            {
                base.Title = "";
                showMessage = true;
            }
            counter++;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (buttonOk.Margin.Left < 1)
            {
                buttonOk.Margin = new Thickness(buttonOk.Margin.Left + 100, buttonOk.Margin.Top, 0, 0);
            }
            if (buttonOk.Margin.Left + buttonOk.Width + 10 > base.Width)
            {
                buttonOk.Margin = new Thickness(base.Width - 100 - buttonOk.Width, buttonOk.Margin.Top, 0, 0);
            }
            if (buttonOk.Margin.Top < 1)
            {
                buttonOk.Margin = new Thickness(buttonOk.Margin.Left, buttonOk.Margin.Top + 100, 0, 0);
            }
            if (buttonOk.Margin.Top + buttonOk.Height + 40 > base.Height)
            {
                buttonOk.Margin = new Thickness(buttonOk.Margin.Left, base.Height - 100 - buttonOk.Height, 0, 0);
            }
            if (e.GetPosition(c).X > buttonOk.Margin.Left - 20
                && e.GetPosition(c).Y > buttonOk.Margin.Top - 20
                && e.GetPosition(c).X < buttonOk.Margin.Left + buttonOk.Width / 2
                && e.GetPosition(c).Y < buttonOk.Margin.Top + buttonOk.Height / 2)
            {
                buttonOk.Margin = new Thickness(buttonOk.Margin.Left + 1, buttonOk.Margin.Top + 1, 0, 0);
                changeSize();
            }
            if (e.GetPosition(c).X > buttonOk.Margin.Left - 15
                && e.GetPosition(c).X < buttonOk.Margin.Left + buttonOk.Width / 2
                && e.GetPosition(c).Y > buttonOk.Margin.Top + buttonOk.Height / 2
                && e.GetPosition(c).Y < buttonOk.Margin.Top + buttonOk.Height + 20)
            {
                buttonOk.Margin = new Thickness(buttonOk.Margin.Left + 5, buttonOk.Margin.Top - 5, 0, 0);
                changeSize();
            }
            if (e.GetPosition(c).X > buttonOk.Margin.Left + buttonOk.Width / 2
                && e.GetPosition(c).X < buttonOk.Margin.Left + buttonOk.Width + 20
                && e.GetPosition(c).Y > buttonOk.Margin.Top + buttonOk.Height / 2
                && e.GetPosition(c).Y < buttonOk.Margin.Top + buttonOk.Height + 20)
            {
                buttonOk.Margin = new Thickness(buttonOk.Margin.Left - 5, buttonOk.Margin.Top - 5, 0, 0);
                changeSize();
            }
            if (e.GetPosition(c).X > buttonOk.Margin.Left + buttonOk.Width / 2
                && e.GetPosition(c).X < buttonOk.Margin.Left + buttonOk.Width + 20
                && e.GetPosition(c).Y < buttonOk.Margin.Top + buttonOk.Height / 2
                && e.GetPosition(c).Y > buttonOk.Margin.Top - 20)
            {
                buttonOk.Margin = new Thickness(buttonOk.Margin.Left - 5, buttonOk.Margin.Top + 5, 0, 0);
                changeSize();
            }
        }

        private void changeSize()
        {
            if (buttonOk.Width > 0.1 && buttonOk.Height > 0.1)
            {
                buttonOk.Width = buttonOk.Width - 0.1;
                buttonOk.Height = buttonOk.Height - 0.1;
            }
            else
            {
                buttonOk.Visibility = Visibility.Hidden;
                timerMain.Start();
                timerMain_tick(null, null);
            }
        }

        private void buttonOk_MouseEnter(object sender, MouseEventArgs e)
        {
            buttonOk.Margin = new Thickness(buttonCancel.Margin.Left + 200, buttonCancel.Margin.Top + 200, 0, 0);
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button 'OK' has been clicked");
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

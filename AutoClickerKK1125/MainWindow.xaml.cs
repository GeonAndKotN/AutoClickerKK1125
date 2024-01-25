using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WindowsInput;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Automation;

namespace AutoClickerKK1125
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
        public string MyCommand;
        static int am;
        static int ms;
        private void Znachenia()
        {
            am = Int32.Parse(Amount.Text);
            ms = Int32.Parse(TimeInSeconds.Text);
        }
        Thread thread;
        private void StartClick(object sender, RoutedEventArgs e)
        {
            Znachenia();
            thread = new Thread(Anotherthread);
            thread.Start();
        }

        private void Anotherthread()
        {
            InputSimulator simulator = new InputSimulator();
            Thread.Sleep(3000);
            for (int i = 0; i < am; i++)
            {
                simulator.Mouse.LeftButtonClick();
                Thread.Sleep(ms);
            }
        }

        private void StopClick(object sender, RoutedEventArgs e)
        {
            am = 0;
        }

        private void TextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == textBox.ToolTip.ToString())
                textBox.Text = null;
        }

        private void Button_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.O)
            {
                StartClick(sender, e);
            }
            if (e.Key == Key.P)
            {
                StopClick(sender, e);
            }
        }
    }
}

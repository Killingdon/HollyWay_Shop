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

namespace HollyWay
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Window1 mainwin;
        public static MainWindow askwin = new MainWindow();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Change(object sender, EventArgs e)
        {
            if (mainwin == null)
            {
                mainwin = new Window1();
                mainwin.Show();
                askwin.Close();
            }
            else mainwin.Activate();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            askwin.Close();
        }
    }
}

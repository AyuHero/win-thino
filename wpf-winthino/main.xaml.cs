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
using System.Windows.Shapes;

namespace wpf_winthino
{
    /// <summary>
    /// main.xaml 的交互逻辑
    /// </summary>
    public partial class main : Window
    {


        public main()
        {
            InitializeComponent();
            Topmost = true;
        }
        public int a = 1;
        private void but_Click(object sender, RoutedEventArgs e)
        {
            if (a == 0)
            {
                Top = Top - 280;
                Left = Left - 280;

                bor.Height = 350;
                bor.Width = 350;

                this.Height = 350;
                this.Width = 350;

                grtext.Visibility = Visibility.Visible;
                grbom.Visibility = Visibility.Visible;

                textb.Text = "发射";

                but.Height = 52;
                but.Width = 52;

                fsb.Height = 50;
                fsb.Width = 50;

                a = 1;
                return;
            }
        }

        private void mainf_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void but_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bor.Height = 70;
            bor.Width = 70;

            this.Height = 70;
            this.Width = 70;

            Top = Top + 280;
            Left = Left + 280;

            grtext.Visibility = Visibility.Collapsed;
            grbom.Visibility = Visibility.Collapsed;



            textb.Text = "开启";

            but.Height = 47;
            but.Width = 47;

            fsb.Height = 45;
            fsb.Width = 45;

            a = 0;
            return;
        }

        private void date_Click(object sender, RoutedEventArgs e)
        {
        }

        private void date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedDateText = date.SelectedDate.Value.ToString("yyyy-MM-dd");
            rich.AppendText(selectedDateText);
        }
    }
}

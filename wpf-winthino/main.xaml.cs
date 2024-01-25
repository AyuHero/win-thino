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
        }
        public int a = 1;
        private void but_Click(object sender, RoutedEventArgs e)
        {
            if (a == 1)
            {
                bor.Height = 70;
                bor.Width = 70;

                this.Height = 70;
                this.Width = 70;

                Top = Top + 380;
                Left = Left + 380;

                a = 0;
                return;
            }
            if (a == 0)
            {
                Top = Top - 380;
                Left = Left - 380;

                bor.Height = 450;
                bor.Width = 450;

                this.Height = 450;
                this.Width = 450;

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
    }
}

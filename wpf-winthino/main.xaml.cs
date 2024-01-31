using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace wpf_winthino
{
    /// <summary>
    /// main.xaml 的交互逻辑
    /// </summary>
    public partial class main : Window
    {

        public string[] setsrting = { };
        public int imas = 0;

        public main()
        {
            InitializeComponent();
            Topmost = true;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }


        public int bigger = 1;



        private void but_Click(object sender, RoutedEventArgs e)
        {


            if (bigger == 0)
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


                bigger = 1;

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

            bigger = 0;
            return;
        }



        private void date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedDateText = date.SelectedDate.Value.ToString("yyyy-MM-dd");
            string tasks = " 📆" + selectedDateText;
            rich.AppendText(tasks);
        }

        private void setb_Click(object sender, RoutedEventArgs e)
        {
            set s1 = new set();
            this.Hide();
            s1.ShowDialog();
            this.Close();
        }

        private void mainf_Loaded(object sender, RoutedEventArgs e)
        {

            string filePath = @".\配置文件.txt";

            string filestring = "";
            try
            {
                // 使用StreamReader打开文件
                using (StreamReader sr = new StreamReader(filePath))
                {
                    // 读取文件的所有内容
                    filestring = sr.ReadToEnd();
                }
            }
            catch
            {
                // 处理异常
                System.Windows.MessageBox.Show("配置文件异常请检查");
            }
            setsrting = filestring.Split(',');
            imas = int.Parse(setsrting[2]);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Windows.Clipboard.Clear();

            TextPointer originalSelectionStart = rich.CaretPosition;

            // 剪切选中的文本到剪贴板
            rich.Cut();

            if (System.Windows.Clipboard.GetText() == "")
            {
                return;
            }

            // 从剪贴板中获取文本
            string formattedText = "**" + System.Windows.Clipboard.GetText() + "**";

            // 恢复原始选中位置并插入格式化的文本
            rich.Selection.Select(originalSelectionStart, originalSelectionStart);
            rich.CaretPosition.InsertTextInRun(formattedText);

            System.Windows.Clipboard.Clear();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            System.Windows.Clipboard.Clear();

            TextPointer originalSelectionStart = rich.CaretPosition;

            // 剪切选中的文本到剪贴板
            rich.Cut();

            if (System.Windows.Clipboard.GetText() == "")
            {
                return;
            }

            // 从剪贴板中获取文本
            string formattedText = "*" + System.Windows.Clipboard.GetText() + "*";

            // 恢复原始选中位置并插入格式化的文本
            rich.Selection.Select(originalSelectionStart, originalSelectionStart);
            rich.CaretPosition.InsertTextInRun(formattedText);

            System.Windows.Clipboard.Clear();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            System.Windows.Clipboard.Clear();

            TextPointer originalSelectionStart = rich.CaretPosition;

            // 剪切选中的文本到剪贴板
            rich.Cut();

            if (System.Windows.Clipboard.GetText() == "")
            {
                return;
            }

            // 从剪贴板中获取文本
            string formattedText = "~~" + System.Windows.Clipboard.GetText() + "~~";

            // 恢复原始选中位置并插入格式化的文本
            rich.Selection.Select(originalSelectionStart, originalSelectionStart);
            rich.CaretPosition.InsertTextInRun(formattedText);

            System.Windows.Clipboard.Clear();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            System.Windows.Clipboard.Clear();

            TextPointer originalSelectionStart = rich.CaretPosition;

            // 剪切选中的文本到剪贴板
            rich.Cut();

            if (System.Windows.Clipboard.GetText() == "")
            {
                return;
            }

            // 从剪贴板中获取文本
            string formattedText = "==" + System.Windows.Clipboard.GetText() + "==";

            // 恢复原始选中位置并插入格式化的文本
            rich.Selection.Select(originalSelectionStart, originalSelectionStart);
            rich.CaretPosition.InsertTextInRun(formattedText);

            System.Windows.Clipboard.Clear();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All Files|*.*";
            openFileDialog.ShowDialog();
            string filePath = openFileDialog.FileName;
            BitmapImage image = new BitmapImage(new Uri(filePath));
            string savePath = setsrting[1] + @"\image" + imas + ".png";
            SaveImage(image, savePath);
            rich.AppendText("\n![[image" + imas + ".png|500]]\n");
            imas += 1;
            string a = setsrting[0] + "," + setsrting[1] + "," + imas;
            string filPath = @".\配置文件.txt";
            File.WriteAllText(filPath, a);
            System.Windows.Clipboard.Clear();

        }


        private void SaveImage(BitmapImage image, string filePath)
        {
            try
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    encoder.Save(stream);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("失败,请检查配置的附件文件的位置是否正确，如第一次设置，请重启软件");
            }
        }
    }
}

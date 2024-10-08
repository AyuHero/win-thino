﻿
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Forms;
using System.Drawing;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;
using Application = System.Windows.Application;

namespace wpf_winthino
{
    /// <summary>
    /// main.xaml 的交互逻辑
    /// </summary>
    /// 
    public partial class main : System.Windows.Window
    {
        private NotifyIcon trayIcon; // 托盘图标实例
        public string[] setsrting = { };
        public int imas = 0;

        public main()
        {
            InitializeComponent();
            Topmost = true;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeTrayIcon();
        }

        private void InitializeTrayIcon()
        {

            var iconStream = Application.GetResourceStream(new Uri("pack://application:,,,/image/013115302283_0纸飞机,折纸,发送 (1).ico")).Stream;
            trayIcon = new NotifyIcon
            {
                Icon = new Icon(iconStream), // 使用图标流来创建图标
                Visible = true,
                Text = "Win-Thino" // 鼠标悬停时显示的文本
            };

            trayIcon.DoubleClick += TrayIcon_DoubleClick; // 设置双击事件处理程序
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Close(); 
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            trayIcon.Dispose(); // 应用程序关闭时清理托盘图标
        }



        public int bigger = 1;

        public double windowLeft = 0;
        public double windowTop = 0;
        public int winmove = 0;

        private async void but_Click(object sender, RoutedEventArgs e)
        {


            if (bigger == 0)
            {
                windowLeft = this.Left;
                windowTop = this.Top;
                winmove = 1;

                // 获取屏幕的工作区大小
                var screenWidth = System.Windows.SystemParameters.WorkArea.Width;
                var screenHeight = System.Windows.SystemParameters.WorkArea.Height;

                // 计算窗口的位置
                var windowWidth = this.Width;
                var windowHeight = this.Height;

                var newLeft = (screenWidth - windowWidth) / 2;
                var newTop = (screenHeight - windowHeight) / 2;

                // 设置窗口的位置
                this.Left = newLeft + 140;
                this.Top = newTop + 75;


                Top = Top - 150;
                Left = Left - 280;

                bor.Height = 220;
                bor.Width = 350;

                this.Height = 220;
                this.Width = 350;

                grtext.Visibility = Visibility.Visible;
                grbom.Visibility = Visibility.Visible;

                textb.Text = "发射";

                but.Height = 52;
                but.Width = 52;

                fsb.Height = 50;
                fsb.Width = 50;
                bigger = 1;

                fsb.Background = new SolidColorBrush(Colors.Black);
                textb.Foreground = new SolidColorBrush(Colors.White);

                rich.Document.Blocks.Clear();
                rich.AppendText(System.Windows.Clipboard.GetText());
                System.Windows.Clipboard.Clear();



                return;
            }
            else 
            {
                System.Windows.Clipboard.Clear();
                TextRange textRange = new TextRange(rich.Document.ContentStart, rich.Document.ContentEnd);
                string message = textRange.Text.Trim();

                if (message == "")
                { return; }
                var todo = true;


                if (ctodo.IsChecked == true)
                {
                    todo = false;
                }


                var apiUrl = setsrting[0];
                var requestData = new
                {
                    text = message,
                    isList = todo,
                    type = com.Text.Trim(),
                };


                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
                        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");


                        var response = await httpClient.PostAsync(apiUrl, content);

                        if (response.IsSuccessStatusCode)
                        {
                            rich.Document.Blocks.Clear();

                            fsb.Background = new SolidColorBrush(Colors.Green);
                            textb.Foreground = new SolidColorBrush(Colors.White);
                            textb.Text = "成功";
                            ctodo.IsChecked = false;
                            //成功
                        }
                        else
                        {
                            fsb.Background = new SolidColorBrush(Colors.Red);
                            textb.Foreground = new SolidColorBrush(Colors.White);
                            textb.Text = "失败";
                            //失败
                        }
                    }
                    catch 
                    {
                        fsb.Background = new SolidColorBrush(Colors.Red);
                        textb.Foreground = new SolidColorBrush(Colors.White);
                        textb.Text = "失败";
                    }
                }
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
            if (winmove == 0)
            { 
            bor.Height = 70;
            bor.Width = 70;

            this.Height = 70;
            this.Width = 70;

            Top = Top + 150;
            Left = Left + 280;

            grtext.Visibility = Visibility.Collapsed;
            grbom.Visibility = Visibility.Collapsed;



            textb.Text = "开启";

            but.Height = 47;
            but.Width = 47;

            fsb.Height = 45;
            fsb.Width = 45;


            fsb.Background = new SolidColorBrush(Colors.White);
            textb.Foreground = new SolidColorBrush(Colors.Black);

            bigger = 0;
            return;
            }
            if (winmove == 1)
            {
                bor.Height = 70;
                bor.Width = 70;

                this.Height = 70;
                this.Width = 70;

                Top = Top + 150;
                Left = Left + 280;

                grtext.Visibility = Visibility.Collapsed;
                grbom.Visibility = Visibility.Collapsed;



                textb.Text = "开启";

                but.Height = 47;
                but.Width = 47;

                fsb.Height = 45;
                fsb.Width = 45;


                fsb.Background = new SolidColorBrush(Colors.White);
                textb.Foreground = new SolidColorBrush(Colors.Black);

                bigger = 0;

                this.Left = windowLeft;
                this.Top = windowTop;
                return;
            }
        }



        private void date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedDateText = date.SelectedDate.Value.ToString("yyyy-MM-dd");
            string tasks = " 📆" + selectedDateText;
            rich.AppendText(tasks);
            ctodo.IsChecked = true;
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
                rich.Focus();
                return;
            }

            // 从剪贴板中获取文本
            string formattedText = "**" + System.Windows.Clipboard.GetText() + "**";

            // 恢复原始选中位置并插入格式化的文本
            rich.Selection.Select(originalSelectionStart, originalSelectionStart);
            rich.CaretPosition.InsertTextInRun(formattedText);
            rich.Focus();
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
                rich.Focus();
                return;
            }

            // 从剪贴板中获取文本
            string formattedText = "*" + System.Windows.Clipboard.GetText() + "*";

            // 恢复原始选中位置并插入格式化的文本
            rich.Selection.Select(originalSelectionStart, originalSelectionStart);
            rich.CaretPosition.InsertTextInRun(formattedText);
            rich.Focus();
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
                rich.Focus();
                return;
            }

            // 从剪贴板中获取文本
            string formattedText = "~~" + System.Windows.Clipboard.GetText() + "~~";

            // 恢复原始选中位置并插入格式化的文本
            rich.Selection.Select(originalSelectionStart, originalSelectionStart);
            rich.CaretPosition.InsertTextInRun(formattedText);
            rich.Focus();
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
                rich.Focus();
                return;
            }

            // 从剪贴板中获取文本
            string formattedText = "==" + System.Windows.Clipboard.GetText() + "==";

            // 恢复原始选中位置并插入格式化的文本
            rich.Selection.Select(originalSelectionStart, originalSelectionStart);
            rich.CaretPosition.InsertTextInRun(formattedText);
            rich.Focus();
            System.Windows.Clipboard.Clear();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All Files|*.*";
            openFileDialog.ShowDialog();
            string filePath = openFileDialog.FileName;
            if (filePath != "")
            {
                BitmapImage image = new BitmapImage(new Uri(filePath));
                string savePath = setsrting[1] + @"\image" + imas + ".png";
                SaveImage(image, savePath);
                rich.AppendText(" "+"\n![[image" + imas + ".png]]\n");
                imas += 1;
                string a = setsrting[0] + "," + setsrting[1] + "," + imas;
                string filPath = @".\配置文件.txt";
                File.WriteAllText(filPath, a);
                System.Windows.Clipboard.Clear();
                rich.Focus();
                rich.CaretPosition = rich.Document.ContentEnd;
                rich.ScrollToEnd();
            }
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
            catch 
            {
                
                System.Windows.MessageBox.Show("失败,请检查配置的附件文件的位置是否正确，如第一次使用请先设置附件位置");
                
            }
        }
        private void Savemage(BitmapSource image, string filePath)
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
            catch
            {

                System.Windows.MessageBox.Show("失败,请检查配置的附件文件的位置是否正确，如第一次使用请先设置附件位置");

            }
        }

        private void rich_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fsb.Background = new SolidColorBrush(Colors.White);
            textb.Foreground = new SolidColorBrush(Colors.Black);
            textb.Text = "发射";


            if (System.Windows.Clipboard.ContainsImage())
            {
                BitmapSource image = System.Windows.Clipboard.GetImage();
                string savePath = setsrting[1] + @"\image" + imas + ".png";
                Savemage(image, savePath);
                rich.AppendText(" " + "\n![[image" + imas + ".png]]\n");
                imas += 1;
                string a = setsrting[0] + "," + setsrting[1] + "," + imas;
                string filPath = @".\配置文件.txt";
                File.WriteAllText(filPath, a);
                System.Windows.Clipboard.Clear();
                rich.Focus();
                rich.CaretPosition = rich.Document.ContentEnd;
                rich.ScrollToEnd();
            }

        }

        public object color1 = null;
        public object color2 = null;
        private void but_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            color1 = fsb.Background;
            color2 =textb.Foreground;
            textb.Foreground = new SolidColorBrush(Colors.White);
            fsb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8076a3"));
        }

        private void but_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            textb.Foreground = (System.Windows.Media.Brush)color2;
            fsb.Background = (System.Windows.Media.Brush)color1;
            color1 = null;
            color2 = null;
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            rich.Document.Blocks.Clear();
            rich.Focus();
        }

        private void rich_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            rich.BorderBrush = new SolidColorBrush(Colors.Black);
        }

    }
}

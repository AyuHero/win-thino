using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;


namespace wpf_winthino
{
    /// <summary>
    /// set.xaml 的交互逻辑
    /// </summary>
    public partial class set : Window
    {
        public set()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public string[] setsrting = { };

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string a = mbtext.Text.Trim() + "," + setsrting[1] + "," + setsrting[2];
            string filePath = @".\配置文件.txt";
            File.WriteAllText(filePath, a);
            System.Windows.MessageBox.Show("修改成功");
        }



        private void Grid_Loaded(object sender, RoutedEventArgs e)
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
            mbtext.Text = setsrting[0];
            fjtxt.Text = setsrting[1];
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                // 设置对话框的标题
                folderDialog.Description = "选择文件夹";

                // 显示对话框，并检查用户是否点击了“确定”按钮
                DialogResult result = folderDialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    // 获取用户选择的文件夹路径
                    string selectedFolderPath = folderDialog.SelectedPath;
                    fjtxt.Text = selectedFolderPath;
                    setsrting[1] = selectedFolderPath.Trim();
                    string a = setsrting[0] + "," + setsrting[1] + "," + setsrting[2];
                    string filePath = @".\配置文件.txt";
                    File.WriteAllText(filePath, a);
                }
                else
                {
                    Console.WriteLine("用户取消了文件夹选择。");
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            main m1 = new main();
            this.Hide();
            m1.ShowDialog();
            this.Close();
        }
    }
}

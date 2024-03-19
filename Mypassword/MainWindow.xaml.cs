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

namespace Mypassword
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count = 0;
        public MainWindow()
        {
            InitializeComponent();
            selectMaxLen.SelectedItem = "6";
        }

        private void bt_copy_Click(object sender, RoutedEventArgs e)
        {
            int maxLen = int.Parse(selectMaxLen.SelectedItem.ToString());
            if (scratchTextBox.Text.Length >= maxLen)
            {
                scratchTextBox.Select(0, maxLen);
                scratchTextBox.Copy();
            }
            else {
                scratchTextBox.SelectAll();
                scratchTextBox.Copy();
            }
        }

        private void bt_paste_Click(object sender, RoutedEventArgs e)
        {
            pwdBox.Clear();
            pwdBox.Paste();
            count++;
            pwChagesLabel.Content = count.ToString();
        }

        private void bt_clear_Click(object sender, RoutedEventArgs e)
        {
            pwdBox.Clear();
        }

        private void listMaskChar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pwdBox.PasswordChar =((ComboBoxItem)listMaskChar.SelectedItem).Content.ToString().ToCharArray()[0];
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listMaskChar.Text=pwdBox.PasswordChar.ToString();
            for(int i = 6;i<= 100; i++)
            {
                selectMaxLen.Items.Add(i.ToString());
            }
            selectMaxLen.SelectedItem = 0;
        }

        private void selectMaxLen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentMaxLen.Content = selectMaxLen.SelectedItem.ToString();
        }

        private void scratchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int maxLen = int.Parse(selectMaxLen.SelectedItem.ToString());
            int len = scratchTextBox.Text.Length;
            currentMaxLen.Content = $"{maxLen - len}";
        }
    }
}
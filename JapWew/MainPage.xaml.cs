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
using JapWoahLib;

namespace JapWew
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            int sl = MainTextBox.SelectionLength;
            int ss = MainTextBox.SelectionStart;
            bool s = sl > 0;
            string t = s ? MainTextBox.SelectedText : MainTextBox.Text;
            
            switch (TransformationComboBox.SelectedIndex)
            {
                case 0: // Fullwidth
                    t = JapWoah.ToFullwidth(t);
                    break;
                case 1: // Shit
                    t = JapWoah.ToShit(t);
                    break;
                case 2: // Smallcaps
                    t = JapWoah.ToSmallCaps(t);
                    break;
                case 3: // Circled
                    t = JapWoah.ToCircled(t);
                    break;
                case 4: // Paratheses
                    t = JapWoah.ToParathese(t);
                    break;
                case 5: // Under-dot
                    t = JapWoah.ToUnderDot(t);
                    break;
            }

            if (s)
                MainTextBox.Text = MainTextBox.Text.Remove(ss, sl).Insert(ss, t);
            else
                MainTextBox.Text = t;
        }

        private void NormalizeButton_Click(object sender, RoutedEventArgs e)
        {
            int sl = MainTextBox.SelectionLength;
            int ss = MainTextBox.SelectionStart;
            bool s = sl > 0;
            string t = s ? MainTextBox.SelectedText : MainTextBox.Text;

            t = JapWoah.Normalize(t);

            if (s)
                MainTextBox.Text = MainTextBox.Text.Remove(ss, sl).Insert(ss, t);
            else
                MainTextBox.Text = t;
        }

        private void CopyToClipboardButton_Click(object sender, RoutedEventArgs e)
        {
            int sl = MainTextBox.SelectionLength;
            int ss = MainTextBox.SelectionStart;
            bool s = sl > 0;
            string t = s ? MainTextBox.SelectedText : MainTextBox.Text;

            Clipboard.SetText(t, TextDataFormat.UnicodeText);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            MainTextBox.Clear();
        }
    }
}

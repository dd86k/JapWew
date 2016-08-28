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

namespace JapWew
{
    /// <summary>
    /// Interaction logic for DiagnosisPage.xaml
    /// </summary>
    public partial class DiagnosisPage : Page
    {
        public DiagnosisPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.SetPageEx(Pages.Main);
        }

        void ProcessCharacter(char c)
        {
            if (c == '\0')
            { // Clear
                UnicodeNumberTextBox.Text = "U+0000";
                HtmlCodeTextBox.Text = "&#0;";
            }
            else
            {
                UnicodeNumberTextBox.Text = $"U+{(int)c:X4}";
                HtmlCodeTextBox.Text = $"&#{(int)c};";
            }
        }

        private void CharacterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProcessCharacter(
                CharacterTextBox.Text.Length > 0 ?
                CharacterTextBox.Text[0] : '\0'
            );
        }
    }
}

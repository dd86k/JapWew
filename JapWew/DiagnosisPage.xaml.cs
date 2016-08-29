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
            UnicodeNumberTextBox.Text = HtmlHelper.GetUnicodeCodePoint(c);
            HtmlCodeTextBox.Text = HtmlHelper.GetHtmlCode(c);
            HtmlCodeHexTextBox.Text = HtmlHelper.GetHtmlHexCode(c);
            DataTextBox.Text = HtmlHelper.GetData(c.ToString());
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

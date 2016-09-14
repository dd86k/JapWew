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

//TODO: Fix the stupid dock height because of the scroller

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

        void ProcessString(string c)
        {
            UnicodeNumberTextBox.Text = HtmlHelper.GetUnicodeCodePoint(c);
            HtmlCodeTextBox.Text = HtmlHelper.GetHtmlCode(c);
            HtmlCodeHexTextBox.Text = HtmlHelper.GetHtmlHexCode(c);
            Utf16leTextBox.Text = HtmlHelper.GetUtf16leData(c);
            EntityTextBox.Text =
                c.Length > 0 ?
                HtmlHelper.GetHtmlEntity(c[0]) : "--";
        }

        private void CharacterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProcessString(CharacterTextBox.Text);
        }
    }
}

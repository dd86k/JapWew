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
    /// Interaction logic for AboutPage.xaml
    /// </summary>
    public partial class AboutPage : Page
    {
        string Version =>
            System.Reflection.Assembly.GetExecutingAssembly()
            .GetName().Version.ToString();

        public AboutPage()
        {
            InitializeComponent();

            AboutTextBlock.Text =
$@"JapWew v{Version}
Unicode Text Transformer

Copyrights © DD~! 2016

JapWew is licenced with the MIT license.";
        }

        void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.ReturnToLastPage();
        }
    }
}

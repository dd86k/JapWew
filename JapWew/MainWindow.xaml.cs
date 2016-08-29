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
using MahApps.Metro.Controls;
using System.Windows.Media.Animation;
using JapWoahLib;

//TODO: Make selection clipboard shit 

namespace JapWew
{
    public enum Pages
    {
        Main,
        Settings,
        Diagnosis,
        About,
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public static MainWindow Instance { get; private set; }

        readonly Dictionary<Pages, Page> PageList;

        static Pages LastPage;

        static bool MenuIsOpen;

        public MainWindow()
        {
            InitializeComponent();

            Instance = this;

            PageList = new Dictionary<Pages, Page>();
            PageList.Add(Pages.Main, new MainPage());
            PageList.Add(Pages.Settings, new SettingsPage());
            PageList.Add(Pages.Diagnosis, new DiagnosisPage());
            PageList.Add(Pages.About, new AboutPage());
        }

        // Methods

        public static void ReturnToLastPage()
        {
            SetPageEx(LastPage);
            ShowMenuButton();
        }

        public static void SetPageEx(Pages page)
        {
            Instance.SetPage(page);
        }

        public void SetPage(Pages page)
        {
            MainFrame.Navigate(PageList[page]);

            switch (page)
            {
                case Pages.Main:
                case Pages.Diagnosis:
                    LastPage = page;
                    break;
            }
        }

        public void CloseMenu()
        {
            MenuBar.BeginStoryboard(FindResource("StoryboardMenuBarClose") as Storyboard);

            MenuIsOpen = false;
        }

        public void OpenMenu()
        {
            MenuBar.BeginStoryboard(FindResource("StoryboardMenuBarOpen") as Storyboard);

            MenuIsOpen = true;
        }

        public static void HideMenuButton()
        {
            Instance.MainMenuButton.Visibility = Visibility.Hidden;
        }

        public static void ShowMenuButton()
        {
            Instance.MainMenuButton.Visibility = Visibility.Visible;
        }

        // Window control events

        void MainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            OpenMenu();
        }

        void metroWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //TODO: Find a way to close menu anywhere on click in app
            if (MenuIsOpen && e.GetPosition(sender as IInputElement).X > MenuBar.Width)
                CloseMenu();
        }

        // Menu control events

        void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
        }

        private void MenuTransformButton_Click(object sender, RoutedEventArgs e)
        {
            SetPage(Pages.Main);

            ShowMenuButton();

            CloseMenu();
        }

        private void MenuDiagnosisButton_Click(object sender, RoutedEventArgs e)
        {
            SetPage(Pages.Diagnosis);

            ShowMenuButton();

            CloseMenu();
        }

        void MenuSettings_Click(object sender, RoutedEventArgs e)
        {
            SetPage(Pages.Settings);

            HideMenuButton();

            CloseMenu();
        }

        void MenuAbout_Click(object sender, RoutedEventArgs e)
        {
            SetPage(Pages.About);

            HideMenuButton();

            CloseMenu();
        }

        private void MenuExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

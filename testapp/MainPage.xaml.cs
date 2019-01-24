using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using testapp.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace testapp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

        }

        #region NavigationView event handlers
        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            // set the initial Page to Exercise2
            foreach (NavigationViewItemBase item in navView.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "Exercise_1")
                {
                    navView.SelectedItem = item;
                    break;
                }
            }           
            contentFrame.Navigate(typeof(Exercise2));
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {

        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            TextBlock ItemContent = args.InvokedItem as TextBlock;
            if (ItemContent != null)
            {
                switch (ItemContent.Tag)
                {
                    case "nav1":
                        contentFrame.Navigate(typeof(Exercise1));
                        break;

                    case "nav2":
                        contentFrame.Navigate(typeof(Exercise2));
                        break;

                    case "nav3":
                        contentFrame.Navigate(typeof(Exercise3));
                        break;

                    case "nav4":
                        contentFrame.Navigate(typeof(Exercise4));
                        break;

                    case "nav5":
                        contentFrame.Navigate(typeof(Exercise5));
                        break;
                    case "nav6":
                        contentFrame.Navigate(typeof(Exercise6));
                        break;
                }
            }
        }
        #endregion
    }
}

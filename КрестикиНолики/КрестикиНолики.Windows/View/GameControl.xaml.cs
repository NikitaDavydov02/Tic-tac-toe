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

// Шаблон элемента пользовательского элемента управления задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234236

namespace КрестикиНолики.View
{
    public sealed partial class GameControl : UserControl
    {
        public GameControl()
        {
            this.InitializeComponent();
        }
        public GameControl(int x, int y, int color) : this()
        {
            double X = 100 * x;
            double Y = (2 - y) * 100;
            Canvas.SetLeft(this, X);
            Canvas.SetTop(this, Y);
            if (color == 1)
            {
                NullImage.Visibility = Visibility.Collapsed;
                KrestImage.Visibility = Visibility.Visible;
            }
            else
            {
                NullImage.Visibility = Visibility.Visible;
                KrestImage.Visibility = Visibility.Collapsed;
            }
        }
    }
}

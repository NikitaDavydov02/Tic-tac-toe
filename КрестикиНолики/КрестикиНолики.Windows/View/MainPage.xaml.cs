using КрестикиНолики.Common;
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
using КрестикиНолики.ViewModel;

// Документацию по шаблону элемента "Основная страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=234237

namespace КрестикиНолики.View
{
    /// <summary>
    /// Основная страница, которая обеспечивает характеристики, являющимися общими для большинства приложений.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// Эту настройку можно изменить на модель строго типизированных представлений.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper используется на каждой странице для облегчения навигации и 
        /// управление жизненным циклом процесса
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        readonly KrestyckyNolickyViewModel viewModel;
        public MainPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
            viewModel = new KrestyckyNolickyViewModel();
            DataContext = viewModel;
        }

        /// <summary>
        /// Заполняет страницу содержимым, передаваемым в процессе навигации. Любое сохраненное состояние также является
        /// при повторном создании страницы из предыдущего сеанса.
        /// </summary>
        /// <param name="sender">
        /// Источник события; обычно <see cref="Common.NavigationHelper"/>
        /// </param>
        /// <param name="e">Данные события, предоставляющие параметр навигации, который передается
        /// <see cref="Frame.Navigate(Type, Object)"/> при первоначальном запросе этой страницы, и
        /// словарь состояния, сохраненного этой страницей в ходе предыдущего
        /// сеансом. Состояние будет равно значению NULL при первом посещении страницы.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Сохраняет состояние, связанное с данной страницей, в случае приостановки приложения или
        /// удаления страницы из кэша навигации.  Значения должны соответствовать требованиям сериализации
        /// требования <see cref="Common.SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">Источник события; обычно <see cref="Common.NavigationHelper"/></param>
        /// <param name="e">Данные события, которые предоставляют пустой словарь для заполнения
        /// сериализуемым состоянием.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region Регистрация NavigationHelper

        /// Методы, предоставленные в этом разделе, используются исключительно для того, чтобы
        /// NavigationHelper для отклика на методы навигации страницы.
        /// 
        /// Логика страницы должна быть размещена в обработчиках событий для 
        /// <see cref="Common.NavigationHelper.LoadState"/>
        /// и <see cref="Common.NavigationHelper.SaveState"/>.
        /// Параметр навигации доступен в методе LoadState 
        /// в дополнение к состоянию страницы, сохраненному в ходе предыдущего сеанса.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void Canvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Point pointerPosition = e.GetCurrentPoint(null).Position;
            double ost = pointerPosition.X % 100;
            double Xnumber = pointerPosition.X - ost;
            int XCell = Convert.ToInt32(Xnumber);

            double Yost = (300 - pointerPosition.X) % 100;
            double Ynumber = pointerPosition.X - ost;
            int YCell = Convert.ToInt32(Xnumber);
            viewModel.MakeOneMove(XCell, YCell);
        }

        private void Image_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            //Point abs = e.GetCurrentPoint(null).Position;
            //Point pointerPosition = grid.TransformToVisual(field).TransformPoint(abs);
            //double ost = pointerPosition.X % 100;
            //double Xnumber = pointerPosition.X - ost;
            //int XCell = Convert.ToInt32(Xnumber);

            //double Yost = (300 - pointerPosition.X) % 100;
            //double Ynumber = pointerPosition.X - ost;
            //int YCell = Convert.ToInt32(Xnumber);
            //iewModel.MakeOneMove(XCell, YCell);
        }

        private void first_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            viewModel.MakeOneMove(0, 2);
        }

        private void second_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            viewModel.MakeOneMove(1, 2);
        }

        private void third_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            viewModel.MakeOneMove(2, 2);
        }

        private void four_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            viewModel.MakeOneMove(0, 1);
        }

        private void five_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            viewModel.MakeOneMove(1, 1);
        }

        private void six_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            viewModel.MakeOneMove(2, 1);
        }

        private void seven_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            viewModel.MakeOneMove(0, 0);
        }

        private void eight_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            viewModel.MakeOneMove(1, 0);
        }

        private void nine_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            viewModel.MakeOneMove(2, 0);
        }
    }
}

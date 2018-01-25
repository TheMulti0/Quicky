using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using QuickyApp.ViewModels;

namespace QuickyApp.Views
{
    /// <summary>
    ///     Interaction logic for Tile.xaml
    /// </summary>
    public partial class Tile : UserControl
    {
        private Stopwatch _stopWatch;

        public static readonly DependencyProperty AccentColorProperty = DependencyProperty.Register(
            "AccentColor", typeof(Brush), typeof(Tile), new PropertyMetadata(Brushes.Black));

        public static readonly DependencyProperty PageViewModelProperty = DependencyProperty.Register(
            "PageViewModel", typeof(IPageViewModel), typeof(Tile), new PropertyMetadata(default(IPageViewModel)));

        public IPageViewModel PageViewModel
        {
            get => (IPageViewModel) GetValue(PageViewModelProperty);
            set => SetValue(PageViewModelProperty, value);
        }

        public Tile()
        {
            InitializeComponent();

            DataContext = this;

            _stopWatch = new Stopwatch();
        }

        public Brush AccentColor
        {
            get => (Brush) GetValue(AccentColorProperty);
            set => SetValue(AccentColorProperty, value);
        }

        public string Icon { get; set; }

        public string Text { get; set; }

        public string Description { get; set; }

        private void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            => _stopWatch.Restart();

        private async void OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _stopWatch.Stop();
            double time = 25000.0 / _stopWatch.ElapsedMilliseconds;

            if (time > 225.0)
            {
                time = 225.0;
            }
            await Task.Delay(TimeSpan.FromMilliseconds(time));

            var navigatorVm = (IPageNavigatorViewModel) Application.Current.MainWindow?.DataContext;
            navigatorVm?.ChangeViewModel(PageViewModel);
        }
    }
}
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
using QuickyApp.ViewModels;

namespace QuickyApp.Views
{
    /// <summary>
    /// Interaction logic for WindowButton.xaml
    /// </summary>
    public partial class WindowButton : UserControl
    {
        private readonly WindowButtonViewModel _vm;

        public string Icon { get; set; }

        public WindowButtonType ButtonType { get; set; }

        public WindowButton()
        {
            InitializeComponent();

            _vm = (WindowButtonViewModel) DataContext;
        }


        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            _vm.OverRectangleVisibility = Visibility.Visible;

            _vm.OverRectangleFill = 
                ButtonType == WindowButtonType.Close 
                ? _vm.OverRectangleCloseBrush 
                : _vm.OverRectangleLightBrush;
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            _vm.DownRectangleVisibilty = Visibility.Hidden;
            _vm.OverRectangleVisibility = Visibility.Hidden;

            if (ButtonType == WindowButtonType.Close)
            {
                _vm.IconForeground = _vm.IconBlackBrush;
            }
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            _vm.DownRectangleVisibilty = Visibility.Hidden;

            MessageBox.Show("dsa");

            if (ButtonType == WindowButtonType.Close)
            {
                _vm.DownRectangleFill = _vm.DownRectangleCloseBrush;
                _vm.IconForeground = _vm.IconWhiteBrush;
            }
            else
            {
                _vm.DownRectangleFill = _vm.DownRectangleLightBrush;
            }
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ButtonType == WindowButtonType.Close)
            {
                _vm.DownRectangleFill = _vm.DownRectangleLightBrush;
                _vm.IconForeground = _vm.IconBlackBrush;
            }
            else
            {
                _vm.DownRectangleFill = _vm.DownRectangleDarkBrush;
            }
        }
    }
}

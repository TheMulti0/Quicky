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
using EasyTranslate.Enums;
using EasyTranslate.Words;
using QuickyApp.ViewModels;

namespace QuickyApp.Views
{
    /// <summary>
    /// Interaction logic for TranslateControl.xaml
    /// </summary>
    public partial class TranslateControl : UserControl
    {
        private readonly TranslateControlViewModel _vm;

        public TranslateControl()
        {
            InitializeComponent();

            _vm = (TranslateControlViewModel) DataContext;
        }

        private async void Button_OnClick(object sender, RoutedEventArgs e)
            => _vm.FinalWord = await _vm.Operate(new TranslateWord(_vm.OriginalWord), TranslateLanguages.French);
    }
}

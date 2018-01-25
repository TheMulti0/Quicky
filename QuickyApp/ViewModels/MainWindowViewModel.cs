using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QuickyApp.Annotations;

namespace QuickyApp.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged, IPageNavigatorViewModel
    {
        private List<IPageViewModel> _pageViewModels;
        private IPageViewModel _currentPageViewModel;

        public MainWindowViewModel()
        {
            PageViewModels.Add(new HomeControlViewModel());
            PageViewModels.Add(new TranslateControlViewModel());

            CurrentPageViewModel = PageViewModels[0];
        }

        public List<IPageViewModel> PageViewModels 
            => _pageViewModels 
            ?? (_pageViewModels = new List<IPageViewModel>());

        public IPageViewModel CurrentPageViewModel
        {
            get => _currentPageViewModel;
            set
            {
                if (_currentPageViewModel == value)
                {
                    return;
                }
                _currentPageViewModel = value;
                OnPropertyChanged();
            }
        }

        public void ChangeViewModel(IPageViewModel viewModel)
        {
            if (PageViewModels.Any(vm => vm.GetType().Name != viewModel.GetType().Name))
            {
                PageViewModels.Add(viewModel);
            }

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

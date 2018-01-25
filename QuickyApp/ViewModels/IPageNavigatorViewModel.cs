using System;
using System.Collections.Generic;

namespace QuickyApp.ViewModels
{
    public interface IPageNavigatorViewModel
    {
        List<IPageViewModel> PageViewModels { get; }

        IPageViewModel CurrentPageViewModel { get; set; }

        void ChangeViewModel(IPageViewModel viewModel);
    }
}
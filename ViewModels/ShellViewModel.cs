using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;
using Services;
using Services.Navigation;

namespace ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private IPageViewModel _currentPageViewModel;
        public ShellViewModel(INavigator navigator,
            SalesViewModel salesViewModel,
            InventoryViewModel inventoryViewModel)
        {
            navigator.ChangeViewModel += NavigatorOnChangeViewModel;
            PageViewModels = new IPageViewModel[] {salesViewModel, inventoryViewModel};

            CurrentPageViewModel = PageViewModels[0];
        }

        /// <summary>
        /// The currently selected IPageViewModel
        /// </summary>
        public IPageViewModel CurrentPageViewModel
        {
            get => _currentPageViewModel;
            set
            {
                _currentPageViewModel = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// A collection of PageViewModels
        /// </summary>
        public IPageViewModel[] PageViewModels { get; }

        /// <summary>
        /// Changes the <see cref="CurrentPageViewModel"/> based on the name of the view model passed in
        /// </summary>
        /// <param name="sender">Not used. The sender of this event</param>
        /// <param name="newPageViewModelName">The name of the view model to change to</param>
        private void NavigatorOnChangeViewModel(object sender, string newPageViewModelName)
        {
            CurrentPageViewModel = PageViewModels.FirstOrDefault(x => x.Name == newPageViewModelName) ?? throw new ArgumentException($"This ViewModel {newPageViewModelName} does not exist in the {nameof(PageViewModels)} collection");
            CurrentPageViewModel.OnNavigated();
        }
    }
}

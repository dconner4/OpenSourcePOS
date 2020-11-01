using System;
using System.Linq;
using Services.Navigation;

namespace Services
{
    public class Navigator : BindableBase, INavigator
    {
        /// <inheritdoc cref="INavigator"/>
        public event EventHandler<string> ChangeViewModel;

        public void OnChangeViewModel(string viewModelName)
        {
            ChangeViewModel?.Invoke(this, viewModelName);
        }
    }
}

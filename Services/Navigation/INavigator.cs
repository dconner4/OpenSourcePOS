using System;

namespace Services.Navigation
{
    /// <summary>
    /// Interface for common navigation properties
    /// </summary>
    public interface INavigator
    {
        /// <summary>
        /// Event to change the current view model
        /// </summary>
        event EventHandler<string> ChangeViewModel;

        /// <summary>
        /// Event invoker to invoke the <see cref="ChangeViewModel"/> event
        /// </summary>
        /// <param name="viewModelName">The name of the view model to change to</param>
        void OnChangeViewModel(string viewModelName);
    }
}

using System;

namespace Services.Navigation
{
    /// <summary>
    /// Common interface for ViewModels
    /// </summary>
    public interface IPageViewModel
    {
        string Name { get; }

        void OnNavigated();
    }
}

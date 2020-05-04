using ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace OpenSourcePOS
{
    /// <summary>
    /// 
    /// </summary>
    public class ViewModelLocator
    {
        public SalesViewModel SalesViewModel => _serviceProvider.GetService(typeof(SalesViewModel)) as SalesViewModel;

        private readonly ServiceProvider _serviceProvider;

        public ViewModelLocator()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            RegisterViewModels(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceCollection"></param>
        private void RegisterViewModels(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(typeof(SalesViewModel));
        }
    }
}

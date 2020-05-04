using LocalRepository;
using LocalRepository.Context;
using LocalRepository.Interfaces;
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

        public InventoryViewModel InventoryViewModel => _serviceProvider.GetService(typeof(InventoryViewModel)) as InventoryViewModel;

        private readonly ServiceProvider _serviceProvider;

        public ViewModelLocator()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            RegisterRepositories(serviceCollection);
            RegisterViewModels(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void RegisterRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IInventoryRepository, InventoryRepository>();
        }

        private void RegisterServices()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceCollection"></param>
        private void RegisterViewModels(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(typeof(SalesViewModel));
            serviceCollection.AddSingleton(typeof(InventoryViewModel));
        }
    }
}

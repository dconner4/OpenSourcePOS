using System.IO.Ports;
using LocalRepository;
using LocalRepository.Context;
using LocalRepository.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Navigation;

namespace OpenSourcePOS
{
    /// <summary>
    /// 
    /// </summary>
    public class ViewModelLocator
    {
        public SalesViewModel SalesViewModel => _serviceProvider.GetService(typeof(SalesViewModel)) as SalesViewModel;

        public InventoryViewModel InventoryViewModel => _serviceProvider.GetService(typeof(InventoryViewModel)) as InventoryViewModel;

        public ShellViewModel ShellViewModel => _serviceProvider.GetService(typeof(ShellViewModel)) as ShellViewModel;

        private readonly ServiceProvider _serviceProvider;

        public ViewModelLocator()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            RegisterRepositories(serviceCollection);
            RegisterServices(serviceCollection);
            RegisterViewModels(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void RegisterRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IInventoryRepository, InventoryRepository>();
            serviceCollection.AddSingleton<ISalesRepository, SalesRepository>();
        }

        private void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<INavigator, Navigator>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceCollection"></param>
        private void RegisterViewModels(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(typeof(SalesViewModel));
            serviceCollection.AddSingleton(typeof(InventoryViewModel));
            serviceCollection.AddSingleton(typeof(ShellViewModel));
        }
    }
}

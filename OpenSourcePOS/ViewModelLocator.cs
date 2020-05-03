using ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace OpenSourcePOS
{
    /// <summary>
    /// 
    /// </summary>
    public class ViewModelLocator
    {
        public SalesViewModel SalesViewModel => serviceProvider.GetService(typeof(SalesViewModel)) as SalesViewModel;

        private ServiceProvider serviceProvider;

        public ViewModelLocator()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            RegisterViewModels(serviceCollection);

            serviceProvider = serviceCollection.BuildServiceProvider();
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

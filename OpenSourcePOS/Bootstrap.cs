using System.ComponentModel.Composition.Hosting;

namespace OpenSourcePOS
{
    /// <summary>
    /// 
    /// </summary>
    public class Bootstrap
    {
        private static CompositionContainer _container;

        /// <summary>
        /// 
        /// </summary>
        public static CompositionContainer Container
        {
            get
            {
                if (_container == null)
                {
                    var catalog = new AssemblyCatalog(typeof(App).Assembly);

                    _container = new CompositionContainer(catalog);
                }

                return _container;
            }
        }
    }
}

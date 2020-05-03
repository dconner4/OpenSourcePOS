using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace OpenSourcePOS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            using(LocalDatabaseContext context = new LocalDatabaseContext())
            {
                context.Database.Migrate();
            }
        }
    }
}

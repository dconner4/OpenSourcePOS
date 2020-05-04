using System;
using System.Windows;
using LocalRepository.Context;
using Microsoft.EntityFrameworkCore;
namespace OpenSourcePOS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            using (var context = new LocalDatabaseContext())
            {
                context.Database.Migrate();
            }
        }
    }
}

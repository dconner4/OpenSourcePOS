using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Services
{
    public class BindableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Checks if the property is different then updates it and invokes a <see cref="PropertyChanged"/> event if it is
        /// </summary>
        /// <typeparam name="T">The type of the caller</typeparam>
        /// <param name="storage">The stored value</param>
        /// <param name="value">The new value</param>
        /// <param name="propertyName">The name of the property (will be automatically pulled from the calling property if this is null)</param>
        /// <returns>A bool indicating whether the method completed successfully or not</returns>
        protected bool Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <inheritdoc cref="INotifyPropertyChanged"/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Invokes the <see cref="PropertyChanged"/> event and passes the property name
        /// </summary>
        /// <param name="propertyName">The name of the property this was called from</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

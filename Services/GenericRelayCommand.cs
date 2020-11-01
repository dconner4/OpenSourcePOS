using System;
using System.Windows.Input;

namespace Services
{
    /// <summary>
    /// Implementation of ICommand to handle events from View to ViewModel
    /// </summary>
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;
        
        private RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <inheritdoc cref="ICommand"/>
        public event EventHandler CanExecuteChanged;

        /// <inheritdoc cref="ICommand"/>
        /// <remarks>
        /// Defaulting to true until I can find a case to use this
        /// </remarks>
        public bool CanExecute(object parameter) => true;

        /// <summary>
        /// Parameter-less overload of <see cref="Execute(object)"/> to make method less clunky
        /// </summary>
        public void Execute() => Execute(null);
        
        /// <inheritdoc cref="ICommand"/>
        public void Execute(object parameter)
        {
            if(!(parameter is T castParam))
                throw new ArgumentException(nameof(parameter));

            if (_canExecute(castParam))
            {
                _execute((T)castParam);
            }
        }

        /// <summary>
        /// Creates a new <see cref="RelayCommand{T}"/> with the ability to pass a parameter
        /// </summary>
        /// <param name="execute">The <see cref="Action"/> to be executed when this command it ran</param>
        /// <param name="canExecute">A <see cref="Func{T, TResult}"/> to check if this command can execute when ran</param>
        /// <returns>The newly created <see cref="RelayCommand{T}"/></returns>
        public static RelayCommand<T> Create(Action<T> execute, Func<T, bool> canExecute = null) => new RelayCommand<T>(execute, canExecute);
    }
}

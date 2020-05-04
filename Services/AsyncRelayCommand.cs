using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Services
{
    /// <summary>
    /// Implementation of ICommand to handle events from View to ViewModel
    /// </summary>
    public class AsyncRelayCommand : ICommand
    {
        private Func<object, Task> _execute;
        private Func<object, bool> _canExecute;
        
        public AsyncRelayCommand(Func<Task> execute) : this(execute, () => true) { }

        public AsyncRelayCommand(Func<object, Task> execute) : this(execute, p => true) { }

        public AsyncRelayCommand(Func<Task> execute, Func<bool> canExecute = null)
        {
            _execute = _ => execute();
            _canExecute = _ => canExecute?.Invoke() ?? true;
        }

        public AsyncRelayCommand(Func<object, Task> execute, Func<object, bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <inheritdoc cref="ICommand"/>
        public event EventHandler CanExecuteChanged;

        /// <inheritdoc cref="ICommand"/>
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        /// <summary>
        /// Parameter-less overload of <see cref="Execute(object)"/> to make method less clunky
        /// </summary>
        public void Execute() => Execute(null);
        
        /// <inheritdoc cref="ICommand"/>
        public async void Execute(object parameter)
        {
            if (_canExecute(null))
            {
                await _execute(parameter);
            }
        }
    }
}

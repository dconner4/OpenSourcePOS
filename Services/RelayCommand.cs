using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Services
{
    /// <summary>
    /// Implementation of ICommand to handle events from View to ViewModel
    /// </summary>
    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public RelayCommand(Action execute) : this(execute, () => true) { }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = _ => execute();
            _canExecute = _ => canExecute?.Invoke() ?? true;
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <inheritdoc cref="ICommand"/>
        public event EventHandler CanExecuteChanged;

        /// <inheritdoc cref="ICommand"/>
        public bool CanExecute(object parameter) => true;

        /// <summary>
        /// Parameter-less overload of <see cref="Execute(object)"/> to make method less clunky
        /// </summary>
        public void Execute() => Execute(null);
        
        /// <inheritdoc cref="ICommand"/>
        public void Execute(object parameter)
        {
            if (_canExecute(parameter))
            {
                _execute(parameter);
            }
        }
    }
}

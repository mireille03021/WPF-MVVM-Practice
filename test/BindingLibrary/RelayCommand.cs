using System;
using System.Windows.Input;

namespace BindingLibrary
{
    public class RelayCommand : ICommand
    {
        private Action<object> _execteMethod;
        private Func<object, bool> _canexecuteMethod;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> execteMethod, Func<object, bool> canexecuteMethod)
        {
            _execteMethod = execteMethod;
            _canexecuteMethod = canexecuteMethod;
        }

        public RelayCommand(Action<object> execute) : this(execute,(x) => true) { }

        public bool CanExecute(object parameter)
        {
            return _canexecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            _execteMethod(parameter);
        }
    }
}

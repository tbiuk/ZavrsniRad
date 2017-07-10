using System;
using System.Windows.Input;

namespace BusinessLogicLayer
{
    public class RelayCommandWithParameter : ICommand
    {

        private Action<object> _action;

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public RelayCommandWithParameter(Action<object> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
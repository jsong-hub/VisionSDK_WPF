using System;
using System.Windows.Input;

namespace VisionSDK_WPF.Common
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;
        
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action<object> execute) : this(execute, null)
        {
        }

        private RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }


        public bool CanExecute(object o)
        {
            if (this._canExecute == null)
            {
                return true;
            }

            return this._canExecute(o);
        }

        public void Execute(object o)
        {
            this._execute(o);
        }
    }
}
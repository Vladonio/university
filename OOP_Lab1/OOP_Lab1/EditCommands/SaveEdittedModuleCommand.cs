using OOP_Lab1.Models;
using System;
using System.Windows.Input;

namespace OOP_Lab1.EditCommands
{
    public class SaveEdittedModuleCommand<T> : ICommand where T : ICopied<T>
    {
        private T target;
        private T source;

        public event EventHandler CanExecuteChanged;

        public SaveEdittedModuleCommand(T target, T source)
        {
            this.target = target;
            this.source = source;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            source.CopyTo(target);
        }
    }
}

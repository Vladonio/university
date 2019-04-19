using OOP_Lab1.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace OOP_Lab1.EditCommands
{
    public class AddNewModuleCommand : ICommand
    {
        private IList<Module> modules;
        private Module newModule;

        public event EventHandler CanExecuteChanged;

        public AddNewModuleCommand(IList<Module> modules, Module module)
        {
            newModule = module;
            this.modules = modules;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            modules.Add(newModule);
        }
    }
}

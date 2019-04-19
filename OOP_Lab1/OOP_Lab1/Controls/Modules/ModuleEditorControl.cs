using System;
using System.Windows.Controls;

namespace OOP_Lab1.Controls.Modules
{
    public class ModuleEditorControl : UserControl
    {
        protected Action actions = () => { };

        public void AddOnSaveAction(Action action)
        {
            actions += action;
        }
    }
}

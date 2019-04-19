using OOP_Lab1.Controls.Modules;
using OOP_Lab1.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace OOP_Lab1.EditorFactories
{
    public interface IModuleEditorFactory
    {
        string ModuleName { get; }

        ModuleEditorControl CreateNewEditor(IList<Module> modules);

        ModuleEditorControl CreateEditor(Module module);

        bool IsValidModule(Module module);
    }
}

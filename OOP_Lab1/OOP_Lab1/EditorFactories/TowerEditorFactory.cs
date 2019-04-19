using OOP_Lab1.Controls.Modules;
using OOP_Lab1.EditCommands;
using OOP_Lab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab1.EditorFactories
{
    class TowerEditorFactory : IModuleEditorFactory
    {
        public string ModuleName => "Tower";

        public ModuleEditorControl CreateEditor(Module module)
        {
            if (!IsValidModule(module))
            {
                throw new ArgumentException("Invalid module");
            }

            var editor = new TowerEditor();

            Tower targetTower = module as Tower;

            editor.Tower = targetTower;
            editor.SaveCommand = new SaveEdittedModuleCommand<Tower>(targetTower, editor.ModifiedTower);

            return editor;
        }

        public ModuleEditorControl CreateNewEditor(IList<Module> modules)
        {
            var editor = new TowerEditor();

            editor.SaveCommand = new AddNewModuleCommand(modules, editor.ModifiedTower);

            return editor;
        }

        public bool IsValidModule(Module module)
        {
            return module.GetType() == typeof(Tower);
        }
    }
}

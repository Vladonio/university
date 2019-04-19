using OOP_Lab1.Controls.Modules;
using OOP_Lab1.EditCommands;
using OOP_Lab1.Models;
using System;
using System.Collections.Generic;

namespace OOP_Lab1.EditorFactories
{
    class GunEditorFactory : IModuleEditorFactory
    {
        public string ModuleName => "Gun";

        public ModuleEditorControl CreateEditor(Module module)
        {
            if (!IsValidModule(module))
            {
                throw new ArgumentException("Invalid module");
            }

            var editor = new GunEditor();

            Gun targetGun = module as Gun;

            editor.Gun = targetGun;
            editor.SaveCommand = new SaveEdittedModuleCommand<Gun>(targetGun, editor.ModifiedGun);

            return editor;
        }

        public ModuleEditorControl CreateNewEditor(IList<Module> modules)
        {
            var editor = new GunEditor();

            editor.SaveCommand = new AddNewModuleCommand(modules, editor.ModifiedGun);

            return editor;
        }

        public bool IsValidModule(Module module)
        {
            return module.GetType() == typeof(Gun);
        }
    }
}

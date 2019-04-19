using System;
using System.Collections.Generic;
using OOP_Lab1.Controls.Modules;
using OOP_Lab1.EditCommands;
using OOP_Lab1.Models;

namespace OOP_Lab1.EditorFactories
{
    public class EngineEditorFactory : IModuleEditorFactory
    {
        public string ModuleName => "Engine";

        public ModuleEditorControl CreateEditor(Module module)
        {
            if (!IsValidModule(module))
            {
                throw new ArgumentException("Invalid module");
            }

            var editor = new EngineEditor();

            Engine targetEngine = module as Engine;

            editor.Engine = targetEngine;
            editor.SaveCommand = new SaveEdittedModuleCommand<Engine>(targetEngine, editor.ModifiedEngine);

            return editor;
        }

        public ModuleEditorControl CreateNewEditor(IList<Module> modules)
        {
            var editor = new EngineEditor();

            editor.SaveCommand = new AddNewModuleCommand(modules, editor.ModifiedEngine);

            return editor;
        }

        public bool IsValidModule(Module module)
        {
            return module.GetType() == typeof(Engine);
        }
    }
}

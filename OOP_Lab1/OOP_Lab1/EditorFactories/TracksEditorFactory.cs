using OOP_Lab1.Controls.Modules;
using OOP_Lab1.EditCommands;
using OOP_Lab1.Models;
using System;
using System.Collections.Generic;

namespace OOP_Lab1.EditorFactories
{
    class TracksEditorFactory : IModuleEditorFactory
    {
        public string ModuleName => "Tracks";

        public ModuleEditorControl CreateEditor(Module module)
        {
            if (!IsValidModule(module))
            {
                throw new ArgumentException("Invalid module");
            }

            var editor = new TracksEditor();

            Tracks targetTracks = module as Tracks;

            editor.Tracks = targetTracks;
            editor.SaveCommand = new SaveEdittedModuleCommand<Tracks>(targetTracks, editor.ModifiedTracks);

            return editor;
        }

        public ModuleEditorControl CreateNewEditor(IList<Module> modules)
        {
            var editor = new TracksEditor();

            editor.SaveCommand = new AddNewModuleCommand(modules, editor.ModifiedTracks);

            return editor;
        }

        public bool IsValidModule(Module module)
        {
            return module.GetType() == typeof(Tracks);
        }
    }
}

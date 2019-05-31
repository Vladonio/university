using OOP_Lab1.Controls.Modules;
using OOP_Lab1.EditorFactories;
using OOP_Lab1.Models;
using OOP_Lab1.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Newtonsoft.Json;
using System.IO;
using OOP_Lab1.Serializers;
using System.Runtime.Serialization.Formatters.Binary;
using Polenter.Serialization;

namespace OOP_Lab1.ViewModels
{
    public class ModulesTabViewModel
    {
        public ObservableCollection<Module> Modules { get; set; }



        public IModuleEditorFactory SelectedFactory { get; set; }

        public List<IModuleEditorFactory> ModuleEditorFactories { get; }

        public ICommand OpenNewModuleEditor { get; }


        public Module SelectedModule { get; set; }

        public ICommand OpenModuleEditor { get; }

        public ICommand DeleteModule { get; }

        public ModulesTabViewModel()
        {
            Modules = new ObservableCollection<Module>();
            Modules.Add(new Engine() { Name = "Engine1", Power = 100, Vulnerability = "50" });
            Modules.Add(new Tracks() { Name = "Track1", WeightCapacity = 60, Vulnerability = "50" });
            Modules.Add(new Tracks() { Name = "Tracks", WeightCapacity = 75, Vulnerability = "60" });
            Modules.Add(new Gun() { Name = "Gun", Caliber = 122, Rapidity = 15, Vulnerability = "40" });
            Modules.Add(new Tower() { Name = "Tower", TurningSpeed = 45, Vulnerability = "50" });

            OpenNewModuleEditor = new OpenNewModuleEditorCommand(this);
            OpenModuleEditor = new OpenEditorCommand(this);
            DeleteModule = new DeleteModuleCommand(this);

            ModuleEditorFactories = new List<IModuleEditorFactory>()
            {
                new EngineEditorFactory(),
                new GunEditorFactory(),
                new TowerEditorFactory(),
                new TracksEditorFactory(),
            };
        }

        private class OpenNewModuleEditorCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private ModulesTabViewModel modulesTab;

            public OpenNewModuleEditorCommand(ModulesTabViewModel modulesTab)
            {
                this.modulesTab = modulesTab;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                ModuleEditorControl editor = modulesTab.SelectedFactory.CreateNewEditor(modulesTab.Modules);

                ModulesEditor editorWindow = new ModulesEditor(editor);

                editor.AddOnSaveAction(() => editorWindow.Close());

                editorWindow.ShowDialog();
            }
        }

        private class OpenEditorCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private ModulesTabViewModel modulesTab;

            public OpenEditorCommand(ModulesTabViewModel modulesTab)
            {
                this.modulesTab = modulesTab;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                try
                {
                    ModuleEditorControl editor = modulesTab.ModuleEditorFactories.First(f => f.IsValidModule(modulesTab.SelectedModule))
                        .CreateEditor(modulesTab.SelectedModule);

                    ModulesEditor editorWindow = new ModulesEditor(editor);

                    editor.AddOnSaveAction(() => editorWindow.Close());

                    editorWindow.ShowDialog();
                }
                catch
                {
                }
            }
        }

        private class DeleteModuleCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private ModulesTabViewModel modulesTab;

            public DeleteModuleCommand(ModulesTabViewModel modulesTab)
            {
                this.modulesTab = modulesTab;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                modulesTab.Modules.Remove(modulesTab.SelectedModule);
            }
        }
    }
}

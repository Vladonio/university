using OOP_Lab1.Models;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace OOP_Lab1.Controls.Modules
{
    /// <summary>
    /// Interaction logic for EngineEditor.xaml
    /// </summary>
    public partial class EngineEditor : ModuleEditorControl, INotifyPropertyChanged
    {
        private Engine modifiedEngine;

        public Engine ModifiedEngine
        {
            get { return modifiedEngine; }
            set
            {
                modifiedEngine = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ModifiedEngine)));
            }
        }

        private static DependencyProperty engineDependencyProperty = DependencyProperty.Register("Engine", typeof(Engine), typeof(EngineEditor));

        private static DependencyProperty saveDependencyProperty = DependencyProperty.Register("SaveCommand", typeof(ICommand), typeof(EngineEditor));

        public event PropertyChangedEventHandler PropertyChanged;

        public Engine Engine
        {
            get { return (Engine)GetValue(engineDependencyProperty); }
            set
            {
                SetValue(engineDependencyProperty, value);

                Engine.CopyTo(ModifiedEngine);
            }
        }

        public ICommand SaveCommand
        {
            get { return (ICommand)GetValue(saveDependencyProperty); }
            set { SetValue(saveDependencyProperty, value); }
        }

        public EngineEditor()
        {
            InitializeComponent();

            ModifiedEngine = new Engine();

            mainGrid.DataContext = ModifiedEngine;

            Save.Click += Save_Click;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            actions();
        }
    }
}

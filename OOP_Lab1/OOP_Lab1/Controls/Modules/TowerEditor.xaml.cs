using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using OOP_Lab1.Models;

namespace OOP_Lab1.Controls.Modules
{
    /// <summary>
    /// Interaction logic for TowerEditor.xaml
    /// </summary>
    public partial class TowerEditor : ModuleEditorControl, INotifyPropertyChanged
    {
        private Tower modifiedTower;

        public Tower ModifiedTower
        {
            get { return modifiedTower; }
            set
            {
                modifiedTower = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ModifiedTower)));
            }
        }

        private static DependencyProperty towerDependencyProperty = DependencyProperty.Register("Tower", typeof(Tower), typeof(TowerEditor));

        private static DependencyProperty saveDependencyProperty = DependencyProperty.Register("SaveCommand", typeof(ICommand), typeof(TowerEditor));

        public event PropertyChangedEventHandler PropertyChanged;

        public Tower Tower
        {
            get { return (Tower)GetValue(towerDependencyProperty); }
            set
            {
                SetValue(towerDependencyProperty, value);

                Tower.CopyTo(ModifiedTower);
            }
        }

        public ICommand SaveCommand
        {
            get { return (ICommand)GetValue(saveDependencyProperty); }
            set { SetValue(saveDependencyProperty, value); }
        }

        public TowerEditor()
        {
            InitializeComponent();

            ModifiedTower = new Tower();

            mainGrid.DataContext = ModifiedTower;
            Save.Click += Save_Click;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            actions();
        }
    }
}

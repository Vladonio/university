using OOP_Lab1.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OOP_Lab1.Controls.Vehicles
{
    /// <summary>
    /// Interaction logic for TowerTankEditor.xaml
    /// </summary>
    public partial class TowerTankEditor : VehicleEditorControl
    {
        private TowerTank modifiedTowerTank;

        public TowerTank ModifiedTowerTank
        {
            get { return modifiedTowerTank; }
            set
            {
                modifiedTowerTank = value;
                RaisePropertyChanged(nameof(ModifiedTowerTank));
            }
        }

        private static DependencyProperty towerTankDependencyProperty = DependencyProperty.Register("TowerTank", typeof(TowerTank), typeof(TowerTankEditor));

        private static DependencyProperty saveDependencyProperty = DependencyProperty.Register("SaveCommand", typeof(ICommand), typeof(TowerTankEditor));


        public TowerTank TowerTank
        {
            get { return (TowerTank)GetValue(towerTankDependencyProperty); }
            set
            {
                SetValue(towerTankDependencyProperty, value);

                TowerTank.CopyTo(ModifiedTowerTank);
            }
        }

        public ICommand SaveCommand
        {
            get { return (ICommand)GetValue(saveDependencyProperty); }
            set { SetValue(saveDependencyProperty, value); }
        }

        public TowerTankEditor()
        {
            InitializeComponent();

            ModifiedTowerTank = new TowerTank();

            mainGrid.DataContext = ModifiedTowerTank;

            Save.Click += Save_Click;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            actions();
        }
    }
}

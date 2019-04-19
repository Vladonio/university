using OOP_Lab1.Models;
using System.Windows;
using System.Windows.Input;

namespace OOP_Lab1.Controls.Vehicles
{
    /// <summary>
    /// Interaction logic for CivilianVehicleEditor.xaml
    /// </summary>
    public partial class CivilianVehicleEditor : VehicleEditorControl
    {
        private CivilianVehicle modifiedCivilianVehicle;

        public CivilianVehicle ModifiedCivilianVehicle
        {
            get { return modifiedCivilianVehicle; }
            set
            {
                modifiedCivilianVehicle = value;
                RaisePropertyChanged(nameof(ModifiedCivilianVehicle));
            }
        }

        private static DependencyProperty civilianVehicleDependencyProperty = DependencyProperty.Register("CivilianVehicle", typeof(CivilianVehicle), typeof(CivilianVehicleEditor));

        private static DependencyProperty saveDependencyProperty = DependencyProperty.Register("SaveCommand", typeof(ICommand), typeof(CivilianVehicleEditor));


        public CivilianVehicle CivilianVehicle
        {
            get { return (CivilianVehicle)GetValue(civilianVehicleDependencyProperty); }
            set
            {
                SetValue(civilianVehicleDependencyProperty, value);

                CivilianVehicle.CopyTo(ModifiedCivilianVehicle);
            }
        }

        public ICommand SaveCommand
        {
            get { return (ICommand)GetValue(saveDependencyProperty); }
            set { SetValue(saveDependencyProperty, value); }
        }

        public CivilianVehicleEditor()
        {
            InitializeComponent();

            ModifiedCivilianVehicle = new CivilianVehicle();

            mainGrid.DataContext = ModifiedCivilianVehicle;

            Save.Click += Save_Click;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            actions();
        }
    }
}

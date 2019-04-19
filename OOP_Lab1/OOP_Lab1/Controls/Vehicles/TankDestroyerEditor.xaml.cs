using OOP_Lab1.Models;
using System.Windows;
using System.Windows.Input;

namespace OOP_Lab1.Controls.Vehicles
{
    /// <summary>
    /// Interaction logic for TankDestroyerEditor.xaml
    /// </summary>
    public partial class TankDestroyerEditor : VehicleEditorControl
    {
        private TankDestroyer modifiedTankDestroyer;

        public TankDestroyer ModifiedTankDestroyer
        {
            get { return modifiedTankDestroyer; }
            set
            {
                modifiedTankDestroyer = value;
                RaisePropertyChanged(nameof(ModifiedTankDestroyer));
            }
        }

        private static DependencyProperty tankDestroyerDependencyProperty = DependencyProperty.Register("TankDestroyer", typeof(TankDestroyer), typeof(TankDestroyerEditor));

        private static DependencyProperty saveDependencyProperty = DependencyProperty.Register("SaveCommand", typeof(ICommand), typeof(TankDestroyerEditor));


        public TankDestroyer TankDestroyer
        {
            get { return (TankDestroyer)GetValue(tankDestroyerDependencyProperty); }
            set
            {
                SetValue(tankDestroyerDependencyProperty, value);

                TankDestroyer.CopyTo(ModifiedTankDestroyer);
            }
        }

        public ICommand SaveCommand
        {
            get { return (ICommand)GetValue(saveDependencyProperty); }
            set { SetValue(saveDependencyProperty, value); }
        }

        public TankDestroyerEditor()
        {
            InitializeComponent();

            ModifiedTankDestroyer = new TankDestroyer();

            mainGrid.DataContext = ModifiedTankDestroyer;

            Save.Click += Save_Click;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            actions();
        }
    }
}

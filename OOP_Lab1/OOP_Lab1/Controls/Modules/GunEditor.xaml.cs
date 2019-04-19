using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using OOP_Lab1.Models;

namespace OOP_Lab1.Controls.Modules
{
    /// <summary>
    /// Interaction logic for GunEditor.xaml
    /// </summary>
    public partial class GunEditor : ModuleEditorControl, INotifyPropertyChanged
    {
        private Gun modifiedGun;

        public Gun ModifiedGun
        {
            get { return modifiedGun; }
            set
            {
                modifiedGun = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ModifiedGun)));
            }
        }

        private static DependencyProperty gunDependencyProperty = DependencyProperty.Register("Gun", typeof(Gun), typeof(GunEditor));

        private static DependencyProperty saveDependencyProperty = DependencyProperty.Register("SaveCommand", typeof(ICommand), typeof(GunEditor));

        public event PropertyChangedEventHandler PropertyChanged;

        public Gun Gun
        {
            get { return (Gun)GetValue(gunDependencyProperty); }
            set
            {
                SetValue(gunDependencyProperty, value);

                Gun.CopyTo(ModifiedGun);
            }
        }

        public ICommand SaveCommand
        {
            get { return (ICommand)GetValue(saveDependencyProperty); }
            set { SetValue(saveDependencyProperty, value); }
        }

        public GunEditor()
        {
            InitializeComponent();

            ModifiedGun = new Gun();

            mainGrid.DataContext = ModifiedGun;

            Save.Click += Save_Click;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            actions();
        }
    }
}

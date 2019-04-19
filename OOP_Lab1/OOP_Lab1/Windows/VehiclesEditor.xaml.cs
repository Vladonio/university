using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OOP_Lab1.Windows
{
    /// <summary>
    /// Interaction logic for VehiclesEditor.xaml
    /// </summary>
    public partial class VehiclesEditor : Window
    {
        public VehiclesEditor(UserControl vehicleEditor)
        {
            InitializeComponent();

            MainWindow.Children.Add(vehicleEditor);
        }
    }
}

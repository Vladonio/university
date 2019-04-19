using System.Windows;
using System.Windows.Controls;

namespace OOP_Lab1.Windows
{
    /// <summary>
    /// Interaction logic for ModulesEditor.xaml
    /// </summary>
    public partial class ModulesEditor : Window
    {
        public ModulesEditor(UserControl moduleEditor)
        {
            InitializeComponent();

            //moduleEditor

            MainWindow.Children.Add(moduleEditor);
        }
    }
}

using Microsoft.Win32;
using OOP_Lab1.Models;
using OOP_Lab1.Serializers;
using OOP_Lab1.Serializers.Custom;
using OOP_Lab1.ViewModels;
using OOP_Lab1.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using PluginFramework;

namespace OOP_Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string pluginPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Plugins");

        Dictionary<string, IPlugin> Plugins = new Dictionary<string, IPlugin>();

        private AppViewModel appViewModel;

        private List<ISerializers> Serializers { get; }

        private ISerializers SelectedSerializer { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();


            Serializers = new List<ISerializers>
            {
                new JsonSerialize(),
                new BinarySerializer(),
                new CustomSerializer()
            };

            DataContext = appViewModel = new AppViewModel();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Tab1Add_Click(object sender, RoutedEventArgs e)
        {

            
        }

        private void Serialize_Click(object sender, RoutedEventArgs e)
        {
            AllModels allModels = new AllModels(appViewModel.ModulesTab.Modules, appViewModel.VehiclesTab.Vehicles);

            string fileName = "";
            string fileExtension = "";//StringBuilder
            string filter = string.Join("|", Serializers.Select(x => x.Format));

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = filter;
            if (saveFileDialog.ShowDialog() == true)
                fileName = saveFileDialog.FileName;
            //fileName = System.IO.Path.GetFileName(fileName);
            fileExtension = System.IO.Path.GetExtension(fileName);


            //CivilianVehicle testVehicle = new CivilianVehicle()
            //{
            //    Engine = new Engine()
            //    {
            //        Name = "Engine1",
            //        Power = 100,
            //        Vulnerability = "Good"
            //    },
            //    Name = "Civilian",
            //    Price = 200,
            //    SeatsCount = 3,
            //    Weight = "Big",
            //    Tracks = new Tracks()
            //    {
            //        Name = "Tracks1",
            //        Vulnerability = "Bad",
            //        WeightCapacity = 300
            //    }
            //};



            foreach (ISerializers serializer in Serializers)
            {
                string serializerExtension = serializer.Format.Substring(serializer.Format.LastIndexOf('.'), serializer.Format.Length - serializer.Format.LastIndexOf('.'));

                if (serializerExtension == fileExtension)
                {
                    SelectedSerializer = serializer;
                    SelectedSerializer.SerializeObject(allModels, fileName);
                    break;
                }
            }

            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);


                foreach (var plugin in Plugins)
                {
                    if (comboBoxPlugins.SelectedItem == plugin.Key)
                    {
                        plugin.Value.Archive(file);
                        file.Close();
                        File.Delete(fileName);
                    }
                }
            }
            catch
            { }

        }



        private void DeSerialize_Click(object sender, RoutedEventArgs e)
        {
            string fileName = "";
            string fileExtension = "";
            AllModels newObject = new AllModels(null, null);


            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                fileName = openFileDialog.FileName;
            fileExtension = System.IO.Path.GetExtension(fileName);

            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);

            foreach (var plugin in Plugins)
            {
                if (fileExtension.Substring(1, fileExtension.Length - 1) == plugin.Key.ToLower())
                {
                    file = plugin.Value.DeArchive(file, ref fileExtension);
                }
            }


            foreach (ISerializers serializer in Serializers)
            {
                string serializerExtension = serializer.Format.Substring(serializer.Format.LastIndexOf('.'), serializer.Format.Length - serializer.Format.LastIndexOf('.'));

                if (serializerExtension == fileExtension)
                {
                    SelectedSerializer = serializer;
                    newObject = SelectedSerializer.DeSeriazlixeObject(file) as AllModels;
                    break;
                }
            }

            try
            {
                var modulesCount = newObject.MyModules.Count;
                var vehiclesCount = newObject.MyVehicles.Count;
                for (int i = 0; i < modulesCount; i++)
                {
                    appViewModel.ModulesTab.Modules.Add(newObject.MyModules[i]);
                }
                for (int i = 0; i < vehiclesCount; i++)
                {
                    appViewModel.VehiclesTab.Vehicles.Add(newObject.MyVehicles[i]);
                }
            }
            catch
            {
                
            }

            file.Close();
            if (file.Name != fileName)
            {
                File.Delete(file.Name);
            }
        }


        void LoadPlugins(string folder)
        {
            Plugins.Clear();
            foreach (var dll in Directory.GetFiles(folder, "*.dll"))
            {
                try
                {
                    var assembly = Assembly.LoadFrom(dll);
                    foreach (var type in assembly.GetTypes())
                    {
                        if (type.GetInterface("IPlugin") == typeof(IPlugin))
                        {
                            var plugin = Activator.CreateInstance(type) as IPlugin;
                            Plugins[plugin.Name] = plugin;
                        }
                    }
                }
                catch
                { }
            }
        }

        private void AddPlugins_Click(object sender, RoutedEventArgs e)
        {
            if (Plugins.Count == 0)
            {
                LoadPlugins(pluginPath);
                foreach (var plugin in Plugins)
                {
                    var kek = plugin.ToString();
                    comboBoxPlugins.Items.Add(plugin.Key);
                }
            }
        }
    }

}

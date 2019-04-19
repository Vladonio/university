using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using OOP_Lab1.Models;

namespace OOP_Lab1.Controls.Modules
{
    /// <summary>
    /// Interaction logic for TracksEditor.xaml
    /// </summary>
    public partial class TracksEditor : ModuleEditorControl
    {
        private Tracks modifiedTracks;

        public Tracks ModifiedTracks
        {
            get { return modifiedTracks; }
            set
            {
                modifiedTracks = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ModifiedTracks)));
            }
        }

        private static DependencyProperty tracksDependencyProperty = DependencyProperty.Register("Tracks", typeof(Tracks), typeof(TracksEditor));

        private static DependencyProperty saveDependencyProperty = DependencyProperty.Register("SaveCommand", typeof(ICommand), typeof(TracksEditor));

        public event PropertyChangedEventHandler PropertyChanged;

        public Tracks Tracks
        {
            get { return (Tracks)GetValue(tracksDependencyProperty); }
            set
            {
                SetValue(tracksDependencyProperty, value);

                Tracks tracks = Tracks;

                Tracks.CopyTo(ModifiedTracks);
            }
        }


        public ICommand SaveCommand
        {
            get { return (ICommand)GetValue(saveDependencyProperty); }
            set { SetValue(saveDependencyProperty, value); }
        }

        public TracksEditor()
        {
            InitializeComponent();

            modifiedTracks = new Tracks();

            mainGrid.DataContext = modifiedTracks;
            Save.Click += Save_Click;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            actions();
        }
    }
}

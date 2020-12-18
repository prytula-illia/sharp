using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TryingWpfMvvm.ViewModel;

namespace TryingWpfMvvm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            Loaded += MainWindow_Loaded;

            MakeNewOrderButton.BeginAnimation(WidthProperty, new DoubleAnimation() { From = MakeNewOrderButton.ActualWidth, To = 500, Duration = TimeSpan.FromSeconds(10) });
       
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            new SoundPlayer
                (
                    Assembly.GetExecutingAssembly().GetManifestResourceStream("TryingWpfMvvm.Media.music.wav")
                ).Play();
        }
    }
}

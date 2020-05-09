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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ControlFreak.Gui.ViewModels;
using ControlFreak.Gui.ViewModels.Plugins;
using DynamicData;
using NodeNetwork.ViewModels;

namespace ControlFreak.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Create a new viewmodel for the NetworkView
            var network = new NetworkViewModel();

            var btb = new AxisSummer();
            network.Nodes.Add(btb);

            //Assign the viewmodel to the view.
            networkView.ViewModel = network;
        }
    }
}

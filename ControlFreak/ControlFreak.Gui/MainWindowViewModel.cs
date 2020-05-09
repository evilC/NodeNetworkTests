using System.Linq;
using System.Windows;
using ControlFreak.Gui.IONodes.AxisInput;
using ControlFreak.Gui.IONodes.AxisOutput;
using ControlFreak.Gui.IONodes.ButtonInput;
using ControlFreak.Gui.IONodes.ButtonOutput;
using ControlFreak.Gui.Plugins;
using ControlFreak.Gui.Plugins.ButtonsToAxis;
using DynamicData;
using NodeNetwork;
using NodeNetwork.Toolkit;
using NodeNetwork.Toolkit.NodeList;
using NodeNetwork.ViewModels;
using ReactiveUI;

namespace ControlFreak.Gui
{
    public class MainWindowViewModel : ReactiveObject
    {
        static MainWindowViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new MainWindowView(), typeof(IViewFor<MainWindowViewModel>));
        }

        public NodeListViewModel ListViewModel { get; } = new NodeListViewModel();
        public NetworkViewModel NetworkViewModel { get; } = new NetworkViewModel();

        public MainWindowViewModel()
        {
            // IONodes
            ListViewModel.AddNodeType(() => new AxisInputViewModel());
            ListViewModel.AddNodeType(() => new AxisOutputViewModel());
            ListViewModel.AddNodeType(() => new ButtonInputViewModel());
            ListViewModel.AddNodeType(() => new ButtonOutputNode());

            // Plugins
            ListViewModel.AddNodeType(() => new AxisSummerViewModel());
            ListViewModel.AddNodeType(() => new ButtonsToAxisViewModel());

            var startingPoint = new Point(100, 100);

            var inputButton1 = new ButtonInputViewModel();
            NetworkViewModel.Nodes.Add(inputButton1);
            inputButton1.Position = startingPoint;

            var inputButton2 = new ButtonInputViewModel();
            NetworkViewModel.Nodes.Add(inputButton2);
            inputButton2.Position = new Point(startingPoint.X, startingPoint.Y + 150);

            var bToA = new ButtonsToAxisViewModel();
            NetworkViewModel.Nodes.Add(bToA);
            bToA.Position = startingPoint;
            bToA.Position = new Point(startingPoint.X + 250, startingPoint.Y + 50);

            var axisOutput = new AxisOutputViewModel();
            NetworkViewModel.Nodes.Add(axisOutput);
            axisOutput.Position = new Point(startingPoint.X + 500, startingPoint.Y + 100);

            NetworkViewModel.Connections.Add(NetworkViewModel.ConnectionFactory(axisOutput.Input, bToA.Output));
            NetworkViewModel.Connections.Add(NetworkViewModel.ConnectionFactory(bToA.InputLow, inputButton1.Output));
            NetworkViewModel.Connections.Add(NetworkViewModel.ConnectionFactory(bToA.InputHigh, inputButton2.Output));

            inputButton1.ValueEditor.Value = false;
            inputButton2.ValueEditor.Value = false;

            NetworkViewModel.Validator = network =>
            {
                var containsLoops = GraphAlgorithms.FindLoops(network).Any();
                if (containsLoops)
                {
                    return new NetworkValidationResult(false, false, new ErrorMessageViewModel("Network contains loops!"));
                }

                return new NetworkValidationResult(true, true, null);
            };
        }
    }

}

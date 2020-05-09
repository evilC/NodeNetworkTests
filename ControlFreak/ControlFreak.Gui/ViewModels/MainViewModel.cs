using System.Linq;
using System.Reactive.Linq;
using System.Windows;
using ControlFreak.Gui.IONodes.AxisOutput;
using ControlFreak.Gui.IONodes.ButtonOutput;
using ControlFreak.Gui.ViewModels.Plugins;
using DynamicData;
using NodeNetwork;
using NodeNetwork.Toolkit;
using NodeNetwork.Toolkit.NodeList;
using NodeNetwork.ViewModels;
using ReactiveUI;

namespace ControlFreak.Gui.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        static MainViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new MainWindow(), typeof(IViewFor<MainViewModel>));
        }

        public NodeListViewModel ListViewModel { get; } = new NodeListViewModel();
        public NetworkViewModel NetworkViewModel { get; } = new NetworkViewModel();

        public MainViewModel()
        {
            ListViewModel.AddNodeType(() => new AxisSummerViewModel());
            ListViewModel.AddNodeType(() => new FakeAxisInputViewModel());
            ListViewModel.AddNodeType(() => new AxisOutputNode());
            ListViewModel.AddNodeType(() => new ButtonOutputNode());

            var startingPoint = new Point(100, 100);

            var input1 = new FakeAxisInputViewModel();
            NetworkViewModel.Nodes.Add(input1);
            input1.Position = startingPoint;

            var input2 = new FakeAxisInputViewModel();
            NetworkViewModel.Nodes.Add(input2);
            input2.Position = new Point(startingPoint.X, startingPoint.Y + 150);

            var sum = new AxisSummerViewModel();
            NetworkViewModel.Nodes.Add(sum);
            sum.Position = startingPoint;
            sum.Position = new Point(startingPoint.X + 250, startingPoint.Y + 50);

            var axisOutput = new AxisOutputNode();
            NetworkViewModel.Nodes.Add(axisOutput);
            axisOutput.Position = new Point(startingPoint.X + 500, startingPoint.Y + 100);

            NetworkViewModel.Connections.Add(NetworkViewModel.ConnectionFactory(axisOutput.Input, sum.Output));
            NetworkViewModel.Connections.Add(NetworkViewModel.ConnectionFactory(sum.Input1, input1.Output));
            NetworkViewModel.Connections.Add(NetworkViewModel.ConnectionFactory(sum.Input2, input2.Output));

            input1.ValueEditor.Value = 123;
            input2.ValueEditor.Value = 456;

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

using System.Linq;
using System.Windows;
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

        #region ValueLabel
        private string _valueLabel;
        public string ValueLabel
        {
            get => _valueLabel;
            set => this.RaiseAndSetIfChanged(ref _valueLabel, value);
        }
        #endregion

        public MainViewModel()
        {
            ListViewModel.AddNodeType(() => new AxisSummerViewModel());

            var startingPoint = new Point(100, 100);

            var input1 = new AxisSummerViewModel();
            //input1.ValueEditor.Value = 123;
            NetworkViewModel.Nodes.Add(input1);
            input1.Position = startingPoint;

            NetworkViewModel.Validator = network =>
            {
                var containsLoops = GraphAlgorithms.FindLoops(network).Any();
                if (containsLoops)
                {
                    return new NetworkValidationResult(false, false, new ErrorMessageViewModel("Network contains loops!"));
                }

                return new NetworkValidationResult(true, true, null);
            };

            //output.ResultInput.ValueChanged
            //    .Select(v => (NetworkViewModel.LatestValidation?.IsValid ?? true) ? v.ToString() : "Error")
            //    .BindTo(this, vm => vm.ValueLabel);

        }
    }

}

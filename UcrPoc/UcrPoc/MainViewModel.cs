using System;
using System.Windows.Input;
using NodeNetwork.Toolkit.NodeList;
using NodeNetwork.ViewModels;
using ReactiveUI;
using UcrPoc.IONodes.AxisInput;
using UcrPoc.IONodes.AxisOutput;
using UcrPoc.IONodes.ButtonInput;
using UcrPoc.IONodes.ButtonOutput;
using UcrPoc.IONodes.EventInput;
using UcrPoc.IONodes.EventOutput;
using UcrPoc.Nodes.AxisInverter;
using UcrPoc.Nodes.AxisToButtons;
using UcrPoc.Nodes.ButtonsToAxis;
using UcrPoc.Nodes.ButtonToEvent;
using UcrPoc.Nodes.DynamicAxisToButton;
using UcrPoc.Nodes.DynamicButtonToAxis;
using UcrPoc.Nodes.EventToButton;
using UcrPoc.ViewModels.Nodes;

namespace UcrPoc
{
    public class MainViewModel : ReactiveObject
    {
        public NodeListViewModel ListViewModel { get; } = new NodeListViewModel();
        public NetworkViewModel NetworkViewModel { get; } = new NetworkViewModel();

        private ICommand _saveCommand;
        public ICommand SaveCommand { get { return _saveCommand ?? (_saveCommand = new SaveHandler(OnSave)); } }

        static MainViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new MainWindow(), typeof(IViewFor<MainViewModel>));
        }

        public MainViewModel()
        {
            ListViewModel.AddNodeType(() => new AxisInputNode());
            ListViewModel.AddNodeType(() => new AxisOutputNode());
            ListViewModel.AddNodeType(() => new ButtonInputNode());
            ListViewModel.AddNodeType(() => new ButtonOutputNode());
            ListViewModel.AddNodeType(() => new EventInputNode());
            ListViewModel.AddNodeType(() => new EventOutputNode());

            ListViewModel.AddNodeType(() => new AxisInverterNode());
            ListViewModel.AddNodeType(() => new DeadzoneNode());
            ListViewModel.AddNodeType(() => new AxisToButtonsNode());
            ListViewModel.AddNodeType(() => new ButtonsToAxisNode());
            ListViewModel.AddNodeType(() => new EventToButtonNode());
            ListViewModel.AddNodeType(() => new ButtonToEventNode());
            ListViewModel.AddNodeType(() => new DynamicAxisToButtonNode());
            ListViewModel.AddNodeType(() => new DynamicButtonToAxisNode());
        }

        public void OnSave()
        {
            var debug = "me";
            foreach (var nodeViewModel in NetworkViewModel.Nodes)
            {
                var x = nodeViewModel.Position.X;
                var foo = nodeViewModel.GetType();
            }
        }

        public class SaveHandler : ICommand
        {
            public event EventHandler CanExecuteChanged;
            private Action _action;

            public SaveHandler(Action action)
            {
                _action = action;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                _action();
            }
        }
    }
}

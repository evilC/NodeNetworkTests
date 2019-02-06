using System.Reactive.Subjects;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using UcrPoc.ViewModels.Ports;

namespace UcrPoc.ViewModels.Nodes.IO
{
    public class ButtonInputNode : NodeViewModel
    {
        private readonly Subject<bool?> _output = new Subject<bool?>();

        static ButtonInputNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ButtonInputNode>));
        }

        public ButtonInputNode()
        {
            Name = "Button Input";

            var buttonInput = new ButtonInputViewModel(OnButtonEvent)
            {
                ButtonLabel = "Click"
            };
            Inputs.Add(buttonInput);


            var output = new ValueNodeOutputViewModel<bool?>
            {
                Name = "Output",
                Value = _output,
                Port = new ButtonPortViewModel()
            };
            Outputs.Add(output);
        }

        private void OnButtonEvent(bool state)
        {
            _output.OnNext(state);
        }
    }
}

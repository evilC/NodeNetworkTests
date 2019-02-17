using System;
using System.Reactive.Subjects;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using UcrPoc.Ports.Button;

namespace UcrPoc.Nodes.ButtonToEvent
{
    public class ButtonToEventNode  : NodeViewModel
    {
        private readonly Subject<DateTime?> _output = new Subject<DateTime?>();

        static ButtonToEventNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ButtonToEventNode>));
        }

        public ButtonToEventNode()
        {
            Name = "Button To Event";

            var input = new ValueNodeInputViewModel<bool?>()
            {
                Name = "Input",
                Port = new ButtonPortViewModel(),
            };
            Inputs.Add(input);
            input.ValueChanged.Subscribe(newValue =>
            {
                if (newValue == null || !(bool)newValue) return;
                _output.OnNext(DateTime.Now);
            });

            Outputs.Add(new ValueNodeOutputViewModel<DateTime?>
            {
                Name = "Output",
                Value = _output
            });

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using UcrPoc.ViewModels.Ports;

namespace UcrPoc.ViewModels.Nodes
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

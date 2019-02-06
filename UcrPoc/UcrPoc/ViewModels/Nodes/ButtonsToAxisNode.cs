using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UcrPoc.ViewModels.Nodes
{
    public class ButtonsToAxisNode : NodeViewModel
    {
        private readonly ValueNodeInputViewModel<bool?> _inputLow;
        private readonly ValueNodeInputViewModel<bool?> _inputHigh;
        private readonly Subject<short?> _output = new Subject<short?>();

        static ButtonsToAxisNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ButtonsToAxisNode>));
        }

        public ButtonsToAxisNode()
        {
            Name = "Buttons\nTo Axis";

            _inputLow = new ValueNodeInputViewModel<bool?>()
            {
                Name = "Input Low",
                Port = new ButtonPortViewModel()
            };
            Inputs.Add(_inputLow);

            _inputHigh = new ValueNodeInputViewModel<bool?>()
            {
                Name = "Input High",
                Port = new ButtonPortViewModel()
            };
            Inputs.Add(_inputHigh);

            this.WhenAnyValue(vm => vm._inputLow.Value, vm => vm._inputHigh.Value).Subscribe(newValues =>
            {
                var lowValue = newValues.Item1 ?? false;
                var highValue = newValues.Item2 ?? false;
                if (highValue && lowValue)
                {
                    _output.OnNext(0);
                }
                else if (highValue)
                {
                    _output.OnNext(short.MaxValue);
                }
                else if (lowValue)
                {
                    _output.OnNext(short.MinValue);
                }
                else
                {
                    _output.OnNext(0);
                }
            });

            Outputs.Add(new ValueNodeOutputViewModel<short?>
            {
                Name = "Output",
                Port = new AxisPortViewModel(),
                Value = _output,
            });
        }
    }
}

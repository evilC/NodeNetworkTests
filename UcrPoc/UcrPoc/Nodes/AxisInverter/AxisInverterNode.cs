using System;
using System.Reactive.Subjects;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using UcrPoc.Ports.Axis;

namespace UcrPoc.Nodes.AxisInverter
{
    public class AxisInverterNode : NodeViewModel
    {
        private readonly Subject<short?> _output = new Subject<short?>();

        static AxisInverterNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<AxisInverterNode>));
        }

        public AxisInverterNode()
        {
            Name = "Axis\nInverter";

            var input = new ValueNodeInputViewModel<short?>()
            {
                Name = "Input",
                Port = new AxisPortViewModel(),
            };
            Inputs.Add(input);

            input.ValueChanged.Subscribe(newValue =>
            {
                _output.OnNext(InvertAxis(newValue));
            });

            Outputs.Add(new ValueNodeOutputViewModel<short?>
            {
                Name = "Output",
                Port = new AxisPortViewModel(),
                Value = _output
            });
        }

        private short? InvertAxis(short? input)
        {
            if (input == null) return null;
            if (input == 0) return 0;
            if (input == short.MaxValue) return short.MinValue;
            if (input == short.MinValue) return short.MaxValue;
            return (short?) (input * -1);
        }
    }
}

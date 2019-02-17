using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using UcrPoc.Ports.Axis;
using UcrPoc.Ports.Button;

namespace UcrPoc.Nodes.AxisToButtons
{
    public class AxisToButtonsNode : NodeViewModel
    {
        private readonly List<Subject<bool?>> _outputs = new List<Subject<bool?>>();

        static AxisToButtonsNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<AxisToButtonsNode>));
        }

        public AxisToButtonsNode()
        {
            Name = "Axis To Buttons";

            var input = new ValueNodeInputViewModel<short?>()
            {
                Name = "Input",
                Port = new AxisPortViewModel()
            };
            Inputs.Add(input);

            AddOutput("Output Low");
            AddOutput("Output High");
            
            input.ValueChanged.Subscribe(newValue =>
            {
                if (newValue < 0)
                {
                    _outputs[0].OnNext(true);
                    _outputs[1].OnNext(false);
                }
                else if (newValue > 0)
                {
                    _outputs[0].OnNext(false);
                    _outputs[1].OnNext(true);
                }
                else
                {
                    _outputs[0].OnNext(false);
                    _outputs[1].OnNext(false);
                }
            });

        }

        private void AddOutput(string name)
        {
            var vm = new ValueNodeOutputViewModel<bool?> {Name = name, Port = new ButtonPortViewModel()};

            var ov = new Subject<bool?>();
            _outputs.Add(ov);
            vm.Value = ov;

            Outputs.Add(vm);
        }
    }
}

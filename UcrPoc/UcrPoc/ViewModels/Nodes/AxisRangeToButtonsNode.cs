using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using UcrPoc.ViewModels.Ports;

namespace UcrPoc.ViewModels.Nodes
{
    public class AxisRangeToButtonsNode : NodeViewModel
    {
        private List<Subject<bool?>> _outputs = new List<Subject<bool?>>();
        private readonly List<ValueNodeOutputViewModel<bool?>> _resultOutputs = new List<ValueNodeOutputViewModel<bool?>>();

        static AxisRangeToButtonsNode()
        {
            //Splat.Locator.CurrentMutable.Register(() => new AxisRangeToButtonsView(), typeof(IViewFor<AxisRangeToButtonsNode>));
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<AxisRangeToButtonsNode>));
        }

        public AxisRangeToButtonsNode()
        {
            Name = "Axis Range\nTo Buttons\n(Broken)";

            var input = new ValueNodeInputViewModel<short?>
            {
                Name = "Input",
                Port = new AxisPortViewModel()
            };
            Inputs.Add(input);

            var buttonInput = new ButtonInputViewModel(OnAddOutput) { Name = "AddOutput", ButtonLabel = "Add Output" };
            Inputs.Add(buttonInput);
        }

        private void OnAddOutput(bool state)
        {
            if (!state) return;
            AddOutput();
        }

        public void AddOutput()
        {
            var i = _resultOutputs.Count;
            _resultOutputs.Add(new ValueNodeOutputViewModel<bool?> { Name = $"Output {i + 1}" });
            Outputs.Add(_resultOutputs[i]);

            var ov = new Subject<bool?>();
            _outputs.Add(ov);

            _resultOutputs[i].Value = ov;
        }
    }
}

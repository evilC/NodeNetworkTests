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

namespace UcrPoc.ViewModels.Nodes
{
    public class DynamicButtonToAxisNode : NodeViewModel
    {
        private readonly List<ValueNodeInputViewModel<bool?>> _inputs = new List<ValueNodeInputViewModel<bool?>>();
        private readonly Subject<short?> _output = new Subject<short?>();

        static DynamicButtonToAxisNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<DynamicButtonToAxisNode>));
        }

        public DynamicButtonToAxisNode()
        {
            Name = "Dynamic\nButtons\nTo Axis\n(Broken)";

            var buttonInput = new ButtonInputViewModel(OnAddInput) { Name = "AddOutput", ButtonLabel = "Add Input" };
            Inputs.Add(buttonInput);

            var output = new ValueNodeOutputViewModel<short?>
            {
                Name = "Output",
                Port = new AxisPortViewModel(),
                Value = _output,
            };
            Outputs.Add(output);
        }

        private void OnAddInput(bool state)
        {
            if (!state) return;
            AddInput();
        }

        public void AddInput()
        {
            var vm = new ValueNodeInputViewModel<bool?> {Name = $"Input {_inputs.Count + 1}"};
            _inputs.Add(vm);
            Inputs.Add(vm);
        }
    }
}

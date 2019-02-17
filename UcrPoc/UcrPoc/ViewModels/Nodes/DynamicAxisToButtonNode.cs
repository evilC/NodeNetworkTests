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
using UcrPoc.Views.Nodes;

namespace UcrPoc.ViewModels.Nodes
{
    public class DynamicAxisToButtonNode : NodeViewModel
    {
        private List<Subject<bool?>> _outputs = new List<Subject<bool?>>();
        private readonly List<ValueNodeOutputViewModel<bool?>> _resultOutputs = new List<ValueNodeOutputViewModel<bool?>>();
        public bool? AddOutputButtonState { get => _addOutputButtonState.Value; set => _addOutputButtonState.OnNext(value); }
        private readonly BehaviorSubject<bool?> _addOutputButtonState = new BehaviorSubject<bool?>(false);

        static DynamicAxisToButtonNode()
        {
            //Splat.Locator.CurrentMutable.Register(() => new AxisRangeToButtonsView(), typeof(IViewFor<AxisRangeToButtonsNode>));
            Splat.Locator.CurrentMutable.Register(() => new DynamicAxisToButtonView(), typeof(IViewFor<DynamicAxisToButtonNode>));
        }

        public DynamicAxisToButtonNode()
        {
            Name = "Axis Range\nTo Buttons\n(Broken)";

            var input = new ValueNodeInputViewModel<short?>
            {
                Name = "Input",
                Port = new AxisPortViewModel()
            };
            Inputs.Add(input);

            _addOutputButtonState.Subscribe(OnAddOutput);
        }

        private void OnAddOutput(bool? state)
        {
            if (state == null || (bool) !state) return;
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

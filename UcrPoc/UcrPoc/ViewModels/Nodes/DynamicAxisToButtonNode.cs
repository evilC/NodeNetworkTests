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
using UcrPoc.ViewModels.Editors;
using UcrPoc.ViewModels.Ports;
using UcrPoc.Views.Nodes;

namespace UcrPoc.ViewModels.Nodes
{
    public class DynamicAxisToButtonNode : NodeViewModel
    {
        private List<BehaviorSubject<bool?>> _outputs = new List<BehaviorSubject<bool?>>();
        private readonly List<ValueNodeOutputViewModel<bool?>> _resultOutputs = new List<ValueNodeOutputViewModel<bool?>>();
        public bool? AddOutputButtonState { get => _addOutputButtonState.Value; set => _addOutputButtonState.OnNext(value); }
        private readonly BehaviorSubject<bool?> _addOutputButtonState = new BehaviorSubject<bool?>(false);

        static DynamicAxisToButtonNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new DynamicAxisToButtonView(), typeof(IViewFor<DynamicAxisToButtonNode>));
        }

        public DynamicAxisToButtonNode()
        {
            Name = "Dynamic Axis To Button";

            var input = new ValueNodeInputViewModel<short?>
            {
                Name = "Input",
                Port = new AxisPortViewModel()
            };
            Inputs.Add(input);
            input.ValueChanged.Subscribe(newValue =>
            {
                for (var i = 0; i < Outputs.Count; i++)
                {
                    var editor = (AxisToButtonEditorViewModel)Outputs[i].Editor;
                    var output = _outputs[i];
                    if (newValue >= editor.AxisFrom && newValue <= editor.AxisTo)
                    {
                        if (output.Value != null && !(bool) !output.Value) continue;
                        //Console.WriteLine($@"Input changed to: {newValue}, changing output {i + 1} to true");
                        output.OnNext(true);
                    }
                    else
                    {
                        if (output.Value == null || !(bool) output.Value) continue;
                        //Console.WriteLine($@"Input changed to: {newValue}, changing output {i + 1} to false");
                        output.OnNext(false);
                    }
                }
            });

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
            //_resultOutputs.Add(new ValueNodeOutputViewModel<bool?> { Name = $"Output {i + 1}" });
            _resultOutputs.Add(new ValueNodeOutputViewModel<bool?>
            {
                Name = $"Output {i + 1}",
                Port = new ButtonPortViewModel(),
                Editor = new AxisToButtonEditorViewModel()
            });
            Outputs.Add(_resultOutputs[i]);

            var ov = new BehaviorSubject<bool?>(false);
            _outputs.Add(ov);

            _resultOutputs[i].Value = ov;
        }
    }
}

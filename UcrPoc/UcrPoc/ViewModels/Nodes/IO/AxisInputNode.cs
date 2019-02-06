using System;
using System.Reactive.Subjects;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using UcrPoc.ViewModels.Editors;
using UcrPoc.ViewModels.Ports;

namespace UcrPoc.ViewModels.Nodes.IO
{
    public class AxisInputNode : NodeViewModel
    {
        private readonly AxisEditorViewModel _valueEditor = new AxisEditorViewModel();
        private readonly Subject<short?> _output = new Subject<short?>();

        static AxisInputNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<AxisInputNode>));
        }

        public AxisInputNode()
        {
            Name = "Axis Input";

            this.WhenAnyValue(vm => vm._valueEditor.Value).Subscribe(newValue =>
            {
                _output.OnNext(newValue);
            });

            Outputs.Add(new ValueNodeOutputViewModel<short?>
            {
                Name = "Output",
                Editor = _valueEditor,
                Value = _output,
                Port = new AxisPortViewModel()
            });
        }
    }
}

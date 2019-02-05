using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;

namespace UcrPoc.ViewModels.Nodes
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

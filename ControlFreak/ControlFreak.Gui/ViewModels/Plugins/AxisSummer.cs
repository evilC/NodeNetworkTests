using System.Reactive.Linq;
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;

namespace ControlFreak.Gui.ViewModels.Plugins
{
    public class AxisSummer : NodeViewModel
    {
        public ValueNodeInputViewModel<int?> Input1 { get; }
        public ValueNodeInputViewModel<int?> Input2 { get; }
        public ValueNodeOutputViewModel<int?> Output { get; }

        public AxisSummer()
        {
            Name = "Axis Summer";

            Input1 = new ValueNodeInputViewModel<int?>
            {
                Name = "Input 1",
                Editor = new IntegerValueEditorViewModel()
            };
            Inputs.Add(Input1);

            Input2 = new ValueNodeInputViewModel<int?>
            {
                Name = "Input 2",
                Editor = new IntegerValueEditorViewModel()
            };
            Inputs.Add(Input2);

            var sum = this.WhenAnyValue(vm => vm.Input1.Value, vm => vm.Input2.Value)
                .Select(_ => Input1.Value != null && Input2.Value != null ? Input1.Value + Input2.Value : null);

            Output = new ValueNodeOutputViewModel<int?>
            {
                Name = "Output",
                Value = sum
            };
            Outputs.Add(Output);
        }

        static AxisSummer()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<AxisSummer>));
        }
    }
}

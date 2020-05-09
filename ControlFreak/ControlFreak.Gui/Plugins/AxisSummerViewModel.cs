using System.Reactive.Linq;
using ControlFreak.Gui.ViewModels;
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;

namespace ControlFreak.Gui.Plugins
{
    public class AxisSummerViewModel : NodeViewModel
    {
        public ValueNodeInputViewModel<short?> Input1 { get; }
        public ValueNodeInputViewModel<short?> Input2 { get; }
        public ValueNodeOutputViewModel<short?> Output { get; }

        public AxisSummerViewModel()
        {
            Name = "Axis Summer";

            Input1 = new ValueNodeInputViewModel<short?>
            {
                Name = "Input 1",
                Editor = new ShortValueEditorViewModel()
            };
            Inputs.Add(Input1);

            Input2 = new ValueNodeInputViewModel<short?>
            {
                Name = "Input 2",
                Editor = new ShortValueEditorViewModel()
            };
            Inputs.Add(Input2);

            var sum = this.WhenAnyValue(vm => vm.Input1.Value, vm => vm.Input2.Value)
                .Select(_ => Input1.Value != null && Input2.Value != null ? (short?)(Input1.Value + Input2.Value) : null);

            Output = new ValueNodeOutputViewModel<short?>
            {
                Name = "Output",
                Value = sum
            };
            Outputs.Add(Output);
        }

        static AxisSummerViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<AxisSummerViewModel>));
        }
    }
}

using ControlFreak.Gui.ViewModels;
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;

namespace ControlFreak.Gui.IONodes.AxisInput
{
    public class AxisInputViewModel : NodeViewModel
    {
        static AxisInputViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<AxisInputViewModel>));
        }

        public ShortValueEditorViewModel ValueEditor { get; } = new ShortValueEditorViewModel();

        public ValueNodeOutputViewModel<short?> Output { get; }

        public AxisInputViewModel()
        {
            this.Name = "Axis Input";

            Output = new ValueNodeOutputViewModel<short?>
            {
                Name = "Value",
                Editor = ValueEditor,
                Value = this.WhenAnyValue(vm => vm.ValueEditor.Value)
            };
            this.Outputs.Add(Output);
        }
    }
}

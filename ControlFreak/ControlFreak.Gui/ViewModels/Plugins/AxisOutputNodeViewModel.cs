using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;

namespace ControlFreak.Gui.ViewModels.Plugins
{
    public class AxisOutputNodeViewModel : NodeViewModel
    {
        static AxisOutputNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<AxisOutputNodeViewModel>));
        }

        public ValueNodeInputViewModel<int?> ResultInput { get; }

        public AxisOutputNodeViewModel()
        {
            Name = "Axis Output";

            CanBeRemovedByUser = false;

            ResultInput = new ValueNodeInputViewModel<int?>
            {
                Name = "Value",
                Editor = new IntegerValueEditorViewModel()
            };
            Inputs.Add(ResultInput);
        }
    }
}

using NodeNetwork.Toolkit.ValueNode;
using ReactiveUI;
using UcrPoc.Views.Editors;

namespace UcrPoc.Nodes.DynamicAxisToButton
{
    public class AxisToButtonEditorViewModel : ValueEditorViewModel<bool?>
    {
        public short? AxisFrom { get; set; } = 0;
        public short? AxisTo { get; set; } = 0;

        static AxisToButtonEditorViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new AxisToButtonEditorView(), typeof(IViewFor<AxisToButtonEditorViewModel>));
        }

        public AxisToButtonEditorViewModel()
        {
            Value = false;
        }
    }
}

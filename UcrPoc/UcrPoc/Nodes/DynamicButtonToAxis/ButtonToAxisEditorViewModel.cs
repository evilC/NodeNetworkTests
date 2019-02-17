using NodeNetwork.Toolkit.ValueNode;
using ReactiveUI;
using UcrPoc.Views.Editors;

namespace UcrPoc.Nodes.DynamicButtonToAxis
{
    public class ButtonToAxisEditorViewModel : ValueEditorViewModel<bool?>
    {
        public short? AxisSetPoint { get; set; } = 0;

        static ButtonToAxisEditorViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new ButtonToAxisEditorView(), typeof(IViewFor<ButtonToAxisEditorViewModel>));
        }

        public ButtonToAxisEditorViewModel()
        {
            Value = false;
        }
    }
}

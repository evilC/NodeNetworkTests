using NodeNetwork.Toolkit.ValueNode;
using ReactiveUI;

namespace UcrPoc.IONodes.AxisInputNode
{
    public class AxisEditorViewModel : ValueEditorViewModel<short?>
    {
        static AxisEditorViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new AxisEditorView(), typeof(IViewFor<AxisEditorViewModel>));
        }

        public AxisEditorViewModel()
        {
            Value = 0;
        }
    }
}

using NodeNetwork.Toolkit.ValueNode;
using ReactiveUI;
using UcrPoc.Views;

namespace UcrPoc.ViewModels.Editors
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

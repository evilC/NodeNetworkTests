using NodeNetwork.Toolkit.ValueNode;
using ReactiveUI;

namespace ControlFreak.Gui.Editors.BoolValueEditor
{
    public class BoolValueEditorViewModel : ValueEditorViewModel<bool?>
    {
        static BoolValueEditorViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new BoolValueEditorView(), typeof(IViewFor<BoolValueEditorViewModel>));
        }

        public BoolValueEditorViewModel()
        {
            Value = false;
        }
    }
}

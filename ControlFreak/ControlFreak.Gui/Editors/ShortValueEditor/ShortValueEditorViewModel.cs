using NodeNetwork.Toolkit.ValueNode;
using ReactiveUI;

namespace ControlFreak.Gui.Editors.ShortValueEditor
{
    public class ShortValueEditorViewModel : ValueEditorViewModel<short?>
    {
        static ShortValueEditorViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new ShortValueEditorView(), typeof(IViewFor<ShortValueEditorViewModel>));
        }

        public ShortValueEditorViewModel()
        {
            Value = 0;
        }
    }
}

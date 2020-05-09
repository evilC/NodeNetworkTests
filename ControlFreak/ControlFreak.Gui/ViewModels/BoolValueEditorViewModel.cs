using ControlFreak.Gui.Views;
using NodeNetwork.Toolkit.ValueNode;
using ReactiveUI;

namespace ControlFreak.Gui.ViewModels
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

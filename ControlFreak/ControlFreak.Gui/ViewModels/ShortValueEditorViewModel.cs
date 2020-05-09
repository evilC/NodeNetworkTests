using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlFreak.Gui.Views;
using NodeNetwork.Toolkit.ValueNode;
using ReactiveUI;

namespace ControlFreak.Gui.ViewModels
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodeNetwork.Toolkit.ValueNode;
using ReactiveUI;
using UcrPoc.Views.Editors;

namespace UcrPoc.ViewModels.Editors
{
    public class FloatEditorViewModel : ValueEditorViewModel<float?>
    {
        static FloatEditorViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new FloatEditorView(), typeof(IViewFor<FloatEditorViewModel>));
        }

        public FloatEditorViewModel()
        {
            Value = 0;
        }
    }
}

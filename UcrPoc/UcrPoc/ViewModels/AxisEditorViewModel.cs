using NodeNetwork.Toolkit.ValueNode;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UcrPoc.Views;

namespace UcrPoc.ViewModels
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

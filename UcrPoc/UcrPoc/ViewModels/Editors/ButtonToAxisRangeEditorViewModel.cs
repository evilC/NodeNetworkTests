using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using NodeNetwork.Toolkit.ValueNode;
using ReactiveUI;
using UcrPoc.Views.Editors;

namespace UcrPoc.ViewModels.Editors
{
    public class ButtonToAxisRangeEditorViewModel : ValueEditorViewModel<bool?>
    {
        public short? AxisSetPoint { get; set; } = 0;

        static ButtonToAxisRangeEditorViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new ButtonToAxisEditorView(), typeof(IViewFor<ButtonToAxisRangeEditorViewModel>));
        }

        public ButtonToAxisRangeEditorViewModel()
        {
            Value = false;
        }
    }
}

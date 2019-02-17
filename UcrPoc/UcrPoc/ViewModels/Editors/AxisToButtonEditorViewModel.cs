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
    public class AxisToButtonEditorViewModel : ValueEditorViewModel<bool?>
    {
        public short? AxisFrom { get; set; } = 0;
        public short? AxisTo { get; set; } = 0;

        static AxisToButtonEditorViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new AxisToButtonEditorView(), typeof(IViewFor<AxisToButtonEditorViewModel>));
        }

        public AxisToButtonEditorViewModel()
        {
            Value = false;
        }
    }
}

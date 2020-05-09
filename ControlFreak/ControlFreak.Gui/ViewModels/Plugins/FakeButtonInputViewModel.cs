using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;

namespace ControlFreak.Gui.ViewModels.Plugins
{
    public class FakeButtonInputViewModel : NodeViewModel
    {
        static FakeButtonInputViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<FakeButtonInputViewModel>));
        }

        public BoolValueEditorViewModel ValueEditor { get; } = new BoolValueEditorViewModel();

        public ValueNodeOutputViewModel<bool?> Output { get; }

        public FakeButtonInputViewModel()
        {
            this.Name = "Fake Button Input";

            Output = new ValueNodeOutputViewModel<bool?>
            {
                Name = "Value",
                Editor = ValueEditor,
                Value = this.WhenAnyValue(vm => vm.ValueEditor.Value)
            };
            this.Outputs.Add(Output);
        }
    }
}
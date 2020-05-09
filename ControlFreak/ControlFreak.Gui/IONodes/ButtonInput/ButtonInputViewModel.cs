using ControlFreak.Gui.Editors.BoolValueEditor;
using ControlFreak.Gui.Ports.Button;
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;

namespace ControlFreak.Gui.IONodes.ButtonInput
{
    public class ButtonInputViewModel : NodeViewModel
    {
        static ButtonInputViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ButtonInputViewModel>));
        }

        public BoolValueEditorViewModel ValueEditor { get; } = new BoolValueEditorViewModel();

        public ValueNodeOutputViewModel<bool?> Output { get; }

        public ButtonInputViewModel()
        {
            Name = "Button Input";

            Output = new ValueNodeOutputViewModel<bool?>
            {
                Name = "Value",
                Port = new ButtonPortViewModel(),
                Editor = ValueEditor,
                Value = this.WhenAnyValue(vm => vm.ValueEditor.Value)
            };
            this.Outputs.Add(Output);
        }
    }
}
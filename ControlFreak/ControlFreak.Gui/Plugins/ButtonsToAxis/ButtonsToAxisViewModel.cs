using System.Reactive.Linq;
using ControlFreak.Gui.Editors.BoolValueEditor;
using ControlFreak.Gui.Ports.Axis;
using ControlFreak.Gui.Ports.Button;
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;

namespace ControlFreak.Gui.Plugins.ButtonsToAxis
{
    public class ButtonsToAxisViewModel : NodeViewModel
    {
        public ValueNodeInputViewModel<bool?> InputLow { get; }
        public ValueNodeInputViewModel<bool?> InputHigh { get; }
        public ValueNodeOutputViewModel<short?> Output { get; }

        public ButtonsToAxisViewModel()
        {
            Name = "Buttons To Axis";

            InputLow = new ValueNodeInputViewModel<bool?>
            {
                Name = "Input (Low)",
                Port = new ButtonPortViewModel(),
                Editor = new BoolValueEditorViewModel()
            };
            Inputs.Add(InputLow);

            InputHigh = new ValueNodeInputViewModel<bool?>
            {
                Name = "Input (High)",
                Port = new ButtonPortViewModel(),
                Editor = new BoolValueEditorViewModel()
            };
            Inputs.Add(InputHigh);

            var value = this.WhenAnyValue(vm => vm.InputLow.Value, vm => vm.InputHigh.Value)
                .Select(_ =>
                {
                    if (InputLow.Value == true && InputHigh.Value == true) return (short?) 0;
                    if (InputLow.Value == true) return short.MinValue;
                    if (InputHigh.Value == true) return short.MaxValue;
                    return (short?)0;
                });

            Output = new ValueNodeOutputViewModel<short?>
            {
                Name = "Output",
                Port = new AxisPortViewModel(),
                Value = value
            };
            Outputs.Add(Output);
        }

        static ButtonsToAxisViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ButtonsToAxisViewModel>));
        }
    }
}

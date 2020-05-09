using System;
using ControlFreak.Gui.IONodes.AxisOutput;
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using ReactiveUI;

namespace ControlFreak.Gui.IONodes.ButtonOutput
{
    public class ButtonOutputNode : NodeViewModel
    {
        private string _labelContent;
        public ValueNodeInputViewModel<bool?> Input { get; }

        public string LabelContent
        {
            get => _labelContent;
            set => this.RaiseAndSetIfChanged(ref _labelContent, value);
        }

        static ButtonOutputNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new ButtonOutputView(), typeof(IViewFor<ButtonOutputNode>));
        }

        public ButtonOutputNode()
        {
            Name = "Button Output";

            Input = new ValueNodeInputViewModel<bool?>
            {
                Name = "Input",
            };

            Inputs.Add(Input);
            Input.ValueChanged.Subscribe(newValue =>
            {
                LabelContent = newValue == null ? "None" : newValue.ToString();
            });
        }
    }
}

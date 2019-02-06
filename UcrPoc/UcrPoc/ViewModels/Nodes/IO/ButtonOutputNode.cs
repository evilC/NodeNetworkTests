using System;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using ReactiveUI;
using UcrPoc.ViewModels.Ports;
using UcrPoc.Views;

namespace UcrPoc.ViewModels.Nodes.IO
{
    public class ButtonOutputNode : NodeViewModel
    {
        private string _labelContent;

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

            var input = new ValueNodeInputViewModel<bool?>()
            {
                Name = "Input",
                Port = new ButtonPortViewModel()
            };
            Inputs.Add(input);
            input.ValueChanged.Subscribe(newValue =>
            {
                LabelContent = newValue != null && newValue == true ? "Pressed" : "Released";
            });
        }
    }
}

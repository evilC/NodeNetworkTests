using System;
using ControlFreak.Gui.Ports.Axis;
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using ReactiveUI;

namespace ControlFreak.Gui.IONodes.AxisOutput
{
    public class AxisOutputViewModel : NodeViewModel
    {
        private string _labelContent;
        public ValueNodeInputViewModel<short?> Input { get; }

        public string LabelContent
        {
            get => _labelContent;
            set => this.RaiseAndSetIfChanged(ref _labelContent, value);
        }

        static AxisOutputViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new AxisOutputView(), typeof(IViewFor<AxisOutputViewModel>));
        }

        public AxisOutputViewModel()
        {
            Name = "Axis Output";

            Input = new ValueNodeInputViewModel<short?>
            {
                Name = "Input",
                Port = new AxisPortViewModel(),
            };

            Inputs.Add(Input);
            Input.ValueChanged.Subscribe(newValue =>
            {
                LabelContent = newValue == null ? "None" : newValue.ToString();
            });
        }
    }
}

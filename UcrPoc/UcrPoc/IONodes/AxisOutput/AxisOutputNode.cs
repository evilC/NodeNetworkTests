using System;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using ReactiveUI;
using UcrPoc.Ports.Axis;

namespace UcrPoc.IONodes.AxisOutput
{
    public class AxisOutputNode : NodeViewModel
    {
        private string _labelContent;

        public string LabelContent
        {
            get => _labelContent;
            set => this.RaiseAndSetIfChanged(ref _labelContent, value);
        }

        static AxisOutputNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new AxisOutputView(), typeof(IViewFor<AxisOutputNode>));
        }

        public AxisOutputNode()
        {
            Name = "Axis Output";

            var input = new ValueNodeInputViewModel<short?>()
            {
                Name = "Input",
                Port = new AxisPortViewModel()
            };
            Inputs.Add(input);
            input.ValueChanged.Subscribe(newValue =>
            {
                if (newValue == null) return;
                LabelContent = newValue.ToString();
            });
        }
    }
}

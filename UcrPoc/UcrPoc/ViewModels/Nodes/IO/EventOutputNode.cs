using System;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using ReactiveUI;
using UcrPoc.Views.Nodes.IO;

namespace UcrPoc.ViewModels.Nodes.IO
{
    public class EventOutputNode : NodeViewModel
    {
        private string _labelContent;

        public string LabelContent
        {
            get => _labelContent;
            set => this.RaiseAndSetIfChanged(ref _labelContent, value);
        }

        static EventOutputNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new EventOutputView(), typeof(IViewFor<EventOutputNode>));
        }

        public EventOutputNode()
        {
            Name = "Event Output";

            var input = new ValueNodeInputViewModel<DateTime?>()
            {
                Name = "Input",
            };
            Inputs.Add(input);
            input.ValueChanged.Subscribe(newValue =>
            {
                if (newValue != null) LabelContent = ((DateTime) newValue).ToString("hh:mm:ss.fff");
            });
        }
    }
}

using System;
using System.Reactive.Subjects;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using UcrPoc.IONodes.ButtonInput;

namespace UcrPoc.ViewModels.Nodes.IO
{
    public class EventInputNode : NodeViewModel
    {
        private readonly Subject<DateTime?> _output = new Subject<DateTime?>();

        static EventInputNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<EventInputNode>));
        }

        public EventInputNode()
        {
            Name = "Event Input";

            Inputs.Add(new ButtonInputViewModel(OnButtonEvent)
            {
                ButtonLabel = "Click"
            });

            Outputs.Add(new ValueNodeOutputViewModel<DateTime?>
            {
                Name = "Output",
                Value = _output,
            });
        }

        private void OnButtonEvent(bool state)
        {
            if (!state) return; // Events have no press / release, so only send one event on click
            _output.OnNext(DateTime.Now);
        }
    }
}

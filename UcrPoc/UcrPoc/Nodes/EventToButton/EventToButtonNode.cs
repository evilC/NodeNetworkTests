using System;
using System.Reactive.Subjects;
using System.Threading;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using UcrPoc.ViewModels.Ports;

namespace UcrPoc.Nodes.EventToButton
{
    public class EventToButtonNode : NodeViewModel
    {
        private readonly Subject<bool?> _output = new Subject<bool?>();

        static EventToButtonNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<EventToButtonNode>));
        }

        public EventToButtonNode()
        {
            Name = "Event To Button";

            var input = new ValueNodeInputViewModel<DateTime?>()
            {
                Name = "Input",
            };
            Inputs.Add(input);
            input.ValueChanged.Subscribe(newValue =>
            {
                _output.OnNext(true);
                ThreadPool.QueueUserWorkItem(cb => ReleaseButton());
            });

            Outputs.Add(new ValueNodeOutputViewModel<bool?>
            {
                Name = "Output",
                Port = new ButtonPortViewModel(),
                Value = _output
            });
        }

        private void ReleaseButton()
        {
            Thread.Sleep(1000); // ToDo: Add configurable Hold Time
            _output.OnNext(false);
        }
    }
}

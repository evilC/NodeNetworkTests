using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using UcrPoc.Models;

namespace UcrPoc.ViewModels.Nodes
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

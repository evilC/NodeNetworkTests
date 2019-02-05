using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using UcrPoc.Models;
using UcrPoc.Views;

namespace UcrPoc.ViewModels.Nodes
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
                if (Position == new Point(0, 0))
                {
                    return;
                }
                LabelContent = ((DateTime)newValue).ToString("hh:mm:ss.fff");
            });
        }
    }
}

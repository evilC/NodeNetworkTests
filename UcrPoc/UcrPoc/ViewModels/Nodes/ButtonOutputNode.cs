﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using ReactiveUI;
using UcrPoc.Views;

namespace UcrPoc.ViewModels.Nodes
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

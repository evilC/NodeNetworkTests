﻿using System;
using ControlFreak.Gui.ViewModels;
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using ReactiveUI;

namespace ControlFreak.Gui.IONodes.AxisOutput
{
    public class AxisOutputNode : NodeViewModel
    {
        private string _labelContent;
        public ValueNodeInputViewModel<short?> Input { get; }

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

            Input = new ValueNodeInputViewModel<short?>
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

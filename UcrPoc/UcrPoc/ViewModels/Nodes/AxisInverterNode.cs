﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using UcrPoc.ViewModels.Ports;

namespace UcrPoc.ViewModels.Nodes
{
    public class AxisInverterNode : NodeViewModel
    {
        private readonly Subject<short?> _output = new Subject<short?>();

        static AxisInverterNode()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<AxisInverterNode>));
        }

        public AxisInverterNode()
        {
            Name = "Axis\nInverter";

            var input = new ValueNodeInputViewModel<short?>()
            {
                Name = "Input",
                Port = new AxisPortViewModel(),
            };
            Inputs.Add(input);

            input.ValueChanged.Subscribe(newValue =>
            {
                _output.OnNext(InvertAxis(newValue));
            });

            Outputs.Add(new ValueNodeOutputViewModel<short?>
            {
                Name = "Output",
                Port = new AxisPortViewModel(),
                Value = _output
            });
        }

        private short? InvertAxis(short? input)
        {
            if (input == null) return null;
            if (input == 0) return 0;
            if (input == short.MaxValue) return short.MinValue;
            if (input == short.MinValue) return short.MaxValue;
            return (short?) (input * -1);
        }
    }
}

using System;
using System.Reactive.Subjects;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using ReactiveUI;
using UcrPoc.Ports.Axis;
using DeadzoneView = UcrPoc.Nodes.Deadzone.DeadzoneView;

namespace UcrPoc.ViewModels.Nodes
{
    public class DeadzoneNode : NodeViewModel
    {
        private readonly Subject<short?> _output = new Subject<short?>();
        private ValueNodeInputViewModel<float?> _dzAmount;
        private double _scaleFactor;
        private double _deadzoneCutoff;

        private readonly BehaviorSubject<int?> _deadzonePercent = new BehaviorSubject<int?>(0);
        public int? DeadzonePercent { get => _deadzonePercent.Value; set => _deadzonePercent.OnNext(value); }

        static DeadzoneNode()
        {
            //Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<DeadzoneNode>));
            Splat.Locator.CurrentMutable.Register(() => new DeadzoneView(), typeof(IViewFor<DeadzoneNode>));
        }

        public DeadzoneNode()
        {
            Name = "Deadzone";

            _deadzonePercent.Subscribe(SetDeadzone);

            var input = new ValueNodeInputViewModel<short?>()
            {
                Name = "Input",
                Port = new AxisPortViewModel(),
            };
            Inputs.Add(input);

            input.ValueChanged.Subscribe(newValue =>
            {
                _output.OnNext(ApplyDeadzone(newValue));
            });

            Outputs.Add(new ValueNodeOutputViewModel<short?>
            {
                Name = "Output",
                Port = new AxisPortViewModel(),
                Value = _output
            });

        }

        private void SetDeadzone(int? newValue)
        {
            if (newValue == 0)
            {
                _deadzoneCutoff = 0;
                _scaleFactor = 1.0;
            }
            else
            {
                _deadzoneCutoff = (double)(short.MaxValue * (newValue * 0.01));
                _scaleFactor = short.MaxValue / (short.MaxValue - _deadzoneCutoff);
            }
        }

        private short? ApplyDeadzone(short? inValue)
        {
            if (inValue == null) return null;
            var value = (short) inValue;
            var wideVal = WideAbs(value);
            if (wideVal < Math.Round(_deadzoneCutoff))
            {
                return 0;
            }

            var sign = Math.Sign(value);
            var adjustedValue = (wideVal - _deadzoneCutoff) * _scaleFactor;
            var newValue = (int)Math.Round(adjustedValue * sign);
            if (newValue < -32768) newValue = -32768;   // ToDo: Negative values can go up to -32777 (9 over), can this be improved?
            //Debug.WriteLine($"Pre-DZ: {value}, Post-DZ: {newValue}, Cutoff: {_deadzoneCutoff}");
            return (short)newValue;
        }

        public static int WideAbs(short value)
        {
            return Math.Abs((int)value);
        }
    }
}

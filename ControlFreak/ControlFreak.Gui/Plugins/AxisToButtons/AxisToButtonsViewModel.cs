using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using ControlFreak.Gui.Editors.BoolValueEditor;
using ControlFreak.Gui.Editors.ShortValueEditor;
using ControlFreak.Gui.Ports.Axis;
using ControlFreak.Gui.Ports.Button;
using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;

namespace ControlFreak.Gui.Plugins.AxisToButtons
{
    public class AxisToButtonsViewModel : NodeViewModel
    {
        public ValueNodeInputViewModel<short?> Input { get; }
        private readonly List<Subject<bool?>> _outputs = new List<Subject<bool?>>();

        public AxisToButtonsViewModel()
        {
            Name = "Axis To Buttons";

            Input = new ValueNodeInputViewModel<short?>
            {
                Name = "Input (Low)",
                Port = new AxisPortViewModel(),
                Editor = new ShortValueEditorViewModel()
            };
            Inputs.Add(Input);

            AddOutput("Output Low");
            AddOutput("Output High");

            Input.ValueChanged.Subscribe(newValue =>
            {
                if (Input.Value == 0)
                {
                    _outputs[0].OnNext(false);
                    _outputs[1].OnNext(false);
                }
                else if (Input.Value < 0)
                {
                    _outputs[0].OnNext(true);
                    _outputs[1].OnNext(false);
                }
                else
                {
                    _outputs[0].OnNext(false);
                    _outputs[1].OnNext(true);
                }
            });
        }

        static AxisToButtonsViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<AxisToButtonsViewModel>));
        }

        private void AddOutput(string name)
        {
            var vm = new ValueNodeOutputViewModel<bool?>
            {
                Name = name, 
                Port = new ButtonPortViewModel()
            };

            var ov = new Subject<bool?>();
            _outputs.Add(ov);
            vm.Value = ov;

            Outputs.Add(vm);
        }
    }
}

using NodeNetwork.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UcrPoc.IONodes.ButtonInput;
using UcrPoc.Views.Nodes.IO;

namespace UcrPoc.ViewModels
{
    public class ButtonInputViewModel : NodeInputViewModel
    {
        static ButtonInputViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new ButtonInputView(), typeof(IViewFor<ButtonInputViewModel>));
        }

        private ICommand _buttonDownCommand;
        private ICommand _buttonUpCommand;

        public ICommand ButtonDown { get { return _buttonDownCommand ?? (_buttonDownCommand = new CommandHandler(() => OnButtonDown(), _canExecute)); } }
        public ICommand ButtonUp { get { return _buttonUpCommand ?? (_buttonUpCommand = new CommandHandler(() => OnButtonUp(), _canExecute)); } }

        private Action<bool> _buttonDelegate;

        private bool _canExecute;

        public string ButtonLabel { get; set; }

        public ButtonInputViewModel(Action<bool> buttonDelegate)
        {
            _buttonDelegate = buttonDelegate;
            _canExecute = true;
        }

        public void OnButtonDown()
        {
            _buttonDelegate(true);
        }

        public void OnButtonUp()
        {
            _buttonDelegate(false);
        }

        public class CommandHandler : ICommand
        {
            private Action _action;
            private bool _canExecute;
            public CommandHandler(Action action, bool canExecute)
            {
                _action = action;
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                _action();
            }
        }
    }
}

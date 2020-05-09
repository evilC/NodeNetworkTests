﻿using NodeNetwork.ViewModels;
using ReactiveUI;

namespace ControlFreak.Gui.Ports.Button
{
    public class ButtonPortViewModel : PortViewModel
    {
        #region Size
        public double Size
        {
            get => _size;
            set => this.RaiseAndSetIfChanged(ref _size, value);
        }
        private double _size;
        #endregion

        static ButtonPortViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new ButtonPortView(), typeof(IViewFor<ButtonPortViewModel>));
        }
    }
}

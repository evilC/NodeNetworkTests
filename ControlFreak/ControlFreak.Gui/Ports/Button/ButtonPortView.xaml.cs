﻿using System.Reactive.Disposables;
using System.Windows;
using ReactiveUI;

namespace ControlFreak.Gui.Ports.Button
{
    public partial class ButtonPortView : IViewFor<ButtonPortViewModel>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(ButtonPortViewModel), typeof(ButtonPortView), new PropertyMetadata(null));

        public ButtonPortViewModel ViewModel
        {
            get => (ButtonPortViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (ButtonPortViewModel)value;
        }
        #endregion

        public ButtonPortView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.WhenAnyValue(v => v.ViewModel).BindTo(this, v => v.PortView.ViewModel).DisposeWith(d);
            });
        }
    }
}

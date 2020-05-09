using System.Reactive.Disposables;
using System.Windows;
using ReactiveUI;

namespace ControlFreak.Gui.Ports.Axis
{
    public partial class AxisPortView : IViewFor<AxisPortViewModel>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(AxisPortViewModel), typeof(AxisPortView), new PropertyMetadata(null));

        public AxisPortViewModel ViewModel
        {
            get => (AxisPortViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (AxisPortViewModel)value;
        }
        #endregion

        public AxisPortView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.WhenAnyValue(v => v.ViewModel).BindTo(this, v => v.PortView.ViewModel).DisposeWith(d);
            });
        }
    }
}

using System.Reactive.Disposables;
using System.Windows;
using ReactiveUI;

namespace UcrPoc.Nodes.DynamicButtonToAxis
{
    /// <summary>
    /// Interaction logic for ButtonToAxisEditorView.xaml
    /// </summary>
    /// Dummy editor that holds Axis Set Point.
    public partial class ButtonToAxisEditorView : IViewFor<ButtonToAxisEditorViewModel>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(ButtonToAxisEditorViewModel), typeof(ButtonToAxisEditorView), new PropertyMetadata(null));

        public ButtonToAxisEditorViewModel ViewModel
        {
            get => (ButtonToAxisEditorViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (ButtonToAxisEditorViewModel)value;
        }
        #endregion
        public ButtonToAxisEditorView()
        {
            InitializeComponent();

            // Do not bind to the value ...
            //this.WhenActivated(d => {
            //    this.Bind(ViewModel, vm => vm.Value, v => v.CheckBox.IsChecked).DisposeWith(d);
            //});
            // ... Bind to the SetPoint instead
            this.WhenActivated(d =>
            {
                this.Bind(ViewModel, vm => vm.AxisSetPoint, v => v.AxisSetPoint.Text).DisposeWith(d);
            });
        }
    }
}

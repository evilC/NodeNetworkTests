using ReactiveUI;
using System.Windows;
using System.Windows.Controls;

namespace UcrPoc.IONodes.AxisInput
{
    /// <summary>
    /// Interaction logic for IntegerValueEditorView.xaml
    /// </summary>
    public partial class AxisEditorView : UserControl, IViewFor<AxisEditorViewModel>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(AxisEditorViewModel), typeof(AxisEditorView), new PropertyMetadata(null));

        public AxisEditorViewModel ViewModel
        {
            get => (AxisEditorViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (AxisEditorViewModel)value;
        }
        #endregion
        public AxisEditorView()
        {
            InitializeComponent();

            this.WhenActivated(d => d(
                this.Bind(ViewModel, vm => vm.Value, v => v.valueUpDown.Value)
            ));
        }
    }
}

using System.Reactive.Disposables;
using System.Windows;
using ReactiveUI;

namespace UcrPoc.Nodes.DynamicButtonToAxis
{
    /// <summary>
    /// Interaction logic for DynamicButtonToAxisView.xaml
    /// </summary>
    public partial class DynamicButtonToAxisView : IViewFor<DynamicButtonToAxisNode>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(DynamicButtonToAxisNode), typeof(DynamicButtonToAxisView), new PropertyMetadata(null));

        public DynamicButtonToAxisNode ViewModel
        {
            get => (DynamicButtonToAxisNode)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (DynamicButtonToAxisNode)value;
        }
        #endregion
        public DynamicButtonToAxisView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.WhenAnyValue(v => v.ViewModel).BindTo(this, v => v.NodeView.ViewModel).DisposeWith(d);
            });
        }
    }
}

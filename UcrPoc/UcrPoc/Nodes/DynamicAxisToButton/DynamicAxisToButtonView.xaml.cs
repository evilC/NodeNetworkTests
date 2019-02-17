using System.Reactive.Disposables;
using System.Windows;
using ReactiveUI;

namespace UcrPoc.Nodes.DynamicAxisToButton
{
    /// <summary>
    /// Interaction logic for DynamicAxisToButtonView.xaml
    /// </summary>
    public partial class DynamicAxisToButtonView : IViewFor<DynamicAxisToButtonNode>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(DynamicAxisToButtonNode), typeof(DynamicAxisToButtonView), new PropertyMetadata(null));

        public DynamicAxisToButtonNode ViewModel
        {
            get => (DynamicAxisToButtonNode)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (DynamicAxisToButtonNode)value;
        }
        #endregion
        public DynamicAxisToButtonView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.WhenAnyValue(v => v.ViewModel).BindTo(this, v => v.NodeView.ViewModel).DisposeWith(d);
            });
        }
    }
}

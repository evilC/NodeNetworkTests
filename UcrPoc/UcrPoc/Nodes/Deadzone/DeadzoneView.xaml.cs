using System.Reactive.Disposables;
using System.Windows;
using ReactiveUI;
using UcrPoc.ViewModels.Nodes;

namespace UcrPoc.Nodes.Deadzone
{
    /// <summary>
    /// Interaction logic for DeadzoneView.xaml
    /// </summary>
    public partial class DeadzoneView : IViewFor<DeadzoneNode>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(DeadzoneNode), typeof(DeadzoneView), new PropertyMetadata(null));

        public DeadzoneNode ViewModel
        {
            get => (DeadzoneNode)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (DeadzoneNode)value;
        }
        #endregion
        public DeadzoneView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.WhenAnyValue(v => v.ViewModel).BindTo(this, v => v.NodeView.ViewModel).DisposeWith(d);
            });
        }
    }
}

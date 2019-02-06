using System.Reactive.Disposables;
using System.Windows;
using ReactiveUI;
using UcrPoc.ViewModels.Nodes.IO;

namespace UcrPoc.Views.Nodes.IO
{
    /// <summary>
    /// Interaction logic for OutputAxisView.xaml
    /// </summary>
    public partial class AxisOutputView : IViewFor<AxisOutputNode>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(AxisOutputNode), typeof(AxisOutputView), new PropertyMetadata(null));
        public AxisOutputNode ViewModel { get => (AxisOutputNode)GetValue(ViewModelProperty); set => SetValue(ViewModelProperty, value); }
        object IViewFor.ViewModel { get => ViewModel; set => ViewModel = (AxisOutputNode)value; }

        public AxisOutputView()
        {
            DataContext = ViewModel;
            InitializeComponent();

            this.WhenActivated(d =>
            {
                NodeView.ViewModel = this.ViewModel;

                this.Bind(ViewModel,
                    viewModel => viewModel.LabelContent,
                    view => view.labelContent.Content
                ).DisposeWith(d);
            });
        }
    }
}

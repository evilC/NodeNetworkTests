using System.Reactive.Disposables;
using System.Windows;
using ReactiveUI;

namespace UcrPoc.IONodes.ButtonOutput
{
    /// <summary>
    /// Interaction logic for ButtonOutputView.xaml
    /// </summary>
    public partial class ButtonOutputView : IViewFor<ButtonOutputNode>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(ButtonOutputNode), typeof(ButtonOutputView), new PropertyMetadata(null));
        public ButtonOutputNode ViewModel { get => (ButtonOutputNode)GetValue(ViewModelProperty); set => SetValue(ViewModelProperty, value); }
        object IViewFor.ViewModel { get => ViewModel; set => ViewModel = (ButtonOutputNode)value; }

        public ButtonOutputView()
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

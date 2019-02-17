using System.Reactive.Disposables;
using System.Windows;
using ReactiveUI;

namespace UcrPoc.IONodes.EventOutput
{
    /// <summary>
    /// Interaction logic for EventOutputView.xaml
    /// </summary>
    public partial class EventOutputView : IViewFor<EventOutputNode>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(EventOutputNode), typeof(EventOutputView), new PropertyMetadata(null));
        public EventOutputNode ViewModel { get => (EventOutputNode)GetValue(ViewModelProperty); set => SetValue(ViewModelProperty, value); }
        object IViewFor.ViewModel { get => ViewModel; set => ViewModel = (EventOutputNode)value; }

        public EventOutputView()
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

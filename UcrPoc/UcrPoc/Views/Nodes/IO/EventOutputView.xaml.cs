using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReactiveUI;
using UcrPoc.ViewModels.Nodes;
using UcrPoc.ViewModels.Nodes.IO;

namespace UcrPoc.Views.Nodes.IO
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

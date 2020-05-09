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

namespace ControlFreak.Gui.IONodes.AxisOutput
{
    public partial class AxisOutputView : IViewFor<AxisOutputViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(AxisOutputViewModel), typeof(AxisOutputView), new PropertyMetadata(null));
        public AxisOutputViewModel ViewModel { get => (AxisOutputViewModel)GetValue(ViewModelProperty); set => SetValue(ViewModelProperty, value); }
        object IViewFor.ViewModel { get => ViewModel; set => ViewModel = (AxisOutputViewModel)value; }

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

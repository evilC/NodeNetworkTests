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
using UcrPoc.ViewModels;
using UcrPoc.ViewModels.Ports;

namespace UcrPoc.Views
{
    /// <summary>
    /// Interaction logic for AxisPortView.xaml
    /// </summary>
    public partial class AxisPortView : IViewFor<AxisPortViewModel>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(AxisPortViewModel), typeof(AxisPortView), new PropertyMetadata(null));

        public AxisPortViewModel ViewModel
        {
            get => (AxisPortViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (AxisPortViewModel)value;
        }
        #endregion

        public AxisPortView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.WhenAnyValue(v => v.ViewModel).BindTo(this, v => v.PortView.ViewModel).DisposeWith(d);
            });
        }
    }
}

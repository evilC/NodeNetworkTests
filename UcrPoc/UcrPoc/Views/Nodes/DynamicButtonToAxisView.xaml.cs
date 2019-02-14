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
using UcrPoc.ViewModels.Editors;
using UcrPoc.ViewModels.Nodes;
using UcrPoc.Views.Editors;

namespace UcrPoc.Views.Nodes
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

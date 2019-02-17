using System;
using System.Collections.Generic;
using System.Linq;
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

namespace UcrPoc.Views.Nodes
{
    /// <summary>
    /// Interaction logic for DynamicButtonToAxisViewLeader.xaml
    /// </summary>
    public partial class DynamicButtonToAxisViewLeader : IViewFor<DynamicButtonToAxisNode>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(DynamicButtonToAxisNode), typeof(DynamicButtonToAxisViewLeader), new PropertyMetadata(null));

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

        public DynamicButtonToAxisViewLeader()
        {
            InitializeComponent();

            this.Bind(ViewModel, vm => vm.AddInputButtonState, v => v.btnAddInput.IsPressed);
            this.Bind(ViewModel, vm => vm.DefaultSetPointValue, v => v.DefaultSetPoint.Value);
        }
    }
}

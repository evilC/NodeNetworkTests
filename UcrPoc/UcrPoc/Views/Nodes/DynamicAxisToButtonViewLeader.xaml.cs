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
    /// Interaction logic for DynamicAxisToButtonViewLeader.xaml
    /// </summary>
    public partial class DynamicAxisToButtonViewLeader : IViewFor<DynamicAxisToButtonNode>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(DynamicAxisToButtonNode), typeof(DynamicAxisToButtonViewLeader), new PropertyMetadata(null));

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
        public DynamicAxisToButtonViewLeader()
        {
            InitializeComponent();

            this.Bind(ViewModel, vm => vm.AddOutputButtonState, v => v.BtnAddOutput.IsPressed);
        }
    }
}

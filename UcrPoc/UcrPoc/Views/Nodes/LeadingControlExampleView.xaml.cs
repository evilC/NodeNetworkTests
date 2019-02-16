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
    /// Interaction logic for LeadingControlExampleView.xaml
    /// </summary>
    public partial class LeadingControlExampleView : IViewFor<DynamicButtonToAxisNode>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(DynamicButtonToAxisNode), typeof(LeadingControlExampleView), new PropertyMetadata(null));

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

        public LeadingControlExampleView()
        {
            InitializeComponent();

            this.Bind(ViewModel, vm => vm.TestValue, v => v.checkBoxTest.IsChecked);
        }
    }
}

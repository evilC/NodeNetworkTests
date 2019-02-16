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
    /// Interaction logic for DeadzoneViewLeader.xaml
    /// </summary>
    public partial class DeadzoneViewLeader : IViewFor<DeadzoneNode>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(DeadzoneNode), typeof(DeadzoneViewLeader), new PropertyMetadata(null));

        public DeadzoneNode ViewModel
        {
            get => (DeadzoneNode)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (DeadzoneNode)value;
        }
        #endregion

        public DeadzoneViewLeader()
        {
            InitializeComponent();

            this.Bind(ViewModel, vm => vm.DeadzonePercent, v => v.DeadzonePercent.Text);
        }
    }
}

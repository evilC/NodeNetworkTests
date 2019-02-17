using System.Windows;
using ReactiveUI;
using UcrPoc.ViewModels.Nodes;

namespace UcrPoc.Nodes.Deadzone
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

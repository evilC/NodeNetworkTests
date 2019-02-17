using System.Windows;
using ReactiveUI;

namespace UcrPoc.Nodes.DynamicAxisToButton
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

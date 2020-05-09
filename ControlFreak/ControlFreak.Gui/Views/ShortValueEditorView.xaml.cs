using System.Windows;
using System.Windows.Controls;
using ControlFreak.Gui.ViewModels;
using ReactiveUI;

namespace ControlFreak.Gui.Views
{
    public partial class ShortValueEditorView : UserControl, IViewFor<ShortValueEditorViewModel>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(ShortValueEditorViewModel), typeof(ShortValueEditorView), new PropertyMetadata(null));

        public ShortValueEditorViewModel ViewModel
        {
            get => (ShortValueEditorViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (ShortValueEditorViewModel)value;
        }
        #endregion

        public ShortValueEditorView()
        {
            InitializeComponent();

            this.WhenActivated(d => d(
                this.Bind(ViewModel, vm => vm.Value, v => v.valueUpDown.Value)
            ));
        }
    }
}

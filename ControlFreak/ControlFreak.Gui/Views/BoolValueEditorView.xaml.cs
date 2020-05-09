using System.Reactive.Disposables;
using System.Windows;
using ControlFreak.Gui.ViewModels;
using ReactiveUI;

namespace ControlFreak.Gui.Views
{
    public partial class BoolValueEditorView : IViewFor<BoolValueEditorViewModel>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(BoolValueEditorViewModel), typeof(BoolValueEditorView), new PropertyMetadata(null));

        public BoolValueEditorViewModel ViewModel
        {
            get => (BoolValueEditorViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (BoolValueEditorViewModel)value;
        }
        #endregion

        public BoolValueEditorView()
        {
            InitializeComponent();

            this.WhenActivated(d => {
                this.Bind(ViewModel, vm => vm.Value, v => v.CheckBox.IsChecked).DisposeWith(d);
            });
        }
    }
}

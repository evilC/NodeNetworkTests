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

namespace UcrPoc.Views.Editors
{
    /// <summary>
    /// Interaction logic for ButtonToAxisEditorView.xaml
    /// </summary>
    /// Dummy editor that holds Axis Set Point.
    public partial class ButtonToAxisEditorView : IViewFor<ButtonToAxisRangeEditorViewModel>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(ButtonToAxisRangeEditorViewModel), typeof(ButtonToAxisEditorView), new PropertyMetadata(null));

        public ButtonToAxisRangeEditorViewModel ViewModel
        {
            get => (ButtonToAxisRangeEditorViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (ButtonToAxisRangeEditorViewModel)value;
        }
        #endregion
        public ButtonToAxisEditorView()
        {
            InitializeComponent();

            // Do not bind to the value ...
            //this.WhenActivated(d => {
            //    this.Bind(ViewModel, vm => vm.Value, v => v.CheckBox.IsChecked).DisposeWith(d);
            //});
            // ... Bind to the SetPoint instead
            this.WhenActivated(d =>
            {
                this.Bind(ViewModel, vm => vm.AxisSetPoint, v => v.AxisSetPoint.Text).DisposeWith(d);
            });
        }
    }
}

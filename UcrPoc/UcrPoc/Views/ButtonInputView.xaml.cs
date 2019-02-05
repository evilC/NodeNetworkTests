using ReactiveUI;
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
using UcrPoc.ViewModels;

namespace UcrPoc.Views
{
    /// <summary>
    /// Interaction logic for ButtonInputView.xaml
    /// </summary>
    public partial class ButtonInputView : UserControl, IViewFor<ButtonInputViewModel>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(ButtonInputViewModel), typeof(ButtonInputView), new PropertyMetadata(null));

        public ButtonInputViewModel ViewModel
        {
            get => (ButtonInputViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (ButtonInputViewModel)value;
        }
        #endregion


        public ButtonInputView()
        {
            InitializeComponent();
        }
    }
}

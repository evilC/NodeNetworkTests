using System.Reactive.Disposables;
using System.Windows;
using DynamicData;
using NodeNetwork.ViewModels;
using ReactiveUI;


namespace ControlFreak.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window, IViewFor<MainWindowViewModel>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(MainWindowViewModel), typeof(MainWindowView), new PropertyMetadata(null));

        public MainWindowViewModel ViewModel
        {
            get => (MainWindowViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MainWindowViewModel)value;
        }
        #endregion

        public MainWindowView()
        {
            InitializeComponent();

            this.ViewModel = new MainWindowViewModel();

            this.WhenActivated(d =>
            {
                this.OneWayBind(ViewModel, vm => vm.ListViewModel, v => v.nodeList.ViewModel).DisposeWith(d);
                this.OneWayBind(ViewModel, vm => vm.NetworkViewModel, v => v.viewHost.ViewModel).DisposeWith(d);
            });
        }

    }
}

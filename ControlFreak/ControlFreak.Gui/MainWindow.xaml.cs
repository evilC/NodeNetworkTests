using System.Reactive.Disposables;
using System.Windows;
using ControlFreak.Gui.ViewModels;
using ControlFreak.Gui.ViewModels.Plugins;
using DynamicData;
using NodeNetwork.ViewModels;
using ReactiveUI;


namespace ControlFreak.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IViewFor<MainViewModel>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(MainViewModel), typeof(MainWindow), new PropertyMetadata(null));

        public MainViewModel ViewModel
        {
            get => (MainViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MainViewModel)value;
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            this.ViewModel = new MainViewModel();

            this.WhenActivated(d =>
            {
                this.OneWayBind(ViewModel, vm => vm.ListViewModel, v => v.nodeList.ViewModel).DisposeWith(d);
                this.OneWayBind(ViewModel, vm => vm.NetworkViewModel, v => v.viewHost.ViewModel).DisposeWith(d);
                this.OneWayBind(ViewModel, vm => vm.ValueLabel, v => v.valueLabel.Content).DisposeWith(d);

                //this.BindCommand(ViewModel, vm => vm.AutoLayout, v => v.autoLayoutButton);
                //this.BindCommand(ViewModel, vm => vm.StartAutoLayoutLive, v => v.startAutoLayoutLiveButton);
                //this.WhenAnyObservable(v => v.ViewModel.StartAutoLayoutLive.IsExecuting)
                //    .Select((isRunning) => isRunning ? Visibility.Collapsed : Visibility.Visible)
                //    .BindTo(this, v => v.startAutoLayoutLiveButton.Visibility);

                //this.BindCommand(ViewModel, vm => vm.StopAutoLayoutLive, v => v.stopAutoLayoutLiveButton);
                //this.WhenAnyObservable(v => v.ViewModel.StartAutoLayoutLive.IsExecuting)
                //    .Select((isRunning) => isRunning ? Visibility.Visible : Visibility.Collapsed)
                //    .BindTo(this, v => v.stopAutoLayoutLiveButton.Visibility);
            });
        }

    }
}

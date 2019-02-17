using NodeNetwork.ViewModels;
using ReactiveUI;

namespace UcrPoc.Ports.Axis
{
    public class AxisPortViewModel : PortViewModel
    {
        #region Size
        public double Size
        {
            get => _size;
            set => this.RaiseAndSetIfChanged(ref _size, value);
        }
        private double _size;
        #endregion

        static AxisPortViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new AxisPortView(), typeof(IViewFor<AxisPortViewModel>));
        }
    }
}

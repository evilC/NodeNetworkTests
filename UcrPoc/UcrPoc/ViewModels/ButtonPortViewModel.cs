using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodeNetwork.ViewModels;
using ReactiveUI;
using UcrPoc.Views;

namespace UcrPoc.ViewModels
{
    public class ButtonPortViewModel : PortViewModel
    {
        #region Size
        public double Size
        {
            get => _size;
            set => this.RaiseAndSetIfChanged(ref _size, value);
        }
        private double _size;
        #endregion

        static ButtonPortViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new ButtonPortView(), typeof(IViewFor<ButtonPortViewModel>));
        }
    }
}

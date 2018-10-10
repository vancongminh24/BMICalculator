using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace BMICalculator.Core.ViewModels.Base
{
	public abstract class BaseViewModel : MvxViewModel
	{
		private IMvxNavigationService _navigationService;
		public IMvxNavigationService NavigationService => _navigationService ?? (_navigationService = Mvx.Resolve<IMvxNavigationService>());
	}
}

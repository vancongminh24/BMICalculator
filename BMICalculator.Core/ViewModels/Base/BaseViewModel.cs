using BMICalculator.Core.Services;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace BMICalculator.Core.ViewModels.Base
{
	public abstract class BaseViewModel : MvxViewModel
	{
		//Check this because we can use resolve directly and no need to use this one
		private IMvxNavigationService _navigationService;
		public IMvxNavigationService NavigationService => _navigationService ?? (_navigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>());

		private IBMICalculatorService _bmiCalculatorService;

		public IBMICalculatorService BMICalculatorService =>
			_bmiCalculatorService ?? (_bmiCalculatorService = Mvx.IoCProvider.Resolve<IBMICalculatorService>());
	}
}

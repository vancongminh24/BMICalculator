using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvvmCross.Navigation;
using System.Threading.Tasks;
using MvvmCross;

namespace BMICalculator.Core.ViewModels
{
    public class BMIResultViewModel : MvxViewModel, IMvxViewModel<double>
    {
		private IMvxNavigationService _navigationService;
	    public IMvxNavigationService NavigationService => _navigationService ?? (_navigationService = Mvx.Resolve<IMvxNavigationService>());
		private double _result;

        public BMIResultViewModel()
        {
			BackToMainCommand = new MvxCommand(BackToMain);
            //BackToMainCommand = new MvxCommand(() => { _navigationService.Close(this); });
        }
	
        public double Result
        {
            get => _result;
            set
            {
                _result = value;
                RaisePropertyChanged(() => Result);
            }
        }

        public void Prepare(double bmi)
        {
			//receive result from MBIResultViewModel
	        Result = bmi;
        }

		public MvxCommand BackToMainCommand { get; set; }


        public void BackToMain()
        {
	        NavigationService.Close(this);
        }
    }
}

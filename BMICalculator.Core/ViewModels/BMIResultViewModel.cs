using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvvmCross.Navigation;
using System.Threading.Tasks;

namespace BMICalculator.Core.ViewModels
{
    public class BMIResultViewModel : MvxViewModel, IMvxViewModel<double>
    {
        private readonly IMvxNavigationService _navigationService;
        private double _result;

        public BMIResultViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
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

        public void Prepare(double parameter)
        {
			//receive result from MBIResultViewModel
	        Result = parameter;
        }

		public MvxCommand BackToMainCommand { get; set; }


        public void BackToMain()
        {
            _navigationService.Close(this);
        }
    }
}

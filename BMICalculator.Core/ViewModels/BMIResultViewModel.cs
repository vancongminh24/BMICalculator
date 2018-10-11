using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvvmCross.Navigation;
using System.Threading.Tasks;
using BMICalculator.Core.ViewModels.Base;
using MvvmCross;

namespace BMICalculator.Core.ViewModels
{
    public class BMIResultViewModel : BaseViewModel, IMvxViewModel<double>
    {
		private double _result;
	    public double Result
	    {
		    get => _result;
		    set
		    {
			    _result = value;
			    RaisePropertyChanged(() => Result);
		    }
	    }
	    public MvxCommand BackToMainCommand { get; set; }
		public BMIResultViewModel()
        {
			BackToMainCommand = new MvxCommand(BackToMain);
        }
        public void Prepare(double bmi)
        {
			//receive result from MBIResultViewModel
	        Result = bmi;
        }
		
        public void BackToMain()
        {	      
	        NavigationService.Close(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BMICalculator.Core.Services;
using BMICalculator.Core.ViewModels.Base;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace BMICalculator.Core.ViewModels
{
	public class BMICalculatorViewModel : BaseViewModel
	{
		readonly IBMICalculatorService _bmiCalculatorService;

		private double _bmi;

		public string WeightLabel => "Cân Nặng (kg)"; //same as method{ get {return "can nang";}}
		public string HeightLabel => "Chiều Cao (m)";
		public string BMILabel => "BMI";
		public string CalculateLabel => "Calculate";
		public IMvxCommand ShowBMIResultCommand { get; }

		public BMICalculatorViewModel()
		{
			
			ShowBMIResultCommand = new MvxCommand(OnNavigateToResult);
		}

		private void OnNavigateToResult()
		{
			CalculateBMI();
			NavigationService.Navigate<BMIResultViewModel, double>(BMI);
		}

		public override async Task Initialize()
		{
			await base.Initialize();
			Weight = 0;
			Height = 0;
		}

		public double Weight { get; set; }

		public double Height { get; set; }

		public double BMI
		{
			get => _bmi;
			set => SetProperty(ref _bmi, value);
			//set
			//{
			//	_bmi = value;
			//	RaisePropertyChanged(() => BMI);

			//}
		}

		public void CalculateBMI()
		{
			var bmiCalculatorService = Mvx.IoCProvider.Resolve<IBMICalculatorService>();
			BMI = bmiCalculatorService.CalculateBMI(Weight, Height);
		}
	}
}

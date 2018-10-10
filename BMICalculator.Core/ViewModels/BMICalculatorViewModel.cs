﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BMICalculator.Core.Services;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace BMICalculator.Core.ViewModels
{
	public class BMICalculatorViewModel : MvxViewModel
	{
		readonly IBMICalculatorService _bmiCalculatorService;
		private IMvxNavigationService _navigationService;
		public IMvxNavigationService NavigationService => _navigationService ?? (_navigationService = Mvx.Resolve<IMvxNavigationService>());

		private double _weight;
		private double _height;
		private double _bmi;

		public string WeightLabel => "Cân Nặng (kg)"; //same as method{ get {return "can nang";}}
		public string HeightLabel => "Chiều Cao (m)";
		public string BMILabel => "BMI";
		public string CalculateLabel => "Calculate";
		public IMvxCommand ShowBMIResultCommand { get; }

		public BMICalculatorViewModel(IBMICalculatorService bmiCalculatorService)
		{
			_bmiCalculatorService = bmiCalculatorService;
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
			_weight = 0;
			_height = 0;

		}

		public double Weight
		{
			get => _weight;
			set
			{
				_weight = value;

			}
		}

		public double Height
		{
			get => _height;
			set
			{
				_height = value;
			}
		}

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

		//public IMvxCommand ShowBMIResultCommand { get; set; }



		public void CalculateBMI()
		{
			BMI = _bmiCalculatorService.CalculateBMI(_weight, _height);
		}
	}
}

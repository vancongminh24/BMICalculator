using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using BMICalculator.Core.ViewModels;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using UIKit;
using System;
using System.Windows.Input;
using MvvmCross.Platforms.Ios.Binding.Views.Gestures;

namespace Blank.Views
{
	
	public class BMIView : MvxViewController<BMICalculatorViewModel>
	{
		private UILabel _weightLabel;
		private UITextField _weighTextField;
		private UILabel _heightLabel;
		private UITextField _heightTextField;
		private UIButton _bmiResultButton;
		private string _calculateBMILabelButton;

		public ICommand ShowBMIResultCommand { get; set; }

		public override void ViewDidLoad()
		{
			View = new UIView
			{
				BackgroundColor = UIColor.White,
				MultipleTouchEnabled = false
			};

			base.ViewDidLoad();
			
			InitWeightLabel();
			InitWeightTextField();
			InitHeightLabel();
			InitHeightTextField();
			InitGoToBMIResultsButton();
			
			CreateBinding();
		}

		
		private void InitWeightLabel()
		{
			_weightLabel = new UILabel
			{
				TranslatesAutoresizingMaskIntoConstraints = false,				
			};
			
			View.Add(_weightLabel);

			View.AddConstraints(new []
			{
				NSLayoutConstraint.Create(_weightLabel, NSLayoutAttribute.Top, NSLayoutRelation.Equal, View, NSLayoutAttribute.Top, 1, 70),
				NSLayoutConstraint.Create(_weightLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 15)
			});
		}
		private void InitWeightTextField()
		{
			_weighTextField = new UITextField { TranslatesAutoresizingMaskIntoConstraints = false };
			View.Add(_weighTextField);
			View.AddConstraints(new[]
			{
				NSLayoutConstraint.Create(_weighTextField, NSLayoutAttribute.Top, NSLayoutRelation.Equal, _weightLabel, NSLayoutAttribute.Bottom, 1, 15),
				NSLayoutConstraint.Create(_weighTextField, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 15)
			});
		}
		private void InitHeightLabel()
		{
			_heightLabel = new UILabel() { TranslatesAutoresizingMaskIntoConstraints = false };
			View.Add(_heightLabel);
			View.AddConstraints(new[]
			{
				NSLayoutConstraint.Create(_heightLabel, NSLayoutAttribute.Top, NSLayoutRelation.Equal, _weighTextField, NSLayoutAttribute.Bottom, 1, 15),
				NSLayoutConstraint.Create(_heightLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 15)
			});
		}

		private void InitHeightTextField()
		{
			_heightTextField = new UITextField { TranslatesAutoresizingMaskIntoConstraints = false };
			View.Add(_heightTextField);
			View.AddConstraints(new[]
			{
				NSLayoutConstraint.Create(_heightTextField, NSLayoutAttribute.Top, NSLayoutRelation.Equal, _heightLabel, NSLayoutAttribute.Bottom, 1, 15),
				NSLayoutConstraint.Create(_heightTextField, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 15)
			});
		}
		private void InitGoToBMIResultsButton()
		{
			_bmiResultButton = new UIButton { TranslatesAutoresizingMaskIntoConstraints = false };
			
			_bmiResultButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			_bmiResultButton.Layer.BorderColor = UIColor.Gray.CGColor;
			_bmiResultButton.Layer.BorderWidth = 1;
			//_bmiResultButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
			//_bmiResultButton.ContentEdgeInsets = new UIEdgeInsets(10, 15, 10, 10);

			View.Add(_bmiResultButton);
			View.AddConstraints(new[]
			{
				NSLayoutConstraint.Create(_bmiResultButton, NSLayoutAttribute.Top, NSLayoutRelation.Equal, _heightTextField, NSLayoutAttribute.Bottom, 1, 15),
				//NSLayoutConstraint.Create(_bmiResultButton, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 15)
				NSLayoutConstraint.Create(_bmiResultButton, NSLayoutAttribute.Left, NSLayoutRelation.Equal, _heightTextField, NSLayoutAttribute.Left, 1, 0)
				});

			_bmiResultButton.AddGestureRecognizer(new UITapGestureRecognizer(OnShowBMIResult));
		}

		private void OnShowBMIResult()
		{
			ShowBMIResultCommand?.Execute(null);
		}
		
		private void CreateBinding()
		{
			var bindingSet = this.CreateBindingSet<BMIView, BMICalculatorViewModel>();

			bindingSet.Bind(_weightLabel).To(vm => vm.WeightLabel);
			bindingSet.Bind(_weighTextField).To(vm => vm.Weight);
			bindingSet.Bind(_heightLabel).To(vm => vm.HeightLabel);
			bindingSet.Bind(_heightTextField).To(vm => vm.Height);

			bindingSet.Bind(_bmiResultButton)
				.For("Title")
				.To(vm =>vm.CalculateLabel);

			//bindingSet.Bind(_bmiResultButton.Tap())
			//	.For(v=> v.Command)
			//	.To(vm => vm.ShowBMIResultCommand);

			bindingSet.Bind(this)
				.For(v => v.ShowBMIResultCommand)
				.To(vm => vm.ShowBMIResultCommand);

			bindingSet.Apply();
		}
	}
}
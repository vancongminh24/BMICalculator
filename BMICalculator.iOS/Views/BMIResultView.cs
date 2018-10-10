using System;
using BMICalculator.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using UIKit;

namespace Blank.Views
{
	
	public class BMIResultView : MvxViewController<BMIResultViewModel>
	{
		private UILabel _bmiResultLabel;
		public override void ViewDidLoad()
		{
			View = new UIView
			{
				BackgroundColor = UIColor.White,
				MultipleTouchEnabled = false
			};

			base.ViewDidLoad();

			InitBMIResultLabel();

			CreateBinding();
		}
		
		private void InitBMIResultLabel()
		{
			_bmiResultLabel = new UILabel() { TranslatesAutoresizingMaskIntoConstraints = false };

			//var statusHeight = UIApplication.SharedApplication.StatusBarHidden ? 0 : UIApplication.SharedApplication.StatusBarFrame.Height;
			
			View.Add(_bmiResultLabel);
			View.AddConstraints(new[]
			{
				NSLayoutConstraint.Create(_bmiResultLabel, NSLayoutAttribute.Top, NSLayoutRelation.Equal, View, NSLayoutAttribute.Top, 1, 70),
				NSLayoutConstraint.Create(_bmiResultLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 15)
			});
		}
		private void CreateBinding()
		{
			var bindingSet = this.CreateBindingSet<BMIResultView, BMIResultViewModel>();

			bindingSet.Bind(_bmiResultLabel).To(vm => vm.Result);
			bindingSet.Apply();
		}
	}
}
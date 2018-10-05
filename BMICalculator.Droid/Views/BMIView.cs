using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using BMICalculator.Core.ViewModels;

namespace BMICalculator.Droid.Views
{
    [Activity(Label = "BMI Calculator", MainLauncher = true)]
    public class BMIView : MvxActivity<BMICalculatorViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainBMIView);
        }
    }
}

using MvvmCross.Platforms.Android.Views;
using Android.App;
using Android.OS;
using BMICalculator.Core.ViewModels;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using BMICalculator.Droid;

namespace Playground.Droid.Activities
{
    [MvxActivityPresentation]
    [Activity(Theme = "@style/AppTheme")]
    public class CollectionView : MvxActivity<BMIResultViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.BMIResultView);
        }
    }
}

﻿using BMICalculator.Core;
using Foundation;
using MvvmCross.Platforms.Ios.Core;
using UIKit;

namespace Blank
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register(nameof(AppDelegate))]
	public class AppDelegate : MvxApplicationDelegate<MvxIosSetup<App>, App>
	{
		public override UIWindow Window { get; set; }

		// FinishedLaunching is the very first code to be executed in your app. Don't forget to call base!
		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
			var result = base.FinishedLaunching(application, launchOptions);

			return result;
		}
	}
}



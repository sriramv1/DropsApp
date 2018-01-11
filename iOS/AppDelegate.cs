using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Octane.Xamarin.Forms.VideoPlayer.iOS;
using UIKit;

namespace DropsApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            // Code for starting up the Xamarin Test Cloud Agent
#if DEBUG
			Xamarin.Calabash.Start();
#endif
            FormsVideoPlayer.Init("EC832145735EF08BF6227AE58D2338F6C825B50B");
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}

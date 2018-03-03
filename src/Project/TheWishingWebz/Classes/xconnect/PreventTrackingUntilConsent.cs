using Sitecore.Analytics;
using Sitecore.Analytics.Pipelines.InitializeTracker;
using Sitecore.Analytics.Pipelines.StartTracking;
using Sitecore.Diagnostics;

namespace TheWishingWebz.Classes.xconnect
{
    public class PreventTrackingUntilConsent : InitializeTracker
    {
        public override void Process(StartTrackingArgs args)
        {
            Assert.ArgumentNotNull((object)args, nameof(args));
            Assert.IsNotNull((object)Tracker.Current, "Tracker.Current");
            Assert.IsNotNull((object)Tracker.Current.Session, "Tracker.Current.Session");
            Assert.IsNotNull((object)Tracker.Current.Session.Contact, "Tracker.Current.Session.Contact");

            // Switch to Method #2
            // Use Sitecore.Sites.SiteContext.Current when trying to determine current site
            // Use Tracker.Current.Session.Contact when trying to determine current contact consent status
            bool siteConsentProvided = false;
            
			if(!siteConsentProvided)
			{
				args.AbortPipeline();
			}
			else
			{
				InitializeTrackerPipeline.Run(new InitializeTrackerArgs()
				{
					CanBeRobot = true,
					Session = Tracker.Current.Session,
					IsNewContact = Tracker.Current.Session.Contact.IsNew,
					HttpContext = args.HttpContext
				});
			}
        }
    }
}
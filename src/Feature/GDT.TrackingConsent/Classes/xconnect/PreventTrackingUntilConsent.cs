using GDT.TrackingConsent.Helpers;
using Sitecore.Analytics;
using Sitecore.Analytics.Pipelines.InitializeTracker;
using Sitecore.Analytics.Pipelines.StartTracking;
using Sitecore.Diagnostics;

namespace GDT.TrackingConsent.Classes.xconnect
{
    public class PreventTrackingUntilConsent : InitializeTracker
    {
        public override void Process(StartTrackingArgs args)
        {
            Assert.ArgumentNotNull((object)args, nameof(args));
            Assert.IsNotNull((object)Tracker.Current, "Tracker.Current");
            Assert.IsNotNull((object)Tracker.Current.Session, "Tracker.Current.Session");
            Assert.IsNotNull((object)Tracker.Current.Session.Contact, "Tracker.Current.Session.Contact");

            bool siteConsentProvided = true;//ConsentInfoHelper.isConsented(Tracker.Current.Session.Contact, Sitecore.Sites.SiteContext.Current);
            
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
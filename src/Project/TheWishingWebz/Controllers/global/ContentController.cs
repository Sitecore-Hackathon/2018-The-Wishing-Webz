using Sitecore.Analytics;
using Sitecore.Mvc.Presentation;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using TheWishingWebz.Models.global;
using GDT.TrackingConsent.Helpers;

namespace TheWishingWebz.Controllers.global
{
    public class ContentController : Controller
    {
        public ActionResult Index()
        {
            Content model = new Content();
            model.Initialize(RenderingContext.Current.Rendering);

            return View("~/Views/global/Content.cshtml", model);            
        }

        [HttpGet]
        public JsonResult GetConsent()
        {
            try
            {
                Task<bool?> siteConsentProvided = ConsentInfoHelper.isConsented(Tracker.Current.Session.Contact, Sitecore.Sites.SiteContext.Current);
                if (siteConsentProvided.Result == null)
                    return Json(new { error = false, consentAnswered = false, consented = false }, JsonRequestBehavior.AllowGet);
                else if (siteConsentProvided.Result == true)
                    return Json(new { error = false, consentAnswered = true, consented = true }, JsonRequestBehavior.AllowGet);
                else if (siteConsentProvided.Result == false)
                    return Json(new { error = false, consentAnswered = true, consented = false }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { error = false, consentAnswered = false, consented = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = true, errorMsg = "Msg: " + ex.Message + " || InnerException: " + ex.InnerException + " || StackTrace: " + ex.StackTrace }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult SetConsent()
        {
            string consent = Request.Form["consent"];
            try
            {
                ConsentInfoHelper consentInfoHelper = new ConsentInfoHelper();
                if (!String.IsNullOrWhiteSpace(consent))
                {
                    // Consented                    
                    ConsentInfoHelper.setConsented(Tracker.Current.Session.Contact, Sitecore.Sites.SiteContext.Current, true);

                    return Json(new { error = false, consentAnswered = true, consented = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    // Does Not Consent
                    ConsentInfoHelper.setConsented(Tracker.Current.Session.Contact, Sitecore.Sites.SiteContext.Current, false);

                    return Json(new { error = false, consentAnswered = true, consented = false }, JsonRequestBehavior.AllowGet);
                }                
            }
            catch (Exception ex)
            {
                return Json(new { error = true, errorMsg = "Msg: " + ex.Message + " || InnerException: " + ex.InnerException + " || StackTrace: " + ex.StackTrace }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult SetAccount()
        {
            string name = Request.Form["name"];
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            string consent = Request.Form["accountConsent"];
            
            try
            {
                ConsentInfoHelper consentInfoHelper = new ConsentInfoHelper();
                if (!String.IsNullOrWhiteSpace(consent))
                {
                    // Consented
                    ConsentInfoHelper.setConsented(Tracker.Current.Session.Contact, Sitecore.Sites.SiteContext.Current, true);
                    return Json(new { error = false, consentAnswered = true, consented = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    // Does Not Consent
                    ConsentInfoHelper.setConsented(Tracker.Current.Session.Contact, Sitecore.Sites.SiteContext.Current, false);
                    return Json(new { error = false, consentAnswered = true, consented = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { error = true, errorMsg = "Msg: " + ex.Message + " || InnerException: " + ex.InnerException + " || StackTrace: " + ex.StackTrace }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
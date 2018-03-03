using Sitecore.Analytics;
using Sitecore.Mvc.Presentation;
using System;
using System.Web.Mvc;
using TheWishingWebz.Models.global;

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
                // TO DO: Get Consent Off Of Contact, and Return Answer Below
                ConsentInfoHelper consentInfoHelper = new ConsentInfoHelper();
                Task<bool?> siteConsentProvided = consentInfoHelper.isConsented(Tracker.Current.Session.Contact, Sitecore.Sites.SiteContext.Current);

                return Json(new { error = false, consentAnswered = true, consented = true }, JsonRequestBehavior.AllowGet);
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
                if(!String.IsNullOrWhiteSpace(consent))
                {
                    // Consented

                    // TO DO: Submit Consent Answer

                    return Json(new { error = false, consentAnswered = true, consented = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    // Does Not Consent

                    // TO DO: Submit Consent Answer

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
                if (!String.IsNullOrWhiteSpace(consent))
                {
                    // Consented

                    // TO DO: Submit Account (and Consent) Answer

                    return Json(new { error = false, consentAnswered = true, consented = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    // Does Not Consent

                    // TO DO: Submit Account (and Consent) Answer

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
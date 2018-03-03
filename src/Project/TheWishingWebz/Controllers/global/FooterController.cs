using Sitecore.Mvc.Presentation;
using System.Web.Mvc;
using TheWishingWebz.Models.global;

namespace TheWishingWebz.Controllers.global
{
    public class FooterController : Controller
    {
        public ActionResult Index()
        {
            Footer model = new Footer();
            model.Initialize(RenderingContext.Current.Rendering);

            return View("~/Views/global/Footer.cshtml", model);            
        }
    }
}
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;
using TheWishingWebz.Models.global;

namespace TheWishingWebz.Controllers.global
{
    public class HeaderController : Controller
    {
        public ActionResult Index()
        {
            Header model = new Header();
            model.Initialize(RenderingContext.Current.Rendering);

            return View("~/Views/global/Header.cshtml", model);            
        }
    }
}
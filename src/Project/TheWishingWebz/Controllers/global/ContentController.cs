using Sitecore.Mvc.Presentation;
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
    }
}
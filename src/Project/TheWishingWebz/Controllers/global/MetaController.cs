using Sitecore.Mvc.Presentation;
using System.Web.Mvc;
using TheWishingWebz.Models.global;

namespace TheWishingWebz.Controllers.global
{
    public class MetaController : Controller
    {
        public ActionResult Index()
        {
            Meta model = new Meta();
            model.Initialize(RenderingContext.Current.Rendering);

            return View("~/Views/global/Meta.cshtml", model);            
        }
    }
}
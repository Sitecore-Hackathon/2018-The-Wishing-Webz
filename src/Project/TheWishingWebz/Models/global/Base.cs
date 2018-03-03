using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System.Threading;
using TheWishingWebz.Classes;

namespace TheWishingWebz.Models.global
{
    public class Base
    {
        //BaseInfo Model Properties
        public Rendering rendering { get; set; }
        public Item renderingItem { get; set; }
        public Item pageItem { get; set; }
        public string siteRootPath { get; set; }
        public Item siteRootItem { get; set; }
        public string strSiteName { get; set; }

        /// <summary>
        /// Initialization of BaseInfo Model
        /// </summary>
        /// <param name="rendering"></param>
        public void BaseInitialize(Rendering rendering)
        {
            this.rendering = rendering;
            renderingItem = rendering.Item;
            pageItem = PageContext.Current.Item;

            siteRootPath = Sitecore.Context.Site.RootPath;
            siteRootItem = Sitecore.Context.Database.GetItem(siteRootPath);
            strSiteName = Utilities.getFieldValue(siteRootItem, "Site Name");

            Thread.CurrentThread.CurrentUICulture = Sitecore.Context.Language.CultureInfo;
        }
    }
}
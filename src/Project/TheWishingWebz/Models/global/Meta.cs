using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using TheWishingWebz.Classes;

namespace TheWishingWebz.Models.global
{
    public class Meta : Base
    {
        public string strMetaTitle { get; set; }
        public string strMetaKeywords { get; set; }
        public string strMetaDescription { get; set; }

        public void Initialize(Rendering rendering)
        {
            BaseInitialize(rendering);

            // Meta Title
            strMetaTitle = Utilities.getFieldValue(pageItem, "Meta Title");
            if (string.IsNullOrWhiteSpace(strMetaTitle))
                strMetaTitle = Utilities.getFieldValue(pageItem, "Title");
            // Meta Keywords
            strMetaKeywords = Utilities.getFieldValue(pageItem, "Meta Keywords");
            // Meta Description
            strMetaDescription = Utilities.getFieldValue(pageItem, "Meta Description");
        }
    }
}
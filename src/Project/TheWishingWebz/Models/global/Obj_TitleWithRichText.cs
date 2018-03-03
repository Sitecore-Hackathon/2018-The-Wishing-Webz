using Sitecore.Data.Items;
using TheWishingWebz.Classes;

namespace TheWishingWebz.Models.global
{
    public class Obj_TitleWithRichText
    {
        public string title { get; set; }
        public string description { get; set; }

        public Obj_TitleWithRichText()
        {
            title = string.Empty;
            description = string.Empty;
        }

        public Obj_TitleWithRichText(Item item)
        {
            if(item != null)
            {
                title = Utilities.getFieldValue(item, "Title");
                description = Utilities.getFieldValue(item, "Description");
            }
            else
            {
                title = string.Empty;
                description = string.Empty;
            }
            
        }
    }
}
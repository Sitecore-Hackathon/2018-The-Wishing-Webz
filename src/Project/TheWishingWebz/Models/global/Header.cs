using Sitecore.Mvc.Presentation;
using TheWishingWebz.Classes;

namespace TheWishingWebz.Models.global
{
    public class Header : Base
    {
        public Obj_TitleWithRichText objTitleWithRichText { get; set; }        

        public void Initialize(Rendering rendering)
        {
            BaseInitialize(rendering);
            objTitleWithRichText = new Obj_TitleWithRichText(Utilities.getReferenceFieldValue(siteRootItem, "Header"));          
        }
    }
}
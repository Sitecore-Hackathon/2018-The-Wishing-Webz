using Sitecore.Mvc.Presentation;

namespace TheWishingWebz.Models.global
{
    public class Content : Base
    {
        public Obj_TitleWithRichText objTitleWithRichText { get; set; }        

        public void Initialize(Rendering rendering)
        {
            BaseInitialize(rendering);

            objTitleWithRichText = new Obj_TitleWithRichText(pageItem);          
        }
    }
}
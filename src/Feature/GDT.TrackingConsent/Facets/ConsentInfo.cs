using Sitecore.XConnect;
using GDT.TrackingConsent.Models.Objects;
using System;
using System.Collections.Generic;

namespace GDT.TrackingConsent.Facets
{
    [Serializable]
    [FacetKey(DefaultFacetKey)]
    public class ConsentInfo : Sitecore.XConnect.Facet
    {
        public const string DefaultFacetKey = "ConsentInfo";

        public ConsentInfo()
        {
            Consents = new List<ConsentObject>();
        }
        
        public List<ConsentObject> Consents { get; set; } // Example: ABC12345
        
    }
}

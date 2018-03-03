using System;
using Sitecore.Globalization;
using Sitecore.Data;

namespace GDT.TrackingConsent.Models.Objects
{
    public class ConsentObject
    {
        public ConsentObject()
        {
            rootId = ID.Null;
            policyId = ID.Null;
            policyVersion = -1;
            language = String.Empty;
            timestamp = DateTime.Now;
            consent = false;
        }

        public ConsentObject(ID rootId, ID policyId, int policyVersion, string language, Boolean consent)
        {
            this.rootId = rootId;
            this.policyId = policyId;
            this.policyVersion = policyVersion;
            this.language = language;
            this.consent = consent;
        }


        public ID rootId { get; set; }
        public ID policyId { get; set; }
        public int policyVersion { get; set; }
        public string language { get; set; }
        public DateTime timestamp { get; set; }
        public Boolean consent { get; set; }
    }
}

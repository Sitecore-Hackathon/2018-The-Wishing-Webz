using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Sites;
using Sitecore.XConnect;
using System;
using System.Linq;
using GDT.TrackingConsent.Facets;
using GDT.TrackingConsent.Models.Objects;

namespace GDT.TrackingConsent.Helpers
{
    class ConsentInfoHelper
    {
        public bool isConsented(Contact contact, SiteContext context, Item currentPolicyItem)
        {
            Boolean isConsented = false;
            if (contact != null && currentPolicyItem != null && context != null) {
                using (Sitecore.XConnect.Client.XConnectClient client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
                {
                    try
                    {
                        var facet = contact.GetFacet<ConsentInfo>(ConsentInfo.DefaultFacetKey);

                        if(facet != null)
                        {
                            if(facet.Consents != null)
                            {
                                ConsentObject obj = facet.Consents.FirstOrDefault<ConsentObject>(x => x.rootId.Equals(Sitecore.Context.Database.GetItem(context.RootPath).ID)
                                                                                && x.language.Equals(context.Language)
                                                                                && x.policyId.Equals(currentPolicyItem.ID)
                                                                                && x.policyVersion.Equals(currentPolicyItem.Version.Number));
                                if (obj != null && obj.consent)
                                    isConsented = true;
                            }
                        }
                    }
                    catch (XdbExecutionException ex)
                    {
                        //do something
                    }
                }
            }
            return isConsented;
        }

        public async void setConsented(Contact contact, SiteContext context, Item currentPolicyItem, Boolean consent)
        {
            if (contact != null && currentPolicyItem != null && context != null)
            {
                using (Sitecore.XConnect.Client.XConnectClient client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
                {
                    try
                    {
                        var facet = contact.GetFacet<ConsentInfo>(ConsentInfo.DefaultFacetKey);
                        ID rootId = Sitecore.Context.Database.GetItem(context.RootPath).ID;
                        if (facet != null)
                        {
                            if (facet.Consents != null)
                            {
                                ConsentObject obj = facet.Consents.FirstOrDefault<ConsentObject>(x => x.rootId.Equals(rootId)
                                                                                && x.language.Equals(context.Language)
                                                                                && x.policyId.Equals(currentPolicyItem.ID)
                                                                                && x.policyVersion.Equals(currentPolicyItem.Version.Number));

                                if(obj != null)
                                    obj.consent = consent;
                                else
                                {
                                    facet.Consents.Add(new ConsentObject(rootId, currentPolicyItem.ID, currentPolicyItem.Version.Number, context.Language, consent));
                                }

                                // Set the updated facet
                                client.SetFacet(contact, ConsentInfo.DefaultFacetKey, facet);
                            }
                        }
                        else
                        {
                            facet = new ConsentInfo();
                            facet.Consents.Add(new ConsentObject(rootId, currentPolicyItem.ID, currentPolicyItem.Version.Number, context.Language, consent));
                        }

                        await client.SubmitAsync();
                    }
                    catch (XdbExecutionException ex)
                    {
                        // Handle exception
                    }
                }
            }
        }
    }
}

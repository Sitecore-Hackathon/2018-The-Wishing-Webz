using GDT.TrackingConsent.Facets;
using GDT.TrackingConsent.Models.Objects;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Sites;
using Sitecore.XConnect;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GDT.TrackingConsent.Helpers
{
    public class ConsentInfoHelper
    {
        public async Task<bool?> isConsented(Sitecore.Analytics.Tracking.Contact contact, SiteContext context)
        {
            Boolean? isConsented = null;
            if (contact != null && context != null) {
                using (Sitecore.XConnect.Client.XConnectClient client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
                {
                    try
                    {
                        var contactReference = new ContactReference(contact.ContactId);
                        Task<Contact> contactTask = client.GetContactAsync(contactReference, new ContactExpandOptions() { });

                        Contact XContact = await contactTask;

                        var facet = XContact.GetFacet<ConsentInfo>(ConsentInfo.DefaultFacetKey);

                        if (facet != null)
                        {
                            if(facet.Consents != null)
                            {
                                Item rootItem = Sitecore.Context.Database.GetItem(context.RootPath);
                                ReferenceField xconsentPolicyField = rootItem.Fields["XConsent Policy"];
                                Item xconsentPolicy = xconsentPolicyField.TargetItem;

                                ConsentObject obj = facet.Consents.FirstOrDefault<ConsentObject>(x => x.rootId.Equals(rootItem.ID)
                                                                                && x.language.Equals(context.Language)
                                                                                && x.policyId.Equals(xconsentPolicy.ID)
                                                                                && x.policyVersion.Equals(xconsentPolicy.Version.Number));
                                if (obj != null && obj.consent)
                                    isConsented = true;
                                else if(obj != null && !obj.consent)
                                {
                                    isConsented = false;
                                }
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

        public async void setConsented(Sitecore.Analytics.Tracking.Contact contact, SiteContext context, Boolean consent)
        {
            if (contact != null && context != null)
            {
                Item rootItem = Sitecore.Context.Database.GetItem(context.RootPath);
                ReferenceField xconsentPolicyField = rootItem.Fields["XConsent Policy"];
                Item xconsentPolicy = xconsentPolicyField.TargetItem;

                if (rootItem != null && xconsentPolicy != null)
                {
                    using (Sitecore.XConnect.Client.XConnectClient client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
                    {
                        try
                        {
                            var contactReference = new ContactReference(contact.ContactId);
                            Task<Contact> contactTask = client.GetContactAsync(contactReference, new ContactExpandOptions() { });

                            Contact XContact = await contactTask;

                            var facet = XContact.GetFacet<ConsentInfo>(ConsentInfo.DefaultFacetKey);


                            if (facet != null)
                            {
                                if (facet.Consents != null)
                                {
                                    ConsentObject obj = facet.Consents.FirstOrDefault<ConsentObject>(x => x.rootId.Equals(rootItem.ID)
                                                                                    && x.language.Equals(context.Language)
                                                                                    && x.policyId.Equals(xconsentPolicy.ID)
                                                                                    && x.policyVersion.Equals(xconsentPolicy.Version.Number));

                                    if (obj != null)
                                    {
                                        obj.consent = consent;
                                    }
                                    else
                                    {
                                        facet.Consents.Add(new ConsentObject(rootItem.ID, xconsentPolicy.ID, xconsentPolicy.Version.Number, context.Language, consent));
                                    }

                                    // Set the updated facet
                                    client.SetFacet(XContact, ConsentInfo.DefaultFacetKey, facet);
                                }
                            }
                            else
                            {
                                facet = new ConsentInfo();
                                facet.Consents.Add(new ConsentObject(rootItem.ID, xconsentPolicy.ID, xconsentPolicy.Version.Number, context.Language, consent));
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
}

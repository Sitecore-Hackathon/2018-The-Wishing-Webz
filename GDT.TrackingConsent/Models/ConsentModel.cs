using Sitecore.XConnect;
using Sitecore.XConnect.Schema;
using System;
using XConnectTut.Facets;

namespace GDT.TrackingConsent.Models
{
    public class ConsentModel
    {
        public static XdbModel Model { get; } = BuildModel();

        private static XdbModel BuildModel()
        {
            XdbModelBuilder modelBuilder = new XdbModelBuilder("ConsentModel", new XdbModelVersion(1, 0));

            modelBuilder.ReferenceModel(Sitecore.XConnect.Collection.Model.CollectionModel.Model);
            // Facets and events here
            modelBuilder.DefineFacet<Contact, ConsentInfo>(ConsentInfo.DefaultFacetKey);

            return modelBuilder.BuildModel();
        }
    }
}

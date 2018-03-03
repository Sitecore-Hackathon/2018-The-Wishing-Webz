using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;

namespace TheWishingWebz.Classes
{
    public class Utilities
    {
        /// <summary>
        /// getFieldValue
        /// </summary>
        /// <param name="itm"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string getFieldValue(Item itm, string fieldName)
        {
            string fieldValue = String.Empty;

            if (itm != null)
                fieldValue = (itm.Fields[fieldName] != null && !String.IsNullOrEmpty(itm.Fields[fieldName].Value) ? itm.Fields[fieldName].Value : String.Empty);

            return fieldValue;
        }

        public static Item getReferenceFieldValue(Item itm, string fieldName)
        {
            try
            {
                ReferenceField referenceField = itm.Fields[fieldName];
                return itm.Database.GetItem(referenceField.TargetItem.ID, itm.Language);
            }
            catch
            {
                return null;
            }
        }
    }
}
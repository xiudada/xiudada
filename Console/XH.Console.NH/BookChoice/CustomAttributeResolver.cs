using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Console.NH.BookChoice
{
    public class CustomAttributeResolver : ICustomAttributeResolver
    {
        private readonly Type _customAttributeType;
        private readonly Type _customAttributeFieldType;

        public CustomAttributeResolver()
        {
            _customAttributeFieldType = typeof(CustomAttributeFieldAttribute);
            _customAttributeType = typeof(CustomAttributeAttribute);
        }

        private Dictionary<string, object> InternalResolveCustomAttribute(object @object, string attributeNamePrefix)
        {
            Dictionary<string, object> customAttributes = new Dictionary<string, object>();

            if (@object != null)
            {
                foreach (var property in @object.GetType().GetProperties())
                {
                    object value = property.GetValue(@object);
                    if (value == null)
                    {
                        continue;
                    }

                    // judge if this is target property
                    var customFieldAttribute = property.GetCustomAttributes(_customAttributeFieldType, true).FirstOrDefault() as CustomAttributeFieldAttribute;
                    if (customFieldAttribute != null)
                    {
                        string attributeName = !String.IsNullOrEmpty(customFieldAttribute.AttributeName) ? customFieldAttribute.AttributeName : property.Name;
                        string prefix = customFieldAttribute.AppendPrefix ? attributeNamePrefix : String.Empty;
                        string key = $"{prefix}{attributeName}";

                        // Over write
                        customAttributes[key] = value;
                    }
                    else
                    {
                        var customAttribute = property.GetCustomAttributes(_customAttributeType, true).FirstOrDefault() as CustomAttributeAttribute;
                        if (customAttribute != null)
                        {
                            var innerCustomeAttributes = InternalResolveCustomAttribute(value, $"{attributeNamePrefix}{customAttribute.Prefix}");

                            foreach (var keyValuePair in innerCustomeAttributes)
                            {
                                customAttributes[keyValuePair.Key] = keyValuePair.Value;
                            }
                        }
                    }
                }
            }

            return customAttributes;
        }

        public Dictionary<string, object> ResolveCustomAttribute(object @object)
        {
            return InternalResolveCustomAttribute(@object, String.Empty);
        }
    }
}

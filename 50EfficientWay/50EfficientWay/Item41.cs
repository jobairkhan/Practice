using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _50EfficientWay
{
    public static class Item41
    {
        public static void Execute()
        {
            dynamic dynamicProperties = new DynamicPropertyBag();
            try
            {
                Console.WriteLine(dynamicProperties.AnyProperty);
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                Console.WriteLine("There are no properties");
            }
        }
    }

    class DynamicPropertyBag : System.Dynamic.DynamicObject
    {
        private Dictionary<string, object> storage = new Dictionary<string, object>();

        public new bool TryGetMember(System.Dynamic.GetMemberBinder binder, out object result)
        {
            if (storage.ContainsKey(binder.Name))
            {
                result = storage[binder.Name];
                return true;
            }
            result = null;
            return false;
        }

        public override bool TrySetMember(System.Dynamic.SetMemberBinder binder, object value)
        {
            string key = binder.Name;
            if (storage.ContainsKey(key))
            {
                storage[key] = value;
            }
            else
            {
                storage.Add(key, value);
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();
            foreach (var item in storage)
                message.AppendFormat("{0}:\t{1}\n", item.Key,
                item.Value);
            return message.ToString();
        }

    }
}

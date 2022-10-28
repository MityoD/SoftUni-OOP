using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public static class Validator 
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propInfo = obj.GetType().GetProperties();

            foreach (var property in propInfo)
            {
                var attributes = property
                    .GetCustomAttributes()
                    .Where(x => x.GetType().IsSubclassOf(typeof(MyValidationAttribute)))
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (MyValidationAttribute item in attributes)
                {
                    bool isValid = item.IsValid(property.GetValue(obj));
                    if (!isValid)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleDialogFlow.API.Helpers
{
    public static class DictionaryHelper
    {

        #region Methods
        public static T GetValue<T>(Dictionary<string, object> source, string keyName)
        {
            T value = default(T);
            if (source != null)
            {
                var actualKeyName = source.Keys.FirstOrDefault(o => o.ToLower() == keyName.ToLower());
                if (!string.IsNullOrEmpty(actualKeyName))
                {
                    value = (T)source[actualKeyName];
                }
            }
            return value;
        }
        #endregion

    }
}

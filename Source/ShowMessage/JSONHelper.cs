using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace ShowMessage
{
    public class JSONHelper
    {
        static JavaScriptSerializer serializer = new JavaScriptSerializer();
        public static T deserialization<T>(string jsonString)
        {

            return serializer.Deserialize<T>(jsonString);

        }

    }
}

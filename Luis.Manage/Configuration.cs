using System;
using System.Collections.Generic;
using System.Text;

namespace LuisManager
{
    public static class LuisConfiguration
    {
        public static string RegionUrl => "https://westeurope.api.cognitive.microsoft.com/luis/v2.0/apps/";
        public static string AppId => "4f94b853-1d90-4f28-9325-10e629fd6267";
        public static string Params => "?verbose=true&timezoneOffset=0&subscription-key=";
        public static string SubscriptionKey => "17eb6f08cf7e4aa69b869abd0adcd517";
        public static string EndpointUrl => RegionUrl + AppId + Params + SubscriptionKey + "&q=";
    }
}

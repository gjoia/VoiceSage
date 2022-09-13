using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoiceSage.Web
{
    public static class SD
    {
        public static string ContactAPIBase { get; set; }
        public enum ApiType 
        { 
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}

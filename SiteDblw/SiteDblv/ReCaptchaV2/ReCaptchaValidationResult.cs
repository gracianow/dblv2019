using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SiteDblv.ReCaptchaV2
{
    public class ReCaptchaValidationResult
    {
        public bool Success { get; set; }
        public string HostName { get; set; }
        [Newtonsoft.Json.JsonProperty("challenge_ts")]
        public string TimeStamp { get; set; }
        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
 
    }




}
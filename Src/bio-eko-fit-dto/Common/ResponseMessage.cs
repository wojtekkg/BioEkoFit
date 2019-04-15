using System.Collections.Generic;
using System.Net;
using bio_eko_fit_dto.Extensions;
using Newtonsoft.Json;

namespace bio_eko_fit_dto.Common
{
    public class ResponseMessage 
    {
        [JsonProperty("code")]
        public HttpStatusCode StatusCode { get; set; }
        
        [JsonProperty("status")]
        public string Status => StatusCode.ToString();

        [JsonProperty("message", NullValueHandling=NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty("parameters", NullValueHandling=NullValueHandling.Ignore)]
        public string[] Parameters { get; set; }

        [JsonProperty("data", NullValueHandling=NullValueHandling.Ignore)]
        public object Data { get; set; }

        public ResponseMessage(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            StatusCode = statusCode;
        }
    }
}
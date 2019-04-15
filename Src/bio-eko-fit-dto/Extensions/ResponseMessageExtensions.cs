using System.Collections.Generic;
using System.Linq;
using System.Net;
using bio_eko_fit_dto.Common;

namespace bio_eko_fit_dto.Extensions
{
    public static class ResponseMessageExtensions
    {
        public static T TransformToFault<T>(this T response, HttpStatusCode statusCode = HttpStatusCode.InternalServerError, string message = FaultCode.INTERNAL_SERVER_ERROR, string[] parameters = null)
        where T : ResponseMessage
        {
            response.StatusCode = statusCode;
            response.Message = message;
            response.Parameters = parameters;
            response.Data = null;
            return response;
        }
    }
}
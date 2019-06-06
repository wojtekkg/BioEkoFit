using System;
using System.Threading.Tasks;
using bio_eko_fit_database;
using bio_eko_fit_dto.Common;
using Microsoft.Extensions.Logging;
using bio_eko_fit_dto.Extensions;
using RawRabbit;
using System.Net;

namespace bio_eko_fit
{
    public abstract class BaseService
    {        
        protected readonly IBusClient _client;
        protected readonly ILogger _logger;
        private string _serviceName;

        public BaseService(IBusClient client, ILogger logger, string serviceName)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _serviceName = serviceName;
            InitializeServices();
        }

        protected virtual void InitializeServices()
        {
            _logger.LogInformation($"{_serviceName} initialized.");
        }

        protected Task<TRES> HandleRequest<TRES>(Func<Task<TRES>> action) where TRES: ResponseMessage
        {            
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Task.FromResult((TRES)CreateFaultMessage());
            }
        }

        private ResponseMessage CreateFaultMessage(HttpStatusCode statusCode = HttpStatusCode.InternalServerError, string message = FaultCode.INTERNAL_SERVER_ERROR, string[] parameters = null)
        {
            return new ResponseMessage
            {

                StatusCode = statusCode,
                Message = message,
                Parameters = parameters,
                Data = null
            };
        }

        protected Task<ResponseMessage> Ok()
        {
            return Task.FromResult(new ResponseMessage());
        }

        protected Task<ResponseMessage> Fault(HttpStatusCode statusCode = HttpStatusCode.InternalServerError, string message = FaultCode.INTERNAL_SERVER_ERROR, string[] parameters = null)
        {
            return Task.FromResult(CreateFaultMessage(statusCode, message, parameters));
        }
    }
}
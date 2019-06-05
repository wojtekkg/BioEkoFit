using System;
using System.Threading.Tasks;
using bio_eko_fit_database;
using bio_eko_fit_dto.Common;
using Microsoft.Extensions.Logging;
using bio_eko_fit_dto.Extensions;
using RawRabbit;

namespace bio_eko_fit
{
    public abstract class BaseService
    {        
        protected readonly IBusClient _client;
        protected readonly IContextFactory _contextFactory;
        protected readonly ILogger _logger;
        private string _serviceName;

        public BaseService(IBusClient client, IContextFactory contextFactory, ILogger logger, string serviceName)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
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
                return Task.FromResult((TRES)new ResponseMessage().TransformToFault());
            }
        }
    }
}
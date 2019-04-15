using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bio_eko_fit_dto;
using bio_eko_fit_dto.Products;
using bio_eko_fit_database;
using bio_eko_fit_database.Entities;
using bio_eko_fit_dto.Extensions;
using RawRabbit;
using RawRabbit.Context;
using bio_eko_fit_dto.Common;
using System.Net;
using Microsoft.Extensions.Logging;

namespace bio_eko_fit.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IBusClient _client;
        private readonly IContextFactory _contextFactory;
        private readonly ILogger _logger;

        public ProductsService(IBusClient client, IContextFactory contextFactory, ILogger<ProductsService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            ServiceInitialization();
        }

        private void ServiceInitialization()
        {
            _client.RespondAsync<GetProductsRequest, ResponseMessage>(GetProducts);
            _client.RespondAsync<DeleteProductRequest, ResponseMessage>(DeleteProduct);
            _client.RespondAsync<CreateProductRequest, ResponseMessage>(InsertProduct);
            _client.RespondAsync<UpdateProductRequest, ResponseMessage>(UpdateProduct);
            _logger.LogInformation($"{nameof(ProductsService)} initialized.");
        }
    
        private Task<ResponseMessage> GetProducts(GetProductsRequest request, MessageContext msgContext)
        {
            var response = new ResponseMessage();
            try
            {
                using (var context = _contextFactory.CreateDefaultContext())
                {
                    var query = context.Products.AsEnumerable();
                    if (request.Id.HasValue)
                    {   
                        query = query.Where(x => x.Id == request.Id.Value);
                    }
                    response.Data = query.Select(x => new Product(){ Id = x.Id, Name = x.Name }).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.TransformToFault();
            }
            return Task.FromResult(response);
        } 

        private Task<ResponseMessage> DeleteProduct(DeleteProductRequest request, MessageContext msgContext)
        {
            var response = new ResponseMessage();
            try
            {
                using (var context = _contextFactory.CreateDefaultContext())
                {
                    context.Products.Remove(new ProductEntity { Id = request.Id });
                    context.SaveChanges();
                }        
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.TransformToFault();
            }
            return Task.FromResult(response);
        }

        private Task<ResponseMessage> InsertProduct(CreateProductRequest request, MessageContext msgContext)
        {
            var response = new ResponseMessage();
            try
            {
                if (string.IsNullOrEmpty(request.Name))
                {
                    return Task.FromResult(response);
                }
                using (var context = _contextFactory.CreateDefaultContext())
                {
                    context.Products.Add(new ProductEntity { Name = request.Name });
                    context.SaveChanges();
                }        
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.TransformToFault();
            }
            return Task.FromResult(response);
        }

        private Task<ResponseMessage> UpdateProduct(UpdateProductRequest request, MessageContext msgContext)
        {
            var response = new ResponseMessage();
            try
            {
                using (var context = _contextFactory.CreateDefaultContext())
                {
                    var product = context.Products.FirstOrDefault(x => x.Id == request.Id);
                    if (product == null)
                    {
                        return Task.FromResult(response);
                    }
                    product.Name = request.Name;
                    context.SaveChanges();
                }        
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = response.TransformToFault();
            }
            return Task.FromResult(response);
        }
    }
}
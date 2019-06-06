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
    public class ProductsService : BaseService, IProductsService
    {
        public ProductsService(IBusClient client, IContextFactory contextFactory, ILogger<ProductsService> logger)
        : base(client, contextFactory, logger, nameof(ProductsService))
        {
        }

        protected override void InitializeServices()
        {
            _client.RespondAsync<GetProductsRequest, ResponseMessage>((req, msgContext) => HandleRequest(() => GetProducts(req, msgContext)));
            _client.RespondAsync<DeleteProductRequest, ResponseMessage>((req, msgContext) => HandleRequest(() => DeleteProduct(req, msgContext)));
            _client.RespondAsync<CreateProductRequest, ResponseMessage>((req, msgContext) => HandleRequest(() => InsertProduct(req, msgContext)));
            _client.RespondAsync<UpdateProductRequest, ResponseMessage>((req, msgContext) => HandleRequest(() => UpdateProduct(req, msgContext)));
            base.InitializeServices();
        }

        private Task<ResponseMessage> GetProducts(GetProductsRequest request, MessageContext msgContext)
        {
            var response = new ResponseMessage();
            using (var context = _contextFactory.CreateDefaultContext())
            {
                var query = context.Products.AsEnumerable();
                if (request.Id.HasValue)
                {   
                    query = query.Where(x => x.Id == request.Id.Value);
                }
                var products = query.Select(x => new Product(){ Id = x.Id, Name = x.Name }).ToList();
                if (products.Count == 0)
                {
                    return Task.FromResult(response.TransformToFault(HttpStatusCode.NotFound));
                }
                response.Data = products;
            }
            return Task.FromResult(response);
        } 

        private Task<ResponseMessage> DeleteProduct(DeleteProductRequest request, MessageContext msgContext)
        {
            var response = new ResponseMessage();
            using (var context = _contextFactory.CreateDefaultContext())
            {
                context.Products.Remove(new ProductEntity { Id = request.Id });
                context.SaveChanges();
            }        
            return Task.FromResult(response);
        }

        private Task<ResponseMessage> InsertProduct(CreateProductRequest request, MessageContext msgContext)
        {
            var response = new ResponseMessage();
            if (string.IsNullOrEmpty(request.Name))
            {
                return Task.FromResult(response.TransformToFault(HttpStatusCode.BadRequest, FaultCode.NULL_OR_EMPTY, new string[] {nameof(request.Name)}));
            }
            using (var context = _contextFactory.CreateDefaultContext())
            {
                context.Products.Add(new ProductEntity { Name = request.Name });
                context.SaveChanges();
            }        
            return Task.FromResult(response);
        }

        private Task<ResponseMessage> UpdateProduct(UpdateProductRequest request, MessageContext msgContext)
        {
            var response = new ResponseMessage();
            using (var context = _contextFactory.CreateDefaultContext())
            {
                var product = context.Products.FirstOrDefault(x => x.Id == request.Id);
                if (product == null)
                {
                    return Task.FromResult(response.TransformToFault(HttpStatusCode.BadRequest, FaultCode.PRODUCT_FOR_UPDATE_NOT_FOUND ));
                }
                product.Name = request.Name;
                context.SaveChanges();
            }                   
            return Task.FromResult(response);
        }
    }
}
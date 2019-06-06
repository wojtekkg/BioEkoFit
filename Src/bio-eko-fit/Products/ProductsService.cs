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
using bio_eko_fit_database.Products;

namespace bio_eko_fit.Products
{
    public class ProductsService : BaseService, IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        public ProductsService(IBusClient client, ILogger<ProductsService> logger, IProductsRepository productsRepository)
        : base(client, logger, nameof(ProductsService))
        {
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
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
            var products = _productsRepository.GetProducts(request.Id);
            if (request.Id.HasValue && products.Count == 0)
            {
                return Fault(HttpStatusCode.NotFound);
            }
            response.Data = products;
            return Task.FromResult(response);
        } 

        private Task<ResponseMessage> DeleteProduct(DeleteProductRequest request, MessageContext msgContext)
        {
            _productsRepository.DeleteProduct(request.Id);
            return Ok();
        }

        private Task<ResponseMessage> InsertProduct(CreateProductRequest request, MessageContext msgContext)
        {
            if (string.IsNullOrEmpty(request.Product.Name))
            {
                return Fault(HttpStatusCode.BadRequest, FaultCode.NULL_OR_EMPTY, new string[] {nameof(request.Product.Name)});
            }
            _productsRepository.InsertProduct(request.Product);
            return Ok();
        }

        private Task<ResponseMessage> UpdateProduct(UpdateProductRequest request, MessageContext msgContext)
        {
            _productsRepository.UpdateProduct(request.Product);   
            return Ok();
        }
    }
}
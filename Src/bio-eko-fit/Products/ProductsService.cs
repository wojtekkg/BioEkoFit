using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bio_eko_fit_dto;
using bio_eko_fit_dto.Products;
using bio_eko_fit_database;
using bio_eko_fit_database.Entities;
using bio_eko_fit_dto.Extensions;
using bio_eko_fit_dto.Common;
using System.Net;
using Microsoft.Extensions.Logging;
using bio_eko_fit_database.Products;

namespace bio_eko_fit.Products
{
    public class ProductsService : BaseService, IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        public ProductsService(ILogger<ProductsService> logger, IProductsRepository productsRepository)
        : base(logger, nameof(ProductsService))
        {
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
        }

        public Task<ResponseMessage> GetProducts(GetProductsRequest request)
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

        public Task<ResponseMessage> DeleteProduct(DeleteProductRequest request)
        {
            _productsRepository.DeleteProduct(request.Id);
            return Ok();
        }

        public Task<ResponseMessage> CreateProduct(CreateProductRequest request)
        {
            if (string.IsNullOrEmpty(request.Product.Name))
            {
                return Fault(HttpStatusCode.BadRequest, FaultCode.NULL_OR_EMPTY, new string[] {nameof(request.Product.Name)});
            }
            _productsRepository.InsertProduct(request.Product);
            return Ok();
        }

        public Task<ResponseMessage> UpdateProduct(UpdateProductRequest request)
        {
            _productsRepository.UpdateProduct(request.Product);   
            return Ok();
        }
    }
}
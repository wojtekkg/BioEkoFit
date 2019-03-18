using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bio_eko_fit_dto;
using bio_eko_fit_dto.Products;
using bio_eko_fit_database;
using bio_eko_fit_database.Entities;
using RawRabbit;
using RawRabbit.Context;

namespace bio_eko_fit.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IBusClient _client;
        private readonly IContextFactory _contextFactory;
        public ProductsService(IBusClient client, IContextFactory contextFactory)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
            ServiceInitialization();
        }

        private void ServiceInitialization()
        {
            _client.RespondAsync<GetProductsRequest, GetProductsResponse>(GetProducts);
            _client.RespondAsync<DeleteProductRequest, bool>(DeleteProduct);
            _client.RespondAsync<CreateProductRequest, bool>(InsertProduct);
            _client.RespondAsync<UpdateProductRequest, bool>(UpdateProduct);
            Console.WriteLine($"{nameof(ProductsService)} initialized.");
        }
    
        private Task<GetProductsResponse> GetProducts(GetProductsRequest request, MessageContext msgContext)
        {
            var response = new GetProductsResponse();
            try
            {
                using (var context = _contextFactory.CreateDefaultContext())
                {
                    var query = context.Products.AsEnumerable();
                    if (request.Id.HasValue)
                    {   
                        query = query.Where(x => x.Id == request.Id.Value);
                    }
                    response.Products = query.Select(x => new Product(){ Id = x.Id, Name = x.Name }).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Task.FromResult(response);
        } 

        private Task<bool> DeleteProduct(DeleteProductRequest request, MessageContext msgContext)
        {
            try
            {
                using (var context = _contextFactory.CreateDefaultContext())
                {
                    context.Products.Remove(new ProductEntity { Id = request.Id });
                    context.SaveChanges();
                }        
                return Task.FromResult(true);        
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Task.FromResult(false);
        }

        private Task<bool> InsertProduct(CreateProductRequest request, MessageContext msgContext)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Name))
                {
                    return Task.FromResult(false);
                }
                using (var context = _contextFactory.CreateDefaultContext())
                {
                    context.Products.Add(new ProductEntity { Name = request.Name });
                    context.SaveChanges();
                }        
                return Task.FromResult(true);        
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Task.FromResult(false);
        }

        private Task<bool> UpdateProduct(UpdateProductRequest request, MessageContext msgContext)
        {
            try
            {
                using (var context = _contextFactory.CreateDefaultContext())
                {
                    var product = context.Products.FirstOrDefault(x => x.Id == request.Id);
                    if (product == null)
                    {
                        return Task.FromResult(false);
                    }
                    product.Name = request.Name;
                    context.SaveChanges();
                }        
                return Task.FromResult(true);        
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Task.FromResult(false);
        }
    }
}
using System;
using System.Threading.Tasks;
using bio_eko_fit_dto;
using RawRabbit;
using RawRabbit.Context;

namespace bio_eko_fit_products
{
    public class ProductsService : IProductsService
    {
        IBusClient _client;
        public ProductsService(IBusClient client)
        {
            _client = client;
            ServiceInitialization();
        }

        private void ServiceInitialization()
        {
            _client.RespondAsync<Product, string>(GetProducts);
            Console.WriteLine($"{nameof(ProductsService)} initialized.");
        }
    
        private Task<string> GetProducts(Product product, MessageContext context)
        {
            return Task.FromResult(product.Name);
        } 
    }
}
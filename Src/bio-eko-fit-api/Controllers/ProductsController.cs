using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;
using bio_eko_fit_dto;
using RawRabbit.Configuration;
using RawRabbit.vNext;
using Microsoft.Extensions.Configuration;
using RawRabbit;
using bio_eko_fit_dto.Products;
using bio_eko_fit_dto.Common;

namespace bio_eko_fit_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IBusClient _client;
        public ProductsController(IBusClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage>> Get()
        {
            Console.WriteLine("Dupa");
            return await _client.RequestAsync<GetProductsRequest, ResponseMessage>(new GetProductsRequest());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseMessage>> Get(int id)
        {
            return await _client.RequestAsync<GetProductsRequest, ResponseMessage>(new GetProductsRequest { Id = id });
        }
        
        [HttpPost]
        public async Task<ActionResult<ResponseMessage>> Post([FromBody] Product product)
        {
            Console.WriteLine("Dupa 2");
            return await _client.RequestAsync<CreateProductRequest, ResponseMessage>(new CreateProductRequest { Name = product.Name } );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseMessage>> Put(int id, [FromBody] string value)
        {
            return await _client.RequestAsync<UpdateProductRequest, ResponseMessage>(new UpdateProductRequest { Id = id, Name = value });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseMessage>> Delete(int id)
        {
            return await _client.RequestAsync<DeleteProductRequest, ResponseMessage>(new DeleteProductRequest { Id = id });
        }
    }
}

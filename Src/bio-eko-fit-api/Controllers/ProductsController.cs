using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using bio_eko_fit_dto;
using Microsoft.Extensions.Configuration;
using bio_eko_fit_dto.Products;
using bio_eko_fit_dto.Common;
using bio_eko_fit.Products;

namespace bio_eko_fit_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        // [HttpGet]
        // public async Task<ActionResult<ResponseMessage>> Get()
        // {
        //     _productsService.GetProducts();
        //     //return await _client.RequestAsync<GetProductsRequest, ResponseMessage>(new GetProductsRequest());
        // }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<ResponseMessage>> Get(int id)
        // {
        //     //return await _client.RequestAsync<GetProductsRequest, ResponseMessage>(new GetProductsRequest { Id = id });
        // }
        
        // [HttpPost]
        // public async Task<ActionResult<ResponseMessage>> Post([FromBody] Product product)
        // {
        //     //return await _client.RequestAsync<CreateProductRequest, ResponseMessage>(new CreateProductRequest { Product = product } );
        // }

        // [HttpPut("{id}")]
        // public async Task<ActionResult<ResponseMessage>> Put([FromBody] Product product)
        // {
        //     //return await _client.RequestAsync<UpdateProductRequest, ResponseMessage>(new UpdateProductRequest { Product = product });
        // }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult<ResponseMessage>> Delete(int id)
        // {
        //     //return await _client.RequestAsync<DeleteProductRequest, ResponseMessage>(new DeleteProductRequest { Id = id });
        // }
    }
}

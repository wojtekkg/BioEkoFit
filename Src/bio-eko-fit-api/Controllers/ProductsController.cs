﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        [HttpGet]
        public async Task<ActionResult<ResponseMessage>> Get()
        {
             return await _productsService.GetProducts(new GetProductsRequest());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseMessage>> Get(int id)
        {
            return await _productsService.GetProducts(new GetProductsRequest { Id = id });
        }
        
        [HttpPost]
        public async Task<ActionResult<ResponseMessage>> Post([FromBody] Product product)
        {
            return await _productsService.CreateProduct(new CreateProductRequest { Product = product });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseMessage>> Put([FromBody] Product product)
        {
            return await _productsService.UpdateProduct(new UpdateProductRequest { Product = product });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseMessage>> Delete(int id)
        {
            return await _productsService.DeleteProduct(new DeleteProductRequest { Id = id });
        }
    }
}

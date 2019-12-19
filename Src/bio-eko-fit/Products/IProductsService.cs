using System.Threading.Tasks;
using bio_eko_fit_dto.Common;
using bio_eko_fit_dto.Products;

namespace bio_eko_fit.Products
{
    public interface IProductsService
    {
         Task<ResponseMessage> GetProducts(GetProductsRequest request);
         Task<ResponseMessage> DeleteProduct(DeleteProductRequest request);
         Task<ResponseMessage> CreateProduct(CreateProductRequest request);
         Task<ResponseMessage> UpdateProduct(UpdateProductRequest request);
    }
}
using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await _httpClient.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(long id)
        {
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> CreateProduct(ProductModel product)
        {
            var response = await _httpClient.PostAsJson(BasePath, product);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();

            throw new Exception("Something wnet wrong when calling api");

        }

        public async Task<ProductModel> UpdateProduct(ProductModel product)
        {
            var response = await _httpClient.PutAsJson(BasePath, product);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductModel>();

            throw new Exception("Something wnet wrong when calling api");
        }

        public async Task<bool> DeleteById(long id)
        {
            var response = await _httpClient.DeleteAsync($"{BasePath}/{id}");

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();

            throw new Exception("Something wnet wrong when calling api");
        }
    }
}

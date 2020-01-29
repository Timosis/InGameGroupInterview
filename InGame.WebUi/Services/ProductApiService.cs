using InGame.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InGame.WebUi.Services
{

    public interface IProductApiService
    {
        Task<List<ProductDto>> GetProducts();
        Task<List<ProductDto>> GetProductsByCategory(int categoryId);
    }

    public class ProductApiService : IProductApiService
    {
        private readonly HttpClient httpClient;
        public ProductApiService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:44386/api/Category/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            this.httpClient = httpClient;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            List<ProductDto> products = new List<ProductDto>();
            try
            {
                HttpResponseMessage responseMessage = httpClient.GetAsync("GetProducts").Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<List<ProductDto>>(responseData);
                }
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductDto>> GetProductsByCategory(int categoryId)
        {
            List<ProductDto> products = new List<ProductDto>();

            HttpResponseMessage responseMessage = await httpClient.GetAsync("GetProductsByCategory/" + categoryId);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<ProductDto>>(responseData);
            }
            return products;

        }
    }
}

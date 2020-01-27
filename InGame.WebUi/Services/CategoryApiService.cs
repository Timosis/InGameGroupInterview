using InGame.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InGame.WebUi.Services
{
    public interface ICategoryApiService
    {
        Task<List<CategoryDto>> GetCategories();
        Task<List<CategoryDto>> GetCategoriesWithoutHierarchy();
    }

    public class CategoryApiService : ICategoryApiService
    {
        private readonly HttpClient httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:44310/api/Category/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            this.httpClient = httpClient;
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            List<CategoryDto> categories = new List<CategoryDto>();
            try
            {
                HttpResponseMessage responseMessage =  httpClient.GetAsync("GetCategories").Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    categories = JsonConvert.DeserializeObject<List<CategoryDto>>(responseData);
                }
                return categories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CategoryDto>> GetCategoriesWithoutHierarchy()
        {
            List<CategoryDto> categories = new List<CategoryDto>();
            try
            {
                HttpResponseMessage responseMessage = httpClient.GetAsync("GetCategoriesWithoutHierarchy").Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = await responseMessage.Content.ReadAsStringAsync();
                    categories = JsonConvert.DeserializeObject<List<CategoryDto>>(responseData);
                }
                return categories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

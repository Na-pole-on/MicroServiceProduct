using WebUI.Models;
using WebUI.Services.Interfaces;

namespace WebUI.Services
{
    public class ItemService: BaseService, IItemService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ItemService(IHttpClientFactory httpClientFactory): base(httpClientFactory)
            => _httpClientFactory = httpClientFactory;

        public async Task<T> GetAllAsync<T>()
            => await this.SendAsync<T>(new ApiRequest
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ItemMicroservice + "/api/items"
            });

        public async Task<T> GetAsync<T>(int id)
            => await this.SendAsync<T>(new ApiRequest
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ItemMicroservice + "/api/items/" + id
            });

        public async Task<T> CreateAsync<T>(ItemViewModel model)
            => await this.SendAsync<T>(new ApiRequest
            {
                ApiType = SD.ApiType.POST,
                Data = model,
                Url = SD.ItemMicroservice + "/api/items"
            });

        public async Task<T> UpdateAsync<T>(ItemViewModel model)
            => await this.SendAsync<T>(new ApiRequest
            {
                ApiType = SD.ApiType.PUT,
                Data = model,
                Url = SD.ItemMicroservice + "/api/items/" + model.Id
            });

        public async Task<T> DeleteAsync<T>(int id)
            => await this.SendAsync<T>(new ApiRequest
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ItemMicroservice + "/api/items/" + id
            });
    }
}

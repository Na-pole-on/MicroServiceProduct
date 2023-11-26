using WebUI.Models;

namespace WebUI.Services.Interfaces
{
    public interface IItemService: IBaseService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(ItemViewModel productDto);
        Task<T> UpdateAsync<T>(ItemViewModel productDto);
        Task<T> DeleteAsync<T>(int id);
    }
}

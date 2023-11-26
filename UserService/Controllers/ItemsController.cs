using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Data;
using UserService.Models;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private ResponseDto _response;
        private readonly AppDbContext _context;

        public ItemsController(AppDbContext context)
            => (_response, _context) = (new(), context);

        [HttpGet]
        public object GetAll()
        {
            try
            {
                _response.Result = _context.Items;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }

            return _response;
        }

        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                _response.Result =  await _context.Items.FindAsync(id);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }

            return _response;
        }

        [HttpPost]
        public async Task<object> Create([FromBody]Item create)
        {
            try
            {
                create.CreatedDate = DateTime.Now;

                await _context.Items.AddAsync(create);
                await _context.SaveChangesAsync();

                _response.Result = create;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }

            return _response;
        }

        [HttpPut("{id}")]
        public async Task<object> Update(int id, [FromBody] Item update)
        {
            try
            {
                var item = await _context.Items.FindAsync(id);

                item.Name = update.Name;
                item.Description = update.Description;
                item.Price = update.Price;

                await _context.SaveChangesAsync();

                _response.Result = item;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }

            return _response;
        }

        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                var item = await _context.Items.FindAsync(id);

                _context.Items.Remove(item);
                await _context.SaveChangesAsync();

                _response.Result = item;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }

            return _response;
        }
    }
}

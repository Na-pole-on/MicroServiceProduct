using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Models;
using WebUI.Services.Interfaces;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IItemService _itemService;
        private ItemViewModel? _itemViewModel;

        public HomeController(IItemService itemService)
            => _itemService = itemService;

        [HttpGet]
        public IActionResult Index()
            => View();

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<ItemViewModel> list = new();
            var response = await _itemService.GetAllAsync<ResponseDto>();

            if (response is not null && response.IsSuccess)
                list = JsonConvert.DeserializeObject<List<ItemViewModel>>(Convert.ToString(response.Result));

            return Json(list);
        }

        [HttpGet]
        public IActionResult Create()
            => View();

        [HttpGet("/Home/Create/{id}")]
        public async Task<IActionResult> Create(int id)
        {
            var response = await _itemService.GetAsync<ResponseDto>(id);

            if (response is not null && response.IsSuccess)
            {
                var item = JsonConvert.DeserializeObject<ItemViewModel>(Convert.ToString(response.Result));

                return View(item);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _itemService.CreateAsync<ResponseDto>(model);

                if (response is not null && response.IsSuccess)
                    return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet("/Home/Update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var response = await _itemService.GetAsync<ResponseDto>(id);

            if(response is not null && response.IsSuccess)
            {
                var item = JsonConvert.DeserializeObject<ItemViewModel>(Convert.ToString(response.Result));

                return View(item);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(ItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _itemService.UpdateAsync<ResponseDto>(model);

                if(response is not null && response.IsSuccess)
                    return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpDelete("/home/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _itemService.DeleteAsync<ResponseDto>(id);

            if (response is not null && response.IsSuccess)
                return Ok();

            return NotFound();
        }

    }
}

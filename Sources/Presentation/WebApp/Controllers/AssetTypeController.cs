using ItlaincenstmentApp.Core.Aplicationn.Dtos.AssetTypeDtos;
using ItlaincenstmentApp.Core.Aplicationn.Interfaces;
using ItlaincenstmentApp.Core.Aplicationn.ViewModels.AssetsTypesViewModels;
using ItlaincenstmentApp.Core.Domain.ValidationEntities;
using Microsoft.AspNetCore.Mvc;

namespace ItlaincenstmentApp.Controllers
{
    public class AssetTypeController : Controller
    {
        private readonly IAssetTypesServices _serives;
        public AssetTypeController(IAssetTypesServices service)
        {
            _serives = service;
        }
        public async Task<IActionResult> Index()
        {
            var dtos = await _serives.GetAllWithAsset();

            if (!dtos.IsSuccess)
                return BadRequest(dtos.Message);

            var vm = dtos.Value.Select(a => new AssetsTypesViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                AssetsQuantity = a.AssetsQuantity
            }).ToList();
            return View(vm);
        }
        public async Task<IActionResult> Details(int id)
        {
            var dtos = await _serives.GetByIdAsync(id);

            if (!dtos.IsSuccess)
                return BadRequest(dtos.Message);

            var vm = new AssetsTypesViewModel
            {
                Id = dtos.Value.Id,
                Name = dtos.Value.Name,
                Description = dtos.Value.Description,
                AssetsQuantity = dtos.Value.AssetsQuantity
            };
            return View(vm);
        }
        public IActionResult Create()
        {
            return View("Save", new SaveAssetsTypesViewModel() { Name = "" });
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveAssetsTypesViewModel vm)
        {
            if (!ModelState.IsValid)
                return View("Save", vm);
            var dto = AssetsTypeDto.NewBuilder()
                .WithId(vm.Id)
                .WithName(vm.Name)
                .WithDescription(vm.Description!)
                .Build();
            var resutl = await _serives.AddAsync(dto);

            if (!resutl.IsSuccess)
            {
                ViewBag.Error = resutl.Message;
                return View("Save", vm);
            }
            return RedirectToRoute(new { controller = "AssetType", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            var isValid = GenericValidId.ValidId(id);

            if (!isValid.IsSuccess)
                return BadRequest(isValid.Message);

            var result = await _serives.GetByIdAsync(isValid.Value);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var dto = result.Value;

            var vm = new SaveAssetsTypesViewModel()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
            };

            ViewBag.Action = "Edit";

            return View("Save", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveAssetsTypesViewModel vm)
        {
            if (!ModelState.IsValid)
                return View("Save", vm);

            var dto = AssetsTypeDto.NewBuilder()
                .WithId(vm.Id)
                .WithName(vm.Name)
                .WithDescription(vm.Description!)
                .Build();

            var result = await _serives.UbdateAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return RedirectToRoute(new { controller = "AssetType", action = "Index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            var isValid = GenericValidId.ValidId(id);

            if (!isValid.IsSuccess)
                return BadRequest(isValid.Message);

            var result = await _serives.GetByIdAsync(isValid.Value);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            var dto = result.Value;

            var vm = new DeleteAssetTypeViewModel()
            {
                Id = dto.Id,
                Name = dto.Name,
            };

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var isValid = GenericValidId.ValidId(id);

            if (!isValid.IsSuccess)
                return BadRequest(isValid.Message);

            var result = await _serives.DeleteAsync(isValid.Value);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return RedirectToRoute(new { controller = "AssetType", action = "Index" });
        }
    }
}

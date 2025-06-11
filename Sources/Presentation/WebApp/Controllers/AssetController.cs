using ItlaincenstmentApp.Core.Aplicationn.Dtos.AssetDtos;
using ItlaincenstmentApp.Core.Aplicationn.Interfaces;
using ItlaincenstmentApp.Core.Aplicationn.ViewModels.AssetsTypesViewModels;
using ItlaincenstmentApp.Core.Aplicationn.ViewModels.AssetViewModels;
using ItlaincenstmentApp.Core.Domain.ValidationEntities;
using Microsoft.AspNetCore.Mvc;

namespace ItlaincenstmentApp.Controllers
{
    public class AssetController : Controller
    {
        public readonly IAssetTypesServices _servicestype;
        public readonly IAssetServices _serives;
        public AssetController(IAssetTypesServices servicesType, IAssetServices service)
        {
            _serives = service;
            _servicestype = servicesType;
        }
        public async Task<IActionResult> Index()
        {
            var dtos = await _serives.GetAllWithAsset();

            if (!dtos.IsSuccess)
                return View(new List<AssetViewModel>() { });

            var vm = dtos.Value.Select(a => new AssetViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                Symbol = a.Symbol,
                AssetyTypeViewModel = new AssetsTypesViewModel
                { 
                    Id = a.assetTypeDto != null ? a.assetTypeDto.Id : 0, 
                    Name = a.assetTypeDto != null ? a.assetTypeDto.Name : "" 
                }
            }).ToList();
            return View(vm);
        }
        public async Task<IActionResult> Details(int id)
        {
            var dtos = await _serives.GetByIdAsync(id);

            if (!dtos.IsSuccess)
                return BadRequest(dtos.Message);

            var vm = new AssetViewModel
            {
                Id = dtos.Value.Id,
                Name = dtos.Value.Name,
                Description = dtos.Value.Description,
                Symbol = "",
                AssetyTypeViewModel = new AssetsTypesViewModel { Id = 1, Name = "" }
            };
            return View(vm);
        }
        public async Task<IActionResult> Create()
        {
            var result = await _servicestype.GetAll();
            if(result.Value.Count <= 0)
            {
                return BadRequest("Deve Crear Asset Type Primero");
            }
            var list = result.Value.ToList();
            ViewBag.TypeIds = list;
            return View("Save", new SaveAssetViewModel() { Id = 0, AssetTypeId = 0, Symbol ="",  Name = "" });
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveAssetViewModel vm)
        {
            if (!ModelState.IsValid)
                return View("Save", vm);
            var dto = AssetDto.NewBuilder()
                .WithId(vm.Id)
                .WithName(vm.Name)
                .WithDescription(vm.Description != null ? vm.Description : "")
                .WithSymbol(vm.Symbol)
                .WithAssetTypeId(vm.AssetTypeId)
                .Buil();
            var resutl = await _serives.AddAsync(dto);

            if (!resutl.IsSuccess)
            {
                ViewBag.Error = resutl.Message;
                return View("Save", vm);
            }
            return RedirectToRoute(new { controller = "Asset", action = "Index" });
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

            var vm = new SaveAssetViewModel()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Symbol = dto.Symbol,
                AssetTypeId = dto.AssetTypeId
            };
            var resulttypeasset = await _servicestype.GetAll();
            var list = resulttypeasset.Value.ToList();
            List<int> ids = new List<int>();
            foreach (var i in list)
            {
                ids.Add(i.Id);
            }
            ViewBag.TypeIds = ids;
            ViewBag.Action = "Edit";

            return View("Save", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveAssetViewModel vm)
        {
            if (!ModelState.IsValid)
                return View("Save", vm);

            var dto = AssetDto.NewBuilder()
                .WithId(vm.Id)
                .WithName(vm.Name)
                .WithDescription(vm.Description != null ? vm.Description : "")
                .WithSymbol(vm.Symbol)
                .WithAssetTypeId(vm.AssetTypeId)
                .Buil();

            var result = await _serives.UbdateAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return RedirectToRoute(new { controller = "Asset", action = "Index" });
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

            var vm = new DeleteAssetViewModel()
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

            return RedirectToRoute(new { controller = "Asset", action = "Index" });
        }
    }
}
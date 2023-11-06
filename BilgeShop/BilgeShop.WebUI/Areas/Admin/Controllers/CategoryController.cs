using BilgeShop.Business.Dtos;
using BilgeShop.Business.Services;
using BilgeShop.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BilgeShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private object? formData;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult List()
        {
            var categoryDtoList = _categoryService.GetCategories();
            var viewModel=categoryDtoList.Select(x=>new CategoryListViewModel()
            {

                Id= x.Id,
                Name = x.Name,
            }).ToList();
            return View(viewModel);
        }
        public IActionResult New()
        {
            return View("Form", new CategoryFormViewModel());
        }
        public IActionResult Save(CategoryFormViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", formData);

            }

            if (formData.Id == 0) // EKLEME
            {
                var addcategoryDto = new AddCategoryDto()
                {
                    Name = formData.Name.Trim(),
                    Description = formData.Description
                };
                var result = _categoryService.AddCategory(addcategoryDto);
                if (result)
                {
                    return RedirectToAction("List");

                }
                else
                {
                    ViewBag.ErrorMessage = "Bu isimde bir kategori zaten mevcut";
                    return View("Form", formData);
                }
            }
            else // GÜNCELLEME
             {


                return RedirectToAction("List");
            }
        }
    }
}




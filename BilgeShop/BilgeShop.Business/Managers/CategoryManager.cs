using BilgeShop.Business.Dtos;
using BilgeShop.Business.Services;
using BilgeShop.Data.Entities;
using BilgeShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeShop.Business.Managers
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepository<CategoryEntity> _categoryRepository;
        public CategoryManager(IRepository<CategoryEntity> categoryRepository)
        {
            _categoryRepository = categoryRepository;


        }

        public bool AddCategory(AddCategoryDto addCategoryDto)
        {
            var hasCategory =_categoryRepository.GetAll(x=>x.Name.ToLower() == addCategoryDto.Name.ToLower()).ToList();
            if(hasCategory.Any())
                {
                return false;
            }
            var entity =new CategoryEntity()
            {
                Name=addCategoryDto.Name,
                    Description=addCategoryDto.Description

            };
            _categoryRepository.Add(entity);
            return true;
        }

        public List<ListCategoryDto> GetCategories()
        {
            var categoryEntities = _categoryRepository.GetAll
                ().OrderBy(x => x.Name);

            var categoryDtoList = categoryEntities.Select(x=> new ListCategoryDto()
            {
                Id= x.Id,
                Name = x.Name
            }).ToList();
            return categoryDtoList;
        }
    }
}

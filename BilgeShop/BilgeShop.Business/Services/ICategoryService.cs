﻿using BilgeShop.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeShop.Business.Services
{
    public interface ICategoryService
    {
        bool AddCategory(AddCategoryDto addCategoryDto);

        List<ListCategoryDto> GetCategories();
 
    }
}

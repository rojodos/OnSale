﻿using OnSale.Common.Entities;
using OnSale.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnSale.Web.Helpers
{
    public interface IConverterHelper
    {
        Category ToCategory(CategoryViewModel model, bool isNew);

        CategoryViewModel ToCategoryViewModel(Category category);
    }

}

﻿using confeccion.Web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnSale.Common.Entities;
using OnSale.Web.Data;
using OnSale.Web.Helpers;
using OnSale.Web.Models;
using System;
using System.Threading.Tasks;

namespace OnSale.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly DataContext _context;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;

        public CategoriesController(DataContext context,IImageHelper imageHelper, IConverterHelper converterHelper)
        {
            _context = context;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        public IActionResult Create()
        {
            CategoryViewModel model = new CategoryViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file, CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var imagePath = string.Empty;

                if (file != null)
                {
                    imagePath = await _imageHelper.UploadImageAsync(file, "categories");
                }

                try
                {
                    Category category = _converterHelper.ToCategory(model, true);
                    category.ImagePath = imagePath;
                    _context.Add(category);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(model);
        }

    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InGame.Dtos;
using InGame.WebUi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InGame.WebUi.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.saveButton = new
            {
                content = "Save",
                isPrimary = true
            };
            ViewBag.cancelButton = new
            {
                content = "Cancel",
            };
            return View();
        }

        public IActionResult Create(ProductVm productVm, IFormFile UploadFiles)        
        {
            return View();
        }


    }
}
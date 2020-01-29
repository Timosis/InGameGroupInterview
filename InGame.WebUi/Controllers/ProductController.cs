using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InGame.Dtos;
using InGame.WebUi.Models;
using Microsoft.AspNetCore.Mvc;

namespace InGame.WebUi.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateProduct(ProductVm productVm)
        {
            return View();
        }


    }
}
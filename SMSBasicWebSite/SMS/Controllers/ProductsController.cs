using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Data.Common;
using SMS.Models;
using SMS.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(Request request, IProductService productService)
            : base(request)
        {
            this.productService = productService;
        }

        [Authorize]
        public Response Create()
        {
            return View(new { IsAuthenticated = true });
        }

        [HttpPost]
        [Authorize]
        public Response Create(ProductFormViewModel model)
        {
            var (isCreated, errorProductMessage) = productService.ProductCreate(model);

            if (!isCreated)
            {
                return View(new { ErrorMessage = errorProductMessage }, "/Error");
            }

            return Redirect("/");
        }
    }
}

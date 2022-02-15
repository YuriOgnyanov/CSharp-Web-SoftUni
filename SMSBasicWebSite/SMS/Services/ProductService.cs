using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models;
using SMS.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repo;

        public ProductService(IRepository repo)
        {
            this.repo = repo;
        }

        public (bool isCreated, string errorProductMessage) ProductCreate(ProductFormViewModel model)
        {
            bool isCreated = false;
            string errorProductMessage = null;

            var (isValid, error) = ValidateProductForm(model);

            if (!isValid)
            {
                return (isValid, error);
            }

            decimal price = 0;

            if (!decimal.TryParse(model.Price, NumberStyles.Float, CultureInfo.InvariantCulture, out price)
                || price < 0.05M || price > 1000M)
            {
                errorProductMessage = "Price must be between 0.05 and 1000";
                return (isValid, errorProductMessage);
            }

            Product product = new Product()
            {
                Name = model.Name,
                Price = price
            };

            try
            {
                repo.Add(product);
                repo.SaveChanges();
                isCreated = true;
            }
            catch (Exception)
            {
                errorProductMessage = "Could not save user in DB";
            }

            return (isCreated, errorProductMessage);
        }

        public (bool isValid, string error) ValidateProductForm(ProductFormViewModel model)
        {
            bool isValid = true;
            StringBuilder error = new StringBuilder();

            if (model.Name.Length < 4 || model.Name.Length > 20 || model.Name is null)
            {
                isValid = false;
                error.AppendLine("The Name is required and must be between 5 and 20 charecters!");
            }

            return (isValid, error.ToString().TrimEnd());
        }

        public IEnumerable<ProductListViewModel> GetProducts()
        {
            return repo.All<Product>()
                .Select(p => new ProductListViewModel()
                {
                    ProductName = p.Name,
                    ProductPrice = p.Price.ToString("F2"),
                    ProductId = p.Id
                })
                .ToList();
        }
    }
}

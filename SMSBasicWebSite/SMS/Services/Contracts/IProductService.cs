using SMS.Models;
using System.Collections.Generic;

namespace SMS.Services.Contracts
{
    public interface IProductService
    {
        (bool isCreated, string errorProductMessage) ProductCreate(ProductFormViewModel model);
        (bool isValid, string error) ValidateProductForm(ProductFormViewModel model);
        IEnumerable<ProductListViewModel> GetProducts();

    }
}

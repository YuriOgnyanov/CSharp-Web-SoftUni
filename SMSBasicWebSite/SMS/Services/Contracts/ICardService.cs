using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services.Contracts
{
    public interface ICardService
    {
        IEnumerable<CartViewModel> AddProduct(string productId, string userId);

        void BuyProducts(string userId);

        IEnumerable<CartViewModel> GetProducts(string userId);
    }
}

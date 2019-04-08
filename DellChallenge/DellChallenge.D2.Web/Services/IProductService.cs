using DellChallenge.D2.Web.Models;
using System.Collections.Generic;

namespace DellChallenge.D2.Web.Services
{
    public interface IProductService
    {
        ProductModel Get(string id);
        IEnumerable<ProductModel> GetAll();
        ProductModel Add(NewProductModel newProduct);
        ProductModel Update(UpdateProductModel product);
        ProductModel Delete(string id);
    }
}
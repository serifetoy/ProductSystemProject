using ProductProject.Models.Entities;
using System.Collections.Generic;

namespace ProductProject.Models.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);
        Product Update(int id, Product product);
        void Delete(int id);
        Product GetById(int id, bool withCategory = false);
        List<Product> Search(string name, int? categoryId, double? minPrice);
        List<Product> GetAll(int page, int pageSize);

    }
}

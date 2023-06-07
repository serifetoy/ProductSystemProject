using Microsoft.EntityFrameworkCore;
using ProductProject.Models.Entities;
using ProductProject.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProductProject.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly CommerceContext _context;
        public ProductRepository(CommerceContext context)
        {
            _context = context;
        }

        public void Add(Product product)//object return dto
        {
            _context.Products.Add(product);
            _context.SaveChanges();

        }

        public Product Update(int id, Product product)
        {
            var p = _context.Products.FirstOrDefault(x => x.Id == id);

            if (p is null) 
                throw new System.Exception("Not Found");

            var cat = _context.Categories.FirstOrDefault(x => x.Id == product.CategoryId);

            if (cat is null)
                throw new System.Exception("Category Not Found");

            p.Price = product.Price;
            p.CategoryId = product.CategoryId;
            p.Name= product.Name; 

            _context.SaveChanges();

            return p;

        }

        public void Delete(int id)
        {
            var p = _context.Products.SingleOrDefault(p => p.Id == id);

            if (p is null)
                throw new System.Exception("Not Found");

            _context.Products.Remove(p);
            _context.SaveChanges();

        }

        public Product GetById(int id, bool withCategory = false)
        {
            var query = _context.Products.AsQueryable();
            if (withCategory)
                query.Include(x => x.Category);

            return query.FirstOrDefault(x=> x.Id == id);
        }
        public List<Product> Search(string name , int? categoryId,double? minPrice  )
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query.Where( x=> x.Name == name);
            if(categoryId.HasValue)
                query.Where(x => x.CategoryId == categoryId);
            if (minPrice.HasValue)
                query.Where(x => x.Price == minPrice);

            return query.ToList();
        }


        public List <Product> GetAll(int page, int pageSize)
        {
            return _context.Products.Skip(page * pageSize).Take(pageSize).ToList(); 
        }
    }
}

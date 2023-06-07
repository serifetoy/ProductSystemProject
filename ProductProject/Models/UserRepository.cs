using Microsoft.EntityFrameworkCore;
using ProductProject.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProductProject.Models
{
    public class UserRepository
    {
        private readonly CommerceContext _context;
        public UserRepository(CommerceContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

        }

        public void Update(int id, User user)
        {
            var u = _context.Users.SingleOrDefault(u => u.Id == id);

            if (u is null)
                throw new System.Exception(" User Not Found");

            u.Name = user.Name;
            u.Addresses = user.Addresses;
            u.Orders = user.Orders;
            u.UserType = user.UserType;
            u.GenderType = user.GenderType;

            _context.SaveChanges();

        }
        public void Delete(int id)
        {
            var u = _context.Users.SingleOrDefault(u => u.Id == id);

            if (u is null)
                throw new System.Exception("Not Found");

            _context.Users.Remove(u);
            _context.SaveChanges();

        }

        public User GetById(int id, bool withOrder = false)
        {
            var query = _context.Users.AsQueryable();
            if (withOrder)
                query.Include(x => x.Orders);

            return query.FirstOrDefault(x => x.Id == id);
        }

        public List<Order> GetAll(int page, int pageSize)
        {
            return _context.Orders.Skip(page * pageSize).Take(pageSize).ToList();
        }
    }
}

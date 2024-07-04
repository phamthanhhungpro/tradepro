using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tradepro.InfraModel.DataAccess;
using tradepro.Logic.Interfaces;
using tradepro.Logic.Request;

namespace tradepro.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly TradeproDbContext _context;
        private readonly IRoleService _roleService;
        public UserService (TradeproDbContext context,
            IRoleService roleService)
        {
            _context = context;
            _roleService = roleService;
        }
        public   void CreateUser(UserRequest userRequest)
        {
            var newUser = new User()
            {
                Name = userRequest.Name,
                Email = userRequest.Email,
                Phone = userRequest.Phone,
                Password = userRequest.Password,
                Address = userRequest.Address,
                Role = _context.Roles.Find(userRequest.RoleId),
                IsActive  = true,
                CreatedAt = DateTime.UtcNow,
        };
            _context.Users.Add(newUser);
             _context.SaveChanges();
        }

        public async Task<List<User>> ListUser()
        {
            return await _context.Users.ToListAsync();
        }
    }
}

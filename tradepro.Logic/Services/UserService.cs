using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tradepro.InfraModel.DataAccess;
using tradepro.Logic.DTOs;
using tradepro.Logic.Interfaces;
using tradepro.Logic.Request;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<CudResponseDto> ChangePassword(Guid Id, ChangpasswordRequest changpasswordRequest)
        {
            var user = await _context.Users.FindAsync(Id);
            if(user == null)
            {
                throw new Exception("Not found");
            }
            else
            {
                if(!user.Password.Equals(changpasswordRequest.Oldpassword))
                {
                    throw new Exception("Old password wrong");
                }
                user.Password = changpasswordRequest.Newpassword;
                await _context.SaveChangesAsync();
            }
            return new CudResponseDto
            {
                Id = Id,
            };

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

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.Include(x => x.Role).Where(x => x.Email.Equals(email)).FirstOrDefaultAsync();
        }

        public async Task<List<User>> ListUser()
        {
            return await _context.Users.Include(x=>x.Role).ToListAsync();
        }

        public async Task<CudResponseDto> UpdateUser(Guid Id, UpdateUserRequest user)
        {
            var updateUser = await _context.Users.FindAsync(Id);
            if (updateUser == null)
            {
                throw new Exception("Not found");
            }
            updateUser.Email = user.Email;
            updateUser.Phone = user.Phone;
            updateUser.Name = user.Name;
            updateUser.Address = user.Address;
            await _context.SaveChangesAsync();
            return new CudResponseDto()
            {
                Id = Id,
            };
        }
    }
}

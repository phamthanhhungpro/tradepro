using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace tradepro.InfraModel.DataAccess
{
    public class Role : IdentityRole<Guid>
    {
        public string Description { get; set; }
        public string Code { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<User> Users { get; set; }
    }
}

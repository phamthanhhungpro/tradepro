﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tradepro.InfraModel.DataAccess;
using tradepro.Logic.Request;

namespace tradepro.Logic.Interfaces
{
    public interface IUserService
    {
       void CreateUser(UserRequest userRequest);
        Task<List<User>> ListUser();
    }
}

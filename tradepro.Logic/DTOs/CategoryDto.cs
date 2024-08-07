﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tradepro.InfraModel.DataAccess;

namespace tradepro.Logic.DTOs
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> products { get; set; }
    }
}

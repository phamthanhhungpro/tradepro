﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace tradepro.Logic.Request
{
    public class RoleRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }
    }
}

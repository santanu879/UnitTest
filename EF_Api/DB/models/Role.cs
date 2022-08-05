﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EF_Api.DB.models
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        public short RoleId { get; set; }
        public string RoleDesc { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}

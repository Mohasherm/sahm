﻿using Microsoft.AspNetCore.Identity;

namespace sahm.Server.Data
{
    public class AppRole : IdentityRole<Guid>
    {
        public AppRole(string name)
        {
            Id= Guid.NewGuid();
            Name = name;
        }
    }
}

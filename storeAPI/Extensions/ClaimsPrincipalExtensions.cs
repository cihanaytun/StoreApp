﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace storeAPI.Extensions
{
    public static  class ClaimsPrincipalExtensions
    {
        public static string RetrieveEmailfromPrincipal (this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Email);
        }
    }
}

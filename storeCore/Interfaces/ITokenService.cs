using storeCore.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeCore.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}

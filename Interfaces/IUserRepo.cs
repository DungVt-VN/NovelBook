using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IUserRepo
    {
        Task<Boolean> GetExistingEmailAsync(string email);
        
    }
}
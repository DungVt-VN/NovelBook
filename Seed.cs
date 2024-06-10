using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;

namespace api
{
    public class Seed
    {
        private readonly ApplicationDBContext _context;

        public Seed(ApplicationDBContext context)
        {
            _context = context;
        }

        public void SeedDataContext() {
            
        }
        
    }
}
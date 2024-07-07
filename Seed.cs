using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;
using api.Data.Enums;
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

        public void SeedDataContext()
        {
            // Ensure database is created
            if (!_context.Database.CanConnect())
            {
                _context.Database.EnsureCreated();
            }
            // Thêm dữ liệu các bảng ở đây


            // Seed Categories
            
            // Kết thúc ở đâyi

        }
    }
}

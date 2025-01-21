﻿using CloudHRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudHRMS.DAO
{
    public class HRMSDbContext : DbContext
    {
        public HRMSDbContext(DbContextOptions<HRMSDbContext> db) : base(db)
        {
        }
        // Has-a Relationship for all of the entities DBSet
        public DbSet<EmployeeEntity> Employees { get; set; }
    }
}

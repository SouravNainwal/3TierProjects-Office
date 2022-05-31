using Microsoft.EntityFrameworkCore;
using System;
using _3TierProjects3;
using _3TierProjects3.DAL.model;

namespace _3TierProjects1.BAL
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }

        public DbSet<StudentModel> EmployeeTable { get; set; }
        public DbSet<LoginModel> LoginTable { get; set; }

    }
}

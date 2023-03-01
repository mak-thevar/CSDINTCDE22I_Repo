using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAppDemo;
using WebAppDemo.Entities;
using WebAppDemo.Models;

namespace WebAppDemo.Data
{
    public partial class DefaultContext : DbContext
    {
        public DefaultContext()
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }

        public DefaultContext(DbContextOptions<DefaultContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
            //Seeding
            SeedDepartment(modelBuilder);
            SeedDesignation(modelBuilder);
        }

        private static void SeedDepartment(ModelBuilder modelBuilder)
        {
            List<Department> departments = new List<Department>()
            {
                new Department() { Id = 1, Name = "Sales" },
                new Department() { Id = 2, Name = "Marketing" },
                new Department() { Id = 3, Name = "Human Resources" },
                new Department() { Id = 4, Name = "Finance" },
                new Department() { Id = 5, Name = "IT" },
                new Department() { Id = 6, Name = "Research and Development" },
                new Department() { Id = 7, Name = "Customer Service" },
                new Department() { Id = 8, Name = "Legal" },
                new Department() { Id = 9, Name = "Operations" },
                new Department() { Id = 10, Name = "Supply Chain" }
            };

            modelBuilder.Entity<Department>().HasData(departments);

        }

        private static void SeedDesignation(ModelBuilder modelBuilder)
        {
            List<Designation> designations = new List<Designation>()
            {
                new Designation() { Id = 1, Name = "Manager" },
                new Designation() { Id = 2, Name = "Senior Developer" },
                new Designation() { Id = 3, Name = "Team Lead" },
                new Designation() { Id = 4, Name = "Software Engineer" },
                new Designation() { Id = 5, Name = "Business Analyst" },
                new Designation() { Id = 6, Name = "Project Manager" },
                new Designation() { Id = 7, Name = "QA Analyst" },
                new Designation() { Id = 8, Name = "Technical Writer" },
                new Designation() { Id = 9, Name = "Product Owner" },
                new Designation() { Id = 10, Name = "UI/UX Designer" }
            };

            modelBuilder.Entity<Designation>().HasData(designations);

        }




        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

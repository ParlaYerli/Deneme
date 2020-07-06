using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Context
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<LogType> LogTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host= localhost; Port= 5432; User Id= postgres; Password = parla; Database=User");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForNpgsqlUseIdentityColumns();
            modelBuilder.ForNpgsqlUseSerialColumns();

            modelBuilder.HasSequence<int>("OrderNumbers")
                        .StartsAt(4)
                        .IncrementsBy(1);

            modelBuilder.Entity<User>()
                        .Property(o => o.Id)
                        .HasDefaultValueSql("nextval('\"OrderNumbers\"')");

            modelBuilder.Entity<Role>().HasData(
                new Role() { Id = 1, Name = "Dealer", CreatedDate = DateTime.Now, CreatedBy = 2 },
                new Role() { Id = 2, Name = "CallCenterAdmin", CreatedDate = DateTime.Now, CreatedBy = 2 },
                 new Role() { Id = 3, Name = "Dealer2", CreatedDate = DateTime.Now, CreatedBy = 2 },
                 new Role() { Id = 4, Name = "CallCenter", CreatedDate = DateTime.Now, CreatedBy = 2 }
                );

            modelBuilder.Entity<User>().HasData(
               new User()
               {
                   Id = 1,
                   CreatedBy = 1,
                   DealerId = 123123,
                   IsActive = true,
                   Password = "023a2d11e01237fb6eab5ca926facd39ee44b1683e84295cccef79b7df905195",//123123
                   RoleId = 1,
                   UpdatedDate = DateTime.Now,
                   CreatedDate = DateTime.Now,
                   UpdatedBy = 1,
                   FullName = "Test",
                   DealerName = "Bayi1",
                   Address = "Test mah. Test sokak.",
                   City = "İstanbul",
                   Phone = "5552223355"
               },
               new User()
               {
                   Id = 2,
                   CreatedBy = 1,
                   IsActive = true,
                   Password = "023a2d11e01237fb6eab5ca926facd39ee44b1683e84295cccef79b7df905195",//123123
                   RoleId = 2,
                   UpdatedDate = DateTime.Now,
                   CreatedDate = DateTime.Now,
                   UpdatedBy = 1,
                   FullName = "CallCenter Admin"
               },
              new User()
              {
                  Id = 3,
                  CreatedBy = 1,
                  DealerId = 3,
                  IsActive = true,
                  Password = "023a2d11e01237fb6eab5ca926facd39ee44b1683e84295cccef79b7df905195",//123123
                  RoleId = 3,
                  UpdatedDate = DateTime.Now,
                  CreatedDate = DateTime.Now,
                  UpdatedBy = 1,
                  FullName = "Dealer",
                  DealerName = "Dealer ekranı",
                  Address = "Test mah. Test sokak.",
                  City = "İstanbul",
                  Phone = "5552223355"
              });

            modelBuilder.Entity<LogType>().HasData(
                new LogType()
                {
                    Id = 1,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    Name = "Login"
                },
                new LogType()
                {
                    Id = 2,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    Name = "SendMail"
                },
                new LogType()
                {
                    Id = 3,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    Name = "ChangePhone"
                },
                new LogType()
                {
                    Id = 4,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    Name = "Error"
                });
        }
    }
}



//4 -123123 callcenter login
//123123 -123123 dealer login
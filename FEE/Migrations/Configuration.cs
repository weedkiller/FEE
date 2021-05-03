namespace FEE.Migrations
{
    using FEE.Enums;
    using FEE.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FEE.Models.FEEDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FEE.Models.FEEDbContext context)
        {
            context.Users.AddOrUpdate(e => e.Id, new User
            {
                Id = 1,
                Username = "admin",
                Email = "admin@gmail.com",
                Name = "Admin",
                RoleId = 1,
                Status = (int)UserStatus.Activated,
                CreateDate = DateTime.Now,
                //AvatarImage = "default-avatar.jpg",
                Password = "0192023A7BBD73250516F069DF18B500", // = admin123
                Phone = "0913849547",
                DepartmentId = 0
            });            
        }
    }
}

﻿namespace Project.Core.Migrations
{
    using Project.Core.Objects;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Project.Core.CompanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Project.Core.CompanyDbContext context)
        {
            List<Department> departments = new List<Department>() {
            new Department(){Name="HR",CreateAt=DateTime.Now },
            new Department(){Name="Java",CreateAt=DateTime.Now },
            new Department(){Name="PHP",CreateAt=DateTime.Now },
            new Department(){Name="doNet",CreateAt=DateTime.Now }
            };
            context.Departments.AddRange(departments);
            context.SaveChanges();
            List<TypeUser> typeUsers = new List<TypeUser>()
            {
                new TypeUser(){Name="Hr",TypeUserId=1 },
                new TypeUser(){Name="Interviewer",TypeUserId=2 }

            };
            context.TypeUsers.AddRange(typeUsers);
            context.SaveChanges();
            List<User> users = new List<User>()
            {
                new User(){Name="a",Email="a@Gmail.com",Avatar="...",Birthday=DateTime.Now,TypeUserId=1,UserStatus=true,Password="123456" },
                new User(){Name="a",Email="abc@gmail.com",Avatar="...",Birthday=DateTime.Now,TypeUserId=1,UserStatus=true,Password="123456" },
                new User(){Name="b",Email="b@Gmail.com",Avatar="...",Birthday=DateTime.Now,TypeUserId=2,UserStatus=true,Password="123456" },
                new User(){Name="bdbdbdbd",Email="bd@gmail.com",Avatar="...",Birthday=DateTime.Now,TypeUserId=2,UserStatus=true,Password="123456" },
                new User(){Name="bdbdbd01",Email="bd1@gmail.com",Avatar="...",Birthday=DateTime.Now,TypeUserId=2,UserStatus=true,Password="123456" }
            };
            context.Users.AddRange(users);
            context.SaveChanges();
            List<Interview> interviews = new List<Interview>() {
               new Interview(){Id=1, UserId = 1 }
            };
            context.Interviews.AddRange(interviews);
            context.SaveChanges();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Text;
using HRP.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRP.DAL.Context
{
    public class DatabaseContext:IdentityDbContext<Entities.User,Entities.Role,string>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Entities.User>(entity =>
            {
                entity.ToTable(name: "tbl_Users");
            });
            builder.Entity<Entities.Role>(entity =>
            {
                entity.ToTable(name: "tbl_Roles");
            });
        }
        
        public  DbSet<Person> tbl_Persons { get; set; }
        public DbSet<PersonDetail> tbl_PersonDetails { get; set; }
        public DbSet<PregnancyCase> tbl_PregnancyCases { get; set; }



    }
}

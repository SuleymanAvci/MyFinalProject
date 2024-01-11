using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Xml.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}


// -------------------------- SQL'de  User, OperationClaim, UserOperationClaim Tabloları oluşturulması için Script kodu;

//USE[Northwind]
//GO

//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE [dbo].[Users](
//    [Id][int] IDENTITY(1, 1) NOT NULL,
//    [FirstName][varchar](50) NOT NULL,
//    [LastName][varchar](50) NOT NULL,
//    [Email][varchar](50) NOT NULL,
//    [PasswordHash][varbinary](500) NOT NULL,
//    [PasswordSalt][varbinary](500) NOT NULL,
//    [Status][bit] NOT NULL,
// CONSTRAINT[PK_Users] PRIMARY KEY CLUSTERED
//(
//    [Id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO


//---------------------------------------------

//USE[Northwind]
//GO

///****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 11.01.2024 17:23:45 ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE [dbo].[UserOperationClaims](
//    [Id][int] IDENTITY(1, 1) NOT NULL,
//    [UserId][int] NOT NULL,
//[OperationClaimId][int] NOT NULL,
// CONSTRAINT[PK_UserOperationClaims] PRIMARY KEY CLUSTERED
//(
//    [Id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO

//---------------------------------------------

//USE[Northwind]
//GO

///****** Object:  Table [dbo].[OperationClaims]    Script Date: 11.01.2024 17:24:01 ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE [dbo].[OperationClaims](
//    [Id][int] IDENTITY(1, 1) NOT NULL,
//    [Name][varchar](250) NOT NULL,
// CONSTRAINT[PK_OperationClaims] PRIMARY KEY CLUSTERED
//(
//    [Id] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO



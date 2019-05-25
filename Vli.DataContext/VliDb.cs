/**
*
* 功 能： N/A
* 类 名： VliDb
* 作 者： weili
* 时 间： 2019/5/17 23:53:42
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/

using Microsoft.EntityFrameworkCore;
using Vli.Entity.PO;

namespace Vli.DataContext
{
    public class VliDb : DbContext
    {
        public VliDb(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AccessRecord> AccessRecord { get; set; }

        public DbSet<SystemGroup> SystemGroup { get; set; }

        public DbSet<SystemLog> SystemLog { get; set; }

        public DbSet<SystemNavigation> SystemNavigation { get; set; }

        public DbSet<SystemParameter> SystemParameter { get; set; }

        public DbSet<SystemPermission> SystemPermission { get; set; }

        public DbSet<SystemRight> SystemRight { get; set; }

        public DbSet<SystemRole> SystemRole { get; set; }

        public DbSet<SystemUser> SystemUser { get; set; }

        public DbSet<UserGroup> UserGroup { get; set; }

        public DbSet<UserRight> UserRight { get; set; }

        public DbSet<UserRole> UserRole { get; set; }

        public DbSet<RoleRight> RoleRight { get; set; }

        public DbSet<GroupRight> GroupRight { get; set; }

        public DbSet<GBDistrictCode> GBDistrictCode { get; set; }

        public DbSet<GBIndustry> GBIndustrie { get; set; }

        public DbSet<Navigation> Navigation { set; get; }
    }
}

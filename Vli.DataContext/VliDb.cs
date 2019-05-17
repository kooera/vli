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

        public DbSet<AccessRecord> AccessRecords { get; set; }

        public DbSet<SystemGroup> SystemGroups { get; set; }

        public DbSet<SystemLog> SystemLogs { get; set; }

        public DbSet<SystemNavigation> SystemNavigations { get; set; }

        public DbSet<SystemParameter> SystemParameters { get; set; }

        public DbSet<SystemPermission> SystemPermissions { get; set; }

        public DbSet<SystemRight> SystemRights { get; set; }

        public DbSet<SystemRole> SystemRoles { get; set; }

        public DbSet<SystemUser> SystemUsers { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }

        public DbSet<UserRight> UserRights { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<RoleRight> RoleRights { get; set; }

        public DbSet<GroupRight> GroupRights { get; set; }

        public DbSet<GBDistrictCode> GBDistrictCodes { get; set; }

        public DbSet<GBIndustry> GBIndustries { get; set; }
    }
}

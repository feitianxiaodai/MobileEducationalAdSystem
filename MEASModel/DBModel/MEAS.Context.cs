﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MEASModel.DBModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MEASEntities : DbContext
    {
        public MEASEntities()
            : base("name=MEASEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Course> Course { get; set; }
        public DbSet<GroupInfo> GroupInfo { get; set; }
        public DbSet<MemberInfo> MemberInfo { get; set; }
        public DbSet<MessageInfo> MessageInfo { get; set; }
        public DbSet<NewsInfo> NewsInfo { get; set; }
        public DbSet<Topic> Topic { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameWorkDemo.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBMovieEntities1 : DbContext
    {
        public DBMovieEntities1()
            : base("name=DBMovieEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tbl_Movie_Master> Tbl_Movie_Master { get; set; }
        public virtual DbSet<Tbl_User_Master> Tbl_User_Master { get; set; }
    }
}

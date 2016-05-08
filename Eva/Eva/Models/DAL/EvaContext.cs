using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Eva.Models.DAL
{
    public class EvaContext : DbContext
    {
        public EvaContext() : base ("EvaContext") 
        {
        }
            
        public DbSet<Evaluatie> Evaluaties { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        } 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AComicConundrum_ASeholm.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
/// DAL = Data Access Layer
/// </summary>
namespace AComicConundrum_ASeholm.DAL
{
    /// <summary>
    /// The main class that coordinates Entity Framework functionality for a given data model.
    /// </summary>
    public class ComicContext : DbContext
    {
        /// <summary>
        /// The name of the connection string (web.config) is passed in to the constructor.
        /// </summary>
        public ComicContext() : base("ComicContext") { }

        /// <summary>
        /// Create a DbSet property for each entity set.
        /// </summary>
        public DbSet<Comic> Comics { get; set; }

        /// <summary>
        /// This prevents table names from being pluralized. Prevents the generated table in the database from 
        /// pluralizing 'Comic'. So, the generated table will now read 'Comic' instead of 'Comics'.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //base.OnModelCreating(modelBuilder);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DateMePlease.Entities;
using DateMePlease.Models;

namespace DateMePlease.Data
{
  public class DateMePleaseContext : DbContext
  {
    public DateMePleaseContext()
      : base("DefaultConnection")
    {
      this.Configuration.LazyLoadingEnabled = false;
      this.Configuration.ProxyCreationEnabled = false;
      Database.SetInitializer<DateMePleaseContext>(new DropCreateDatabaseIfModelChanges<DateMePleaseContext>());
    }

    public DbSet<Member> Members { get; set; }
    public DbSet<Interest> Interests { get; set; }
    public DbSet<Demographics> Demographics { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Profile> Profile { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Member>()
        .HasOptional<Profile>(m => m.Profile)
        .WithOptionalDependent(p => p.Member)
        .Map(p => p.MapKey("ProfileId"));
    }
  }
}
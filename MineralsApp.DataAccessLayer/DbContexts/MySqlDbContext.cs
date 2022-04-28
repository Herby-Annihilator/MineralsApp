using Microsoft.EntityFrameworkCore;
using MineralsApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MineralsApp.DataAccessLayer.DbContexts
{
    public class MySqlDbContext : IdentityDbContext
    {
        public DbSet<Country> Countries { get; set; }

        public DbSet<Territory> Territories { get; set; }

        public DbSet<Field> Fields { get; set; }

        public DbSet<Mineral> Minerals { get; set; }

        public DbSet<Publication> Publications { get; set; }

        public DbSet<Ore> Ores { get; set; }

        public DbSet<Researcher> Researchers { get; set; }

        public MySqlDbContext()
        {
            //_connectionString = connectionString;
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=192.168.1.133;port=3306;user=dvrukin;password=qwerty123@;database=minerals_1;",
                new MySqlServerVersion(new Version(8, 0, 28)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ManyToManyBetweenMineralAndPublication(modelBuilder);
            ManyToManyBetweenResearcherAndPublication(modelBuilder);
            ManyToManyBetweenOreAndMineral(modelBuilder);
            ManyToManyBetweenFieldAndMineral(modelBuilder);
            ConfigureDefaultData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        #region Relations
        protected void ManyToManyBetweenMineralAndPublication(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PublicationDescribesMineral>().HasKey(k => new { k.MineralId, k.PublicationId });

            modelBuilder.Entity<PublicationDescribesMineral>()
                .HasOne(pm => pm.Mineral)
                .WithMany(m => m.PublicationDescribesMineral)
                .HasForeignKey(pm => pm.MineralId);

            modelBuilder.Entity<PublicationDescribesMineral>()
                .HasOne(pm => pm.Publication)
                .WithMany(p => p.PublicationDescribesMineral)
                .HasForeignKey(pm => pm.PublicationId);
        }

        protected void ManyToManyBetweenResearcherAndPublication(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResearcherHasPublication>()
                .HasKey(k => new { k.ResearcherId, k.PublicationId });

            modelBuilder.Entity<ResearcherHasPublication>()
                .HasOne(rp => rp.Researcher)
                .WithMany(r => r.ResearcherHasPublication)
                .HasForeignKey(rp => rp.ResearcherId);

            modelBuilder.Entity<ResearcherHasPublication>()
                .HasOne(rp => rp.Publication)
                .WithMany(p => p.ResearcherHasPublication)
                .HasForeignKey(rp => rp.PublicationId);
        }

        protected void ManyToManyBetweenOreAndMineral(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OreHasMineral>().HasKey(k => new { k.OreId, k.MineralId });

            modelBuilder.Entity<OreHasMineral>()
                .HasOne(om => om.Ore)
                .WithMany(o => o.OreHasMinerals)
                .HasForeignKey(om => om.OreId);

            modelBuilder.Entity<OreHasMineral>()
                .HasOne(om => om.Mineral)
                .WithMany(m => m.OreHasMinerals)
                .HasForeignKey(om => om.MineralId);
        }

        protected void ManyToManyBetweenFieldAndMineral(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FieldHasMineral>().HasKey(k => new { k.MineralId, k.FieldId });
            modelBuilder.Entity<FieldHasMineral>()
                .HasOne(fm => fm.Mineral)
                .WithMany(m => m.FieldHasMinerals)
                .HasForeignKey(fm => fm.MineralId);

            modelBuilder.Entity<FieldHasMineral>()
                .HasOne(fm => fm.Field)
                .WithMany(f => f.FieldHasMinerals)
                .HasForeignKey(fm => fm.FieldId);
        } 
        #endregion

        protected void ConfigureDefaultData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole()
                    {
                        Id = "1",
                        Name = "admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole()
                    {
                        Name = "user",
                        NormalizedName = "USER",
                        Id = "2"
                    }
                );
            modelBuilder.Entity<IdentityUser>()
                .HasData(
                    new IdentityUser()
                    {
                        Id = "1",
                        UserName = "admin",
                        NormalizedUserName = "ADMIN",
                        Email = "admin@yandex.ru",
                        EmailConfirmed = true,
                        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "sosi_jopu"),
                        SecurityStamp = String.Empty
                    },
                    new IdentityUser()
                    {
                        Id = "2",
                        UserName = "user",
                        NormalizedUserName = "USER",
                        Email = "user@yandex.ru",
                        EmailConfirmed = true,
                        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "sosi_jopu"),
                        SecurityStamp = String.Empty
                    }
                );

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                    new IdentityUserRole<string>()
                    {
                        RoleId = "1",
                        UserId = "1",
                    },
                    new IdentityUserRole<string>()
                    {
                        RoleId = "2",
                        UserId = "2",
                    }
                );
        }
    }
}

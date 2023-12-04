using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<PostEntity> Posts { get; set; }

        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "labASP.db");

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity() { Id = 1, Name = "Adam", Email = "adam@wsei.edu.pl", Phone = "127813268163", Birth = new DateTime(2000, 10, 10), Priority = 1, Created = new DateTime(2020, 10, 10) },
                new ContactEntity() { Id = 2, Name = "Ewa", Email = "ewa@wsei.edu.pl", Phone = "293443823478", Birth = new DateTime(1999, 8, 10), Priority = 2, Created = new DateTime(2021, 10, 10) }
            );

            modelBuilder.Entity<PostEntity>().HasData(
                new PostEntity() 
                { 
                    Id = 1, Content = "Treść postu 1",
                    Autor = "Adam", PostDate = new DateTime(2023, 05, 12),
                    Tags = "tag1,tag2", Comment = "komentarz 1" 
                },
                new PostEntity() 
                { Id = 2, Content = "Treść postu 2",
                    Autor = "Ewa",
                    PostDate = new DateTime(1835, 11, 10),
                    Tags = "tag1,tag2", Comment = "komentarz 2" 
                }
            );
        }
    }
}

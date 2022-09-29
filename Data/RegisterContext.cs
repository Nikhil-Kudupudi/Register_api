using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Register.Models;

namespace Register.Data
{
    public class RegisterContext : DbContext
    {
        public RegisterContext (DbContextOptions<RegisterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Register.Models.User> User { get; set; } = default!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=nikhil;Initial Catalog=Admin;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            _ = modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.AdminName).HasColumnName("AdminName");

                entity.Property(e => e.Username).HasColumnName("Username");
                entity.Property(e => e.Password).HasColumnName("Password");
                entity.Property(e => e.CPassword).HasColumnName("CPassword");
                entity.Property(e => e.Address).HasColumnName("Address");
                entity.Property(e => e.Email).HasColumnName("Email");
                entity.Property(e => e.Phone).HasColumnName("Phone");
                entity.Property(e => e.PAN).HasColumnName("PAN");


            });


        }

    }
}

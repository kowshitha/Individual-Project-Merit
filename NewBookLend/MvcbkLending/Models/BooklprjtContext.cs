using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MvcbkLending.Models
{
    public partial class BooklprjtContext : DbContext
    {
        public BooklprjtContext()
        {
        }

        public BooklprjtContext(DbContextOptions<BooklprjtContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booktbl> Booktbls { get; set; }
        public virtual DbSet<Categoytbl> Categoytbls { get; set; }
        public virtual DbSet<UserTable> UserTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=.;initial catalog=Booklprjt;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Booktbl>(entity =>
            {
                entity.HasKey(e => e.BId);

                entity.ToTable("Booktbl");

                entity.Property(e => e.BId)
                    .ValueGeneratedNever()
                    .HasColumnName("bId");

                entity.Property(e => e.Bookname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cname)
                    .HasMaxLength(50)
                    .HasColumnName("cname");

                entity.HasOne(d => d.CnameNavigation)
                    .WithMany(p => p.Booktbls)
                    .HasForeignKey(d => d.Cname)
                    .HasConstraintName("FK__Booktbl__cname__3D5E1FD2");
            });

            modelBuilder.Entity<Categoytbl>(entity =>
            {
                entity.HasKey(e => e.Category)
                    .HasName("PK_Categoytbl_1");

                entity.ToTable("Categoytbl");

                entity.Property(e => e.Category).HasMaxLength(50);
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.ToTable("UserTable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bookname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("bookname");

                entity.Property(e => e.Bookreqno)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("BOOKREQNO")
                    .HasComputedColumnSql("(concat('BK-',datepart(year,getdate()),'-',datepart(month,getdate()),'-',right([id],(6))))", false);

                entity.Property(e => e.Catergory)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("catergory");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Lendeddate)
                    .HasColumnType("date")
                    .HasColumnName("lendeddate");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Returndate)
                    .HasColumnType("date")
                    .HasColumnName("returndate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

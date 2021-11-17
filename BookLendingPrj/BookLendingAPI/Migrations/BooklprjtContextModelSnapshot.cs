﻿// <auto-generated />
using System;
using BookLendingAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookLendingAPI.Migrations
{
    [DbContext(typeof(BooklprjtContext))]
    partial class BooklprjtContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookLendingAPI.Models.Booktbl", b =>
                {
                    b.Property<int>("BId")
                        .HasColumnType("int")
                        .HasColumnName("bId");

                    b.Property<string>("Bookname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Cid")
                        .HasColumnType("int")
                        .HasColumnName("cid");

                    b.HasKey("BId");

                    b.HasIndex("Cid");

                    b.ToTable("Booktbl");
                });

            modelBuilder.Entity("BookLendingAPI.Models.Categoytbl", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categoytbl");
                });

            modelBuilder.Entity("BookLendingAPI.Models.Booktbl", b =>
                {
                    b.HasOne("BookLendingAPI.Models.Categoytbl", "CidNavigation")
                        .WithMany("Booktbls")
                        .HasForeignKey("Cid")
                        .HasConstraintName("FK__Booktbl__cid__267ABA7A");

                    b.Navigation("CidNavigation");
                });

            modelBuilder.Entity("BookLendingAPI.Models.Categoytbl", b =>
                {
                    b.Navigation("Booktbls");
                });
#pragma warning restore 612, 618
        }
    }
}

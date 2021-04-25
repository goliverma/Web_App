﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using demo_web.Data;

namespace demo_web.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("demo_models.Table.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("fullname")
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("demo_models.Table.Movies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("movname")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("demo_models.Table.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<int>("accountid")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("datepost")
                        .HasColumnType("TEXT");

                    b.Property<int>("movId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("movieId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("rating")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("accountid");

                    b.HasIndex("movieId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("demo_models.Table.Review", b =>
                {
                    b.HasOne("demo_models.Table.Account", "account")
                        .WithMany()
                        .HasForeignKey("accountid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("demo_models.Table.Movies", "movie")
                        .WithMany("reviews")
                        .HasForeignKey("movieId");

                    b.Navigation("account");

                    b.Navigation("movie");
                });

            modelBuilder.Entity("demo_models.Table.Movies", b =>
                {
                    b.Navigation("reviews");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Eva.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Eva.Migrations
{
    [DbContext(typeof(EvaDbContext))]
    [Migration("20240709130247_newMigration")]
    partial class newMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Eva.Models.Portfolio", b =>
                {
                    b.Property<int>("PortfolioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PortfolioId"));

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PortfolioId");

                    b.ToTable("Portfolios");

                    b.HasData(
                        new
                        {
                            PortfolioId = 1,
                            UserEmail = "user1@example.com"
                        },
                        new
                        {
                            PortfolioId = 2,
                            UserEmail = "user2@example.com"
                        },
                        new
                        {
                            PortfolioId = 3,
                            UserEmail = "user3@example.com"
                        },
                        new
                        {
                            PortfolioId = 4,
                            UserEmail = "user4@example.com"
                        },
                        new
                        {
                            PortfolioId = 5,
                            UserEmail = "user5@example.com"
                        });
                });

            modelBuilder.Entity("Eva.Models.Share", b =>
                {
                    b.Property<string>("Symbol")
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Symbol");

                    b.ToTable("Shares");

                    b.HasData(
                        new
                        {
                            Symbol = "AAA",
                            Price = 100.00m
                        },
                        new
                        {
                            Symbol = "BBB",
                            Price = 200.00m
                        },
                        new
                        {
                            Symbol = "CCC",
                            Price = 300.00m
                        });
                });

            modelBuilder.Entity("Eva.Models.Trade", b =>
                {
                    b.Property<int>("TradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TradeId"));

                    b.Property<int>("PortfolioId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)");

                    b.Property<int>("TradeType")
                        .HasColumnType("int");

                    b.HasKey("TradeId");

                    b.HasIndex("PortfolioId");

                    b.ToTable("Trades");
                });

            modelBuilder.Entity("Eva.Models.Trade", b =>
                {
                    b.HasOne("Eva.Models.Portfolio", "Portfolio")
                        .WithMany("Trades")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("Eva.Models.Portfolio", b =>
                {
                    b.Navigation("Trades");
                });
#pragma warning restore 612, 618
        }
    }
}

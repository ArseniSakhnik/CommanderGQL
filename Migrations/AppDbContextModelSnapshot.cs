﻿// <auto-generated />
using CommanderGQL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CommanderGQL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CommanderGQL.Models.Command", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CommandLine")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HowTo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PlatformId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId");

                    b.ToTable("Commands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CommandLine = "dotnet build",
                            HowTo = "Build a project",
                            PlatformId = 1
                        },
                        new
                        {
                            Id = 2,
                            CommandLine = "dotnet run",
                            HowTo = "Run a project",
                            PlatformId = 2
                        },
                        new
                        {
                            Id = 3,
                            CommandLine = "docker compose up -d",
                            HowTo = "Start a docker compose file",
                            PlatformId = 2
                        },
                        new
                        {
                            Id = 4,
                            CommandLine = "docker-compose stop",
                            HowTo = "Stop docker compose file",
                            PlatformId = 2
                        });
                });

            modelBuilder.Entity("CommanderGQL.Models.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("LicenseKey")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Platforms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LicenseKey = "1234",
                            Name = ".NET 5"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Docker"
                        },
                        new
                        {
                            Id = 3,
                            LicenseKey = "42342",
                            Name = "Windows"
                        });
                });

            modelBuilder.Entity("CommanderGQL.Models.Command", b =>
                {
                    b.HasOne("CommanderGQL.Models.Platform", "Platform")
                        .WithMany("Commands")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("CommanderGQL.Models.Platform", b =>
                {
                    b.Navigation("Commands");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyVetNuske.Web.Data;

namespace MyVetNuske.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyVetNuske.Web.Data.Entities.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsAvailable");

                    b.Property<int?>("OwnerId");

                    b.Property<int?>("PetId");

                    b.Property<string>("Remarks");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PetId");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("MyVetNuske.Web.Data.Entities.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("PetId");

                    b.Property<string>("Remarks");

                    b.Property<int?>("ServiceTypeId");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("MyVetNuske.Web.Data.Entities.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FixedPhone")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("MyVetNuske.Web.Data.Entities.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Born");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("OwnerId");

                    b.Property<int?>("PetTypeId");

                    b.Property<int?>("RaceTypeId");

                    b.Property<string>("Remarks");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PetTypeId");

                    b.HasIndex("RaceTypeId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("MyVetNuske.Web.Data.Entities.PetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("PetTypes");
                });

            modelBuilder.Entity("MyVetNuske.Web.Data.Entities.RaceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("RaceTypes");
                });

            modelBuilder.Entity("MyVetNuske.Web.Data.Entities.ServiceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("MyVetNuske.Web.Data.Entities.Agenda", b =>
                {
                    b.HasOne("MyVetNuske.Web.Data.Entities.Owner", "Owner")
                        .WithMany("Agendas")
                        .HasForeignKey("OwnerId");

                    b.HasOne("MyVetNuske.Web.Data.Entities.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId");
                });

            modelBuilder.Entity("MyVetNuske.Web.Data.Entities.History", b =>
                {
                    b.HasOne("MyVetNuske.Web.Data.Entities.Pet", "Pet")
                        .WithMany("Histories")
                        .HasForeignKey("PetId");

                    b.HasOne("MyVetNuske.Web.Data.Entities.ServiceType", "ServiceType")
                        .WithMany("Histories")
                        .HasForeignKey("ServiceTypeId");
                });

            modelBuilder.Entity("MyVetNuske.Web.Data.Entities.Pet", b =>
                {
                    b.HasOne("MyVetNuske.Web.Data.Entities.Owner", "Owner")
                        .WithMany("Pets")
                        .HasForeignKey("OwnerId");

                    b.HasOne("MyVetNuske.Web.Data.Entities.PetType", "PetType")
                        .WithMany("Pets")
                        .HasForeignKey("PetTypeId");

                    b.HasOne("MyVetNuske.Web.Data.Entities.RaceType", "RaceType")
                        .WithMany("Pets")
                        .HasForeignKey("RaceTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}

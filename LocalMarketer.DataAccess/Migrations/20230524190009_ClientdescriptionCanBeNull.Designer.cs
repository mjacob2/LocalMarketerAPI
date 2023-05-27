﻿// <auto-generated />
using System;
using LocalMarketer.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocalMarketer.DataAccess.Migrations
{
    [DbContext(typeof(LocalMarketerDbContext))]
    [Migration("20230524190009_ClientdescriptionCanBeNull")]
    partial class ClientdescriptionCanBeNull
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.Attachment", b =>
                {
                    b.Property<int>("AttachmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttachmentId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("AttachmentId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("GoogleGroupId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ClientId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.ClientUser", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ClientId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ClientUser");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.Deal", b =>
                {
                    b.Property<int>("DealId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DealId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<string>("SellerFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.Property<string>("Stage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DealId");

                    b.HasIndex("PackageId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Deals");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.FormFaq", b =>
                {
                    b.Property<int>("FormFaqId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FormFaqId"));

                    b.Property<string>("Answer1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<string>("Question1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question6")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FormFaqId");

                    b.HasIndex("ProfileId");

                    b.ToTable("FormFaqs");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.FormProduct", b =>
                {
                    b.Property<int>("FormProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FormProductId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("FormProductId");

                    b.HasIndex("ProfileId");

                    b.ToTable("FormProducts");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.FormService", b =>
                {
                    b.Property<int>("FormServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FormServiceId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("FormServiceId");

                    b.HasIndex("ProfileId");

                    b.ToTable("FormServices");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NoteId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ToDoId")
                        .HasColumnType("int");

                    b.HasKey("NoteId");

                    b.HasIndex("ToDoId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.Package", b =>
                {
                    b.Property<int>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PackageId"));

                    b.Property<int>("DurationInMonths")
                        .HasColumnType("int");

                    b.Property<double>("MinimumPrice")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PackageId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CrteationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("FormProductId")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Link")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(58)
                        .HasColumnType("nvarchar(58)");

                    b.Property<string>("Price")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ProductId");

                    b.HasIndex("FormProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfileId"));

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerService")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("GoogleProfileId")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MediaLink")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("PostCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ProfileUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Street")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Voivodeship")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("WebsiteUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("ProfileId");

                    b.HasIndex("ClientId");

                    b.HasIndex("GoogleProfileId")
                        .IsUnique()
                        .HasFilter("[GoogleProfileId] IS NOT NULL");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("FormServiceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ServiceId");

                    b.HasIndex("FormServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.ToDo", b =>
                {
                    b.Property<int>("ToDoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ToDoId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<int>("DealId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ForRole")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<string>("Link1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ToDoId");

                    b.HasIndex("DealId");

                    b.ToTable("ToDos");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<bool>("AccesDenied")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.Attachment", b =>
                {
                    b.HasOne("LocalMarketer.DataAccess.Entities.Profile", "Profile")
                        .WithMany("Attachments")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.ClientUser", b =>
                {
                    b.HasOne("LocalMarketer.DataAccess.Entities.Client", "Client")
                        .WithMany("ClientUsers")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocalMarketer.DataAccess.Entities.User", "User")
                        .WithMany("ClientUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.Deal", b =>
                {
                    b.HasOne("LocalMarketer.DataAccess.Entities.Package", "Package")
                        .WithMany()
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocalMarketer.DataAccess.Entities.Profile", "Profile")
                        .WithMany("Deals")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Package");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.FormFaq", b =>
                {
                    b.HasOne("LocalMarketer.DataAccess.Entities.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.FormProduct", b =>
                {
                    b.HasOne("LocalMarketer.DataAccess.Entities.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.FormService", b =>
                {
                    b.HasOne("LocalMarketer.DataAccess.Entities.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.Note", b =>
                {
                    b.HasOne("LocalMarketer.DataAccess.Entities.ToDo", "ToDo")
                        .WithMany("Notes")
                        .HasForeignKey("ToDoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ToDo");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.Product", b =>
                {
                    b.HasOne("LocalMarketer.DataAccess.Entities.FormProduct", "FormProduct")
                        .WithMany("Products")
                        .HasForeignKey("FormProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FormProduct");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.Profile", b =>
                {
                    b.HasOne("LocalMarketer.DataAccess.Entities.Client", "Client")
                        .WithMany("Profiles")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.Service", b =>
                {
                    b.HasOne("LocalMarketer.DataAccess.Entities.FormService", "FormService")
                        .WithMany("Services")
                        .HasForeignKey("FormServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FormService");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.ToDo", b =>
                {
                    b.HasOne("LocalMarketer.DataAccess.Entities.Deal", "Deal")
                        .WithMany("ToDos")
                        .HasForeignKey("DealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deal");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.Client", b =>
                {
                    b.Navigation("ClientUsers");

                    b.Navigation("Profiles");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.Deal", b =>
                {
                    b.Navigation("ToDos");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.FormProduct", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.FormService", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.Profile", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("Deals");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.ToDo", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("LocalMarketer.DataAccess.Entities.User", b =>
                {
                    b.Navigation("ClientUsers");
                });
#pragma warning restore 612, 618
        }
    }
}

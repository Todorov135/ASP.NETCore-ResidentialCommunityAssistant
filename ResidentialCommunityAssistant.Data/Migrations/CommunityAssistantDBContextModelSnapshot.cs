﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResidentialCommunityAssistant.Data;

#nullable disable

namespace ResidentialCommunityAssistant.Data.Migrations
{
    [DbContext(typeof(CommunityAssistantDBContext))]
    partial class CommunityAssistantDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "492c2f53-e30a-4da9-b639-e599ef6d7794",
                            ConcurrencyStamp = "85d21beb-403e-487c-ac01-d08209de7b69",
                            Name = "HomeManager",
                            NormalizedName = "HOMEMANAGER"
                        },
                        new
                        {
                            Id = "df52a94f-e70f-4872-a5a8-48631411afdb",
                            ConcurrencyStamp = "e4025971-7bb2-4242-bdba-225be113c858",
                            Name = "StoreManager",
                            NormalizedName = "STOREMANAGER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                            RoleId = "492c2f53-e30a-4da9-b639-e599ef6d7794"
                        },
                        new
                        {
                            UserId = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                            RoleId = "df52a94f-e70f-4872-a5a8-48631411afdb"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("LocationTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("LocationTypeId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            LocationTypeId = 2,
                            Name = "Цар Борис III-ти Обединител",
                            Number = "37"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 2,
                            LocationTypeId = 2,
                            Name = "Александър Малинов",
                            Number = "78"
                        });
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.Apartament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Signature")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Apartaments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 2,
                            Number = 1,
                            OwnerId = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                            Signature = "A"
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 2,
                            Number = 2,
                            OwnerId = "579b52e0-38e4-4f41-a30f-31e72767c536",
                            Signature = "A"
                        },
                        new
                        {
                            Id = 3,
                            AddressId = 2,
                            Number = 3,
                            OwnerId = "88d33982-06d8-43f0-b809-7d6ed7f3ab23",
                            Signature = "A"
                        });
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LocalityTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)");

                    b.Property<string>("PostCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("LocalityTypeId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LocalityTypeId = 1,
                            Name = "Пловдив",
                            PostCode = "4000"
                        },
                        new
                        {
                            Id = 2,
                            LocalityTypeId = 1,
                            Name = "София",
                            PostCode = "1000"
                        });
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.CommunityTopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CreatorId");

                    b.ToTable("CommunityTopics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 2,
                            CreatedOn = new DateTime(2023, 6, 21, 15, 5, 15, 0, DateTimeKind.Unspecified),
                            CreatorId = "579b52e0-38e4-4f41-a30f-31e72767c536",
                            Description = "Закупуване, засаждане и подръжка на тревни чимове за двора пред сградата.",
                            Title = "Озеленяване на градинка"
                        });
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.ExtendedUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5d344717-beb0-4ff3-8d53-e6fee8200d8e",
                            Email = "homeManager@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Тодор",
                            LastName = "Тодоров",
                            LockoutEnabled = false,
                            NormalizedEmail = "HOMEMANAGER@MAIL.COM",
                            NormalizedUserName = "HOMEMANAGER@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEI/EvplGqnH06VdVP+kf7VH6vejv5MYWqYJXJevshpub14JstCEIFergR/puDmiUug==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a90ab7e1-a507-4746-81f0-803f2c3227f6",
                            TwoFactorEnabled = false,
                            UserName = "homeManager@mail.com"
                        },
                        new
                        {
                            Id = "579b52e0-38e4-4f41-a30f-31e72767c536",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d6db305c-4b22-42ab-9af5-4d08bb592147",
                            Email = "firstOwner@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Иван",
                            LastName = "Иванов",
                            LockoutEnabled = false,
                            NormalizedEmail = "FIRSTOWNER@MAIL.COM",
                            NormalizedUserName = "FIRSTOWNER@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEMmr3Tgi3+J8/Eb2ANu2QsX9gkngpq/l9nI+BC7BPmmw4JYsoBll3kGtMvNWQ2+bPA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f3b9ca5f-1e6f-412e-a691-d1bb40459296",
                            TwoFactorEnabled = false,
                            UserName = "firstOwner@mail.com"
                        },
                        new
                        {
                            Id = "88d33982-06d8-43f0-b809-7d6ed7f3ab23",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d1b78453-9a6c-42cc-99f7-113417155f23",
                            Email = "secondOwner@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Петър",
                            LastName = "Петров",
                            LockoutEnabled = false,
                            NormalizedEmail = "SECONDOWNER@MAIL.COM",
                            NormalizedUserName = "SECONDOWNER@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEBshc435HVTfp49ZVX77J3lCQSTJcd3G5xhikzYqPn4gENYyEeNq9O8c888fC5rY/A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9213dbf8-12cf-47b1-867c-e77ce0205044",
                            TwoFactorEnabled = false,
                            UserName = "secondOwner@mail.com"
                        });
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.HomeManagerApproval", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ApartamentId")
                        .HasColumnType("int");

                    b.Property<string>("HomeManagerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ApartamentId");

                    b.HasIndex("HomeManagerId");

                    b.ToTable("HomeManagersApprovals");
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.LocalityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.ToTable("LocalityTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "гр."
                        },
                        new
                        {
                            Id = 2,
                            Name = "с."
                        });
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.LocationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.ToTable("LocationTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ул."
                        },
                        new
                        {
                            Id = 2,
                            Name = "бул."
                        });
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.OrderCache", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrdersCaches");
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.OrderProduct", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrdersProducts");
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ImgURL")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<decimal>("Price")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Ако използвате uTorrent, това е знамето за Вас.",
                            ImgURL = "https://shop.flagfactory.bg/image/cache/catalog/products/flags/pirates/pirates_mockups/pirate2_mockup-600x360.png",
                            Name = "Пиратско знаме",
                            Price = 10.00m,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 2,
                            Description = "Желаете да завоювате чужди светове?!? Искате жителите да треперя при Вашето присъствие?!? Станете саян!",
                            ImgURL = "https://external-preview.redd.it/xLN_fXFlM6wM84w_VGkRJut0LqNDug4gs-c66_5zZ9o.jpg?auto=webp&s=3dbf10a8efddb301911796c52fadba948206fdbf",
                            Name = "Саянско знаме",
                            Price = 100.00m,
                            Quantity = 100
                        },
                        new
                        {
                            Id = 3,
                            Description = "Покажи на живущите, че си бъдещ доставчик!",
                            ImgURL = "https://e7.pngegg.com/pngimages/407/294/png-clipart-planet-express-ship-bender-t-shirt-professor-farnsworth-bender-television-logo.png",
                            Name = "Planet express знаме",
                            Price = 12.00m,
                            Quantity = 100
                        });
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.UserAddress", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<bool>("IsUserHomeManager")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "AddressId");

                    b.HasIndex("AddressId");

                    b.ToTable("UsersAddresses");

                    b.HasData(
                        new
                        {
                            UserId = "8815d5cc-c403-43e8-b2d3-40f57a8d1d61",
                            AddressId = 2,
                            IsUserHomeManager = false
                        },
                        new
                        {
                            UserId = "579b52e0-38e4-4f41-a30f-31e72767c536",
                            AddressId = 2,
                            IsUserHomeManager = false
                        },
                        new
                        {
                            UserId = "88d33982-06d8-43f0-b809-7d6ed7f3ab23",
                            AddressId = 2,
                            IsUserHomeManager = false
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ResidentialCommunityAssistant.Data.Models.ExtendedUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ResidentialCommunityAssistant.Data.Models.ExtendedUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResidentialCommunityAssistant.Data.Models.ExtendedUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ResidentialCommunityAssistant.Data.Models.ExtendedUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.Address", b =>
                {
                    b.HasOne("ResidentialCommunityAssistant.Data.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResidentialCommunityAssistant.Data.Models.LocationType", "LocationType")
                        .WithMany()
                        .HasForeignKey("LocationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("LocationType");
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.Apartament", b =>
                {
                    b.HasOne("ResidentialCommunityAssistant.Data.Models.Address", "Address")
                        .WithMany("Apartaments")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResidentialCommunityAssistant.Data.Models.ExtendedUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Address");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.City", b =>
                {
                    b.HasOne("ResidentialCommunityAssistant.Data.Models.LocalityType", "LocalityType")
                        .WithMany()
                        .HasForeignKey("LocalityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocalityType");
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.CommunityTopic", b =>
                {
                    b.HasOne("ResidentialCommunityAssistant.Data.Models.Address", "Address")
                        .WithMany("CommunityTopics")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResidentialCommunityAssistant.Data.Models.ExtendedUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.HomeManagerApproval", b =>
                {
                    b.HasOne("ResidentialCommunityAssistant.Data.Models.Apartament", "Apartament")
                        .WithMany()
                        .HasForeignKey("ApartamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResidentialCommunityAssistant.Data.Models.ExtendedUser", "HomeManager")
                        .WithMany()
                        .HasForeignKey("HomeManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartament");

                    b.Navigation("HomeManager");
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.Order", b =>
                {
                    b.HasOne("ResidentialCommunityAssistant.Data.Models.ExtendedUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.OrderCache", b =>
                {
                    b.HasOne("ResidentialCommunityAssistant.Data.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResidentialCommunityAssistant.Data.Models.ExtendedUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.OrderProduct", b =>
                {
                    b.HasOne("ResidentialCommunityAssistant.Data.Models.Order", "Order")
                        .WithMany("OrdersProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResidentialCommunityAssistant.Data.Models.Product", "Product")
                        .WithMany("OrdersProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.UserAddress", b =>
                {
                    b.HasOne("ResidentialCommunityAssistant.Data.Models.Address", "Address")
                        .WithMany("Homeowners")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResidentialCommunityAssistant.Data.Models.ExtendedUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.Address", b =>
                {
                    b.Navigation("Apartaments");

                    b.Navigation("CommunityTopics");

                    b.Navigation("Homeowners");
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.Order", b =>
                {
                    b.Navigation("OrdersProducts");
                });

            modelBuilder.Entity("ResidentialCommunityAssistant.Data.Models.Product", b =>
                {
                    b.Navigation("OrdersProducts");
                });
#pragma warning restore 612, 618
        }
    }
}

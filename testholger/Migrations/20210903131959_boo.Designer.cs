﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using testholger;

namespace testholger.Migrations
{
    [DbContext(typeof(ForumContext))]
    [Migration("20210903131959_boo")]
    partial class boo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("testholger.Posts", b =>
                {
                    b.Property<int>("PostsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostLikes")
                        .HasColumnType("int");

                    b.Property<int?>("TopicsId")
                        .HasColumnType("int");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("PostsId");

                    b.HasIndex("TopicsId");

                    b.HasIndex("UsersId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("testholger.Topics", b =>
                {
                    b.Property<int>("TopicsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberComments")
                        .HasColumnType("int");

                    b.Property<string>("OriginalPost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TopicSubject")
                        .HasColumnType("int");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("TopicsId");

                    b.HasIndex("UsersId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("testholger.Users", b =>
                {
                    b.Property<int>("UsersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsersId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("testholger.Posts", b =>
                {
                    b.HasOne("testholger.Topics", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicsId");

                    b.HasOne("testholger.Users", "user")
                        .WithMany()
                        .HasForeignKey("UsersId");

                    b.Navigation("Topic");

                    b.Navigation("user");
                });

            modelBuilder.Entity("testholger.Topics", b =>
                {
                    b.HasOne("testholger.Users", "User")
                        .WithMany()
                        .HasForeignKey("UsersId");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}

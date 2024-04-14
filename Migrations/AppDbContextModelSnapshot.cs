﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RedditAPI;

#nullable disable

namespace RedditAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RedditAPI.Models.FetchHistory", b =>
                {
                    b.Property<int>("FetchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FetchId"));

                    b.Property<DateTime>("FetchDate")
                        .HasColumnType("datetime");

                    b.Property<int>("SubredditId")
                        .HasColumnType("int");

                    b.HasKey("FetchId");

                    b.HasIndex("SubredditId");

                    b.ToTable("FetchHistories");
                });

            modelBuilder.Entity("RedditAPI.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FetchDate")
                        .HasColumnType("datetime");

                    b.Property<int>("SubredditId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostId");

                    b.HasIndex("SubredditId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("RedditAPI.Models.Subreddit", b =>
                {
                    b.Property<int>("SubredditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubredditId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubredditId");

                    b.ToTable("Subreddits");
                });

            modelBuilder.Entity("RedditAPI.Models.FetchHistory", b =>
                {
                    b.HasOne("RedditAPI.Models.Subreddit", "Subreddit")
                        .WithMany()
                        .HasForeignKey("SubredditId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Subreddit");
                });

            modelBuilder.Entity("RedditAPI.Models.Post", b =>
                {
                    b.HasOne("RedditAPI.Models.Subreddit", "Subreddit")
                        .WithMany("Posts")
                        .HasForeignKey("SubredditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subreddit");
                });

            modelBuilder.Entity("RedditAPI.Models.Subreddit", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
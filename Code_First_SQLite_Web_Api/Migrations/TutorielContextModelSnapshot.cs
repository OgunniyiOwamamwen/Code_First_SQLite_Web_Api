﻿// <auto-generated />
using System;
using Code_First_SQLite_Web_Api.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Code_First_SQLite_Web_Api.Migrations
{
    [DbContext(typeof(TutorielContext))]
    partial class TutorielContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Code_First_SQLite_Web_Api.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseID");

                    b.Property<int>("PlayerID");

                    b.Property<int?>("TournamentID");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("PlayerID");

                    b.HasIndex("TournamentID");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("Code_First_SQLite_Web_Api.Models.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EnrollmentDate");

                    b.Property<string>("Tag");

                    b.HasKey("ID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Code_First_SQLite_Web_Api.Models.Tournament", b =>
                {
                    b.Property<int>("TournamentID");

                    b.Property<int>("Credits");

                    b.Property<string>("Title");

                    b.HasKey("TournamentID");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("Code_First_SQLite_Web_Api.Models.Enrollment", b =>
                {
                    b.HasOne("Code_First_SQLite_Web_Api.Models.Player", "Player")
                        .WithMany("Enrollments")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Code_First_SQLite_Web_Api.Models.Tournament", "Tournament")
                        .WithMany("Enrollments")
                        .HasForeignKey("TournamentID");
                });
#pragma warning restore 612, 618
        }
    }
}

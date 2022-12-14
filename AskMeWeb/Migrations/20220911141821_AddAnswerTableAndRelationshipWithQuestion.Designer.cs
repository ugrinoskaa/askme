// <auto-generated />
using System;
using AskMeWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AskMeWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220911141821_AddAnswerTableAndRelationshipWithQuestion")]
    partial class AddAnswerTableAndRelationshipWithQuestion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AskMeWeb.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("questionId")
                        .HasColumnType("int");

                    b.Property<int>("votes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("questionId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("AskMeWeb.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("votes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("AskMeWeb.Models.Answer", b =>
                {
                    b.HasOne("AskMeWeb.Models.Question", "question")
                        .WithMany("answers")
                        .HasForeignKey("questionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("question");
                });

            modelBuilder.Entity("AskMeWeb.Models.Question", b =>
                {
                    b.Navigation("answers");
                });
#pragma warning restore 612, 618
        }
    }
}

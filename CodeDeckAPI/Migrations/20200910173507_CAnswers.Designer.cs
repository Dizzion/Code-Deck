﻿// <auto-generated />
using CodeDeckAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeDeckAPI.Migrations
{
    [DbContext(typeof(CodeChallengeContext))]
    [Migration("20200910173507_CAnswers")]
    partial class CAnswers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CodeDeckAPI.Models.Answers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodeChallengeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CodeChallengeId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("CodeDeckAPI.Models.CAnswers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ANswersId")
                        .HasColumnType("int");

                    b.Property<string>("AnswerCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ANswersId")
                        .IsUnique();

                    b.ToTable("CAnswers");
                });

            modelBuilder.Entity("CodeDeckAPI.Models.CodeChallenge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChallengeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CodeChallenges");
                });

            modelBuilder.Entity("CodeDeckAPI.Models.JavaAnswers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnswerCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AnswersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswersId")
                        .IsUnique();

                    b.ToTable("JavaAnswers");
                });

            modelBuilder.Entity("CodeDeckAPI.Models.JavaScriptAnswers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnswersId")
                        .HasColumnType("int");

                    b.Property<string>("JavaScriptAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnswersId")
                        .IsUnique();

                    b.ToTable("JavaScriptAnswers");
                });

            modelBuilder.Entity("CodeDeckAPI.Models.PythonAnswers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnswerCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AnswersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswersId")
                        .IsUnique();

                    b.ToTable("PythonAnswers");
                });

            modelBuilder.Entity("CodeDeckAPI.Models.Answers", b =>
                {
                    b.HasOne("CodeDeckAPI.Models.CodeChallenge", "CodeChallenge")
                        .WithMany()
                        .HasForeignKey("CodeChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CodeDeckAPI.Models.CAnswers", b =>
                {
                    b.HasOne("CodeDeckAPI.Models.Answers", "Answers")
                        .WithOne("CAnswers")
                        .HasForeignKey("CodeDeckAPI.Models.CAnswers", "ANswersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CodeDeckAPI.Models.JavaAnswers", b =>
                {
                    b.HasOne("CodeDeckAPI.Models.Answers", "Answers")
                        .WithOne("JavaAnswer")
                        .HasForeignKey("CodeDeckAPI.Models.JavaAnswers", "AnswersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CodeDeckAPI.Models.JavaScriptAnswers", b =>
                {
                    b.HasOne("CodeDeckAPI.Models.Answers", "Answers")
                        .WithOne("JavaScriptAnswers")
                        .HasForeignKey("CodeDeckAPI.Models.JavaScriptAnswers", "AnswersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CodeDeckAPI.Models.PythonAnswers", b =>
                {
                    b.HasOne("CodeDeckAPI.Models.Answers", "Answers")
                        .WithOne("PythonAnswers")
                        .HasForeignKey("CodeDeckAPI.Models.PythonAnswers", "AnswersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
